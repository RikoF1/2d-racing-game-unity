using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayOnPress : MonoBehaviour {

	public AudioSource TiresScreech;
	public AudioSource EngineSound;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
		if(Input.GetKeyDown( KeyCode.A ) && Input.GetKeyDown( KeyCode.D ) && Input.GetKeyDown( KeyCode.LeftArrow ) && Input.GetKeyDown( KeyCode.RightArrow )) {
			TiresScreech.enabled = true;
			TiresScreech.loop = true;
		}
		else
		{
			{
				TiresScreech.enabled = false;
				TiresScreech.loop = false;
			}
		}

		if(Input.GetKeyDown( KeyCode.W ) && Input.GetKeyDown( KeyCode.S ) && Input.GetKeyDown( KeyCode.UpArrow ) && Input.GetKeyDown( KeyCode.DownArrow )){
			EngineSound.enabled = true;
			EngineSound.loop = true;
		}
		else
		{
			{
				EngineSound.enabled = false;
				EngineSound.loop = false;
			}
		}
	}
}
