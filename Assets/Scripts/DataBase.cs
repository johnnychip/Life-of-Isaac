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

	public DecisionPoint(DecisionPoint clone)
	{
		this.codePoint = clone.codePoint;
	}

}
