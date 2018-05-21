using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class DataBase : ScriptableObject {

	public DecisionPoint[] decision;

}

[System.Serializable]
public class DecisionPoint {

	public int codePoint;

	public int[] codeNextPoint;

	public string[] decisionOptions;

	public Sprite myImage;

	public AudioClip myClip;

	public AudioClip song;

	public bool isFinalFrame;

	public bool isTimeToChangeSong;

	public int nextScene;
	public DecisionPoint(DecisionPoint clone)
	{
		this.codePoint = clone.codePoint;
	}

}
