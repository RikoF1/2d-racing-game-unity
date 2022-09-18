using UnityEngine;
using UnityEngine.UI;
using System.Collections;

[RequireComponent( typeof(LapManager))]
public class LapManagerUI : MonoBehaviour {
	
	public Text LapTimeInfoText;

	LapManager m_LapManager;

	private void Awake()
	{
		m_LapManager = GetComponent<LapManager>();
	}

	void Update()
	{

	}

	void UpdateLapTimeInfoText()
	{
		LapTimeInfoText.text = "Current:  " + SecondsToTime( m_LapManager.CurrentLapTime ) + "\n"
			+ "Last: "+ SecondsToTime( m_LapManager.CurrentLapTime ) + "\n"
			+ "Best: " + SecondsToTime( m_LapManager.BestLapTime ) + "";
	}

	string SecondsToTime( float seconds )
	{
		int displayMinutes = Mathf.FloorToInt( seconds / 60f );
		int displaySeconds = Mathf.FloorToInt( seconds % 60f );
		int displayFractionSeconds = Mathf.FloorToInt( ( seconds - displaySeconds ) * 100f );

		return displayMinutes + ":" + displaySeconds.ToString( "00" ) + ":" + displayFractionSeconds.ToString( "00" );
	}	
		
}
