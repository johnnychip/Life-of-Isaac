using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SaveGameFunc : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	public void SaveProgress(int point)
	{
		PlayerPrefs.SetInt("Progress",point);
	}

	public int LoadGame()
	{
		return PlayerPrefs.GetInt("Progress",0);
	}

	public void ResetGameSaved()
	{
		PlayerPrefs.DeleteAll();
	}
}
