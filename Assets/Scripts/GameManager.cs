using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour {

	[SerializeField]
	private DataBase myDataBase;

	[SerializeField]
	private Image myImage;

	[SerializeField]
	private Button[] myButtons;

	private int currentPointCode;

	private DecisionPoint currentPoint;

	// Use this for initialization
	void Start () {
		SetUpPoint();
	}

	public void SetUpPoint()
	{
		currentPoint = myDataBase.decision[currentPointCode];

		myImage.sprite = currentPoint.myImage;
		
		SetUpButtons(currentPoint.decisionOptions.Length);

	}

	public void SetUpButtons(int numOptions)
	{
		foreach (Button temp in myButtons)
		{
			temp.gameObject.SetActive(false);
		}

		for(int i = 0 ; i<numOptions; i++)
		{
			myButtons[i].gameObject.SetActive(true);
			myButtons[i].GetComponentInChildren<Text>().text = currentPoint.decisionOptions[i];
		}

		
	}

	public void SetOption0()
	{
		currentPointCode = currentPoint.codeNextPoint[0];
		SetUpPoint();
	}

	public void SetOption1()
	{
		currentPointCode = currentPoint.codeNextPoint[1];
		SetUpPoint();
	}

	public void SetOption2()
	{
		currentPointCode = currentPoint.codeNextPoint[2];
		SetUpPoint();
	}

	public void SetOption3()
	{
		currentPointCode = currentPoint.codeNextPoint[3];
		SetUpPoint();
	}


}
