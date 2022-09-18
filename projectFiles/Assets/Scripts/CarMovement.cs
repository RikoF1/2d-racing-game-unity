using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CarMovement : MonoBehaviour {

	public float MaximumEngineForce;
	public float MaximumReverseEngineForce;
	public float MaximumSteeringTorque;
	public float ReversePower;
	public float Acceleration;
	public float Deceleration;
	public Transform VisualsParent;
	public float SpinningDuration;
	public int SpinningRotations;


	float m_EnginePower = 0f;
	float m_TargetEnginePower = 0f;
	float m_SteeringDirection = 0f;
	float m_CurrentMaximumEnginePower = 1f;
	bool m_IsSpinning = false;

	Rigidbody2D m_Body;

	private void Awake()
	{
		m_Body = GetComponent<Rigidbody2D>();
	}

	private void Update()
	{
		UpdateEnginePower();
	}

	void UpdateEnginePower()
	{
		float acceleration = Acceleration;

		if( m_TargetEnginePower == 0f )
		{
			acceleration = Deceleration;
		}

		float targetEnginePower = m_TargetEnginePower * m_CurrentMaximumEnginePower;

		m_EnginePower = Mathf.MoveTowards( m_EnginePower, targetEnginePower, acceleration * Time.deltaTime );
	
		if( m_IsSpinning == true )
		{
			m_EnginePower = 0f;
		}
	}


	void FixedUpdate()
	{
		ApplyEngineForce();
		ApplySteeringForce();
	}

	void ApplyEngineForce()
	{
		float maximumEngineForce = MaximumEngineForce;

		if( m_EnginePower < 0f )
		{
			maximumEngineForce = MaximumReverseEngineForce;
			
		}

		m_Body.AddForce( transform.up * m_EnginePower * maximumEngineForce, ForceMode2D.Force );
		
	}

	void ApplySteeringForce()
	{ 
		m_Body.AddTorque( m_SteeringDirection * MaximumSteeringTorque, ForceMode2D.Force );
	}

	public void SetEnginePower( float enginePower )
	{
		m_EnginePower = Mathf.Clamp( enginePower, -1f , 1f);
	}

	public void SetSteeringDirection( float steeringDirection )
	{
		m_SteeringDirection = Mathf.Clamp( steeringDirection, -1f, 1f);
	}

	void StartSpinning()
	{
		if( m_IsSpinning == true )
		{
			return;
		}

		StartCoroutine( SpinningRoutine() );
	}
		IEnumerator SpinningRoutine()
		{
			m_IsSpinning = true;
			float spinningTime = 0f;

			while ( spinningTime < SpinningDuration )
			{
				float spinningProgress = spinningTime / SpinningDuration;
				spinningTime += Time.deltaTime;

				VisualsParent.transform.localRotation = Quaternion.Euler( 0f, 0f, spinningProgress * SpinningRotations * 360f );

				yield return null;
			}

			VisualsParent.transform.localRotation = Quaternion.identity;
			m_IsSpinning = false;
			
		}

	public void OnCollideWithObstacle()
	{
		m_EnginePower = 0f;
	}

	public void OnCollideWithOil()
	{
		m_EnginePower = 0f;
		StartSpinning();
	}

	public void OnEnterOffCourseArea()
	{
		m_CurrentMaximumEnginePower = 0.4f;
	}

	public void OnExitOffCourseArea()
	{
		m_CurrentMaximumEnginePower = 1f;
	}
}