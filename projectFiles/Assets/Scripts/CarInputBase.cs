using System.Collections;
using System.Collections.Generic;
using UnityEngine;

	[RequireComponent( typeof( CarMovement))]
public class CarInputBase : MonoBehaviour 
{
	CarMovement m_Movement;

	private void Awake()
	{
		m_Movement = GetComponent<CarMovement>();
	}

	protected void SetSteeringDirection( float steeringDirection )
	{
		m_Movement.SetSteeringDirection( steeringDirection);
	}

	protected void SetEnginePower( float enginePower )
	{
		m_Movement.SetEnginePower( enginePower );
	}
	
}
