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

	[SerializeField]
	private SaveGameFunc mySaveM;

	private int currentPointCode;

	private DecisionPoint currentPoint;

	// Use this for initialization
	void Start () {
		SetUpPoint();
	}

	public void SetUpPoint()
	{
		currentPointCode = mySaveM.LoadGame();

		currentPoint = myDataBase.decision[currentPointCode];

		myImage.sprite = currentPoint.myImage;
		
		SetUpButtons(currentPoint.decisionOptions.Length);

		Debug.Log("hola mundo47");

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
		SetUpCurrentPointCode(currentPoint.codeNextPoint[0]);
	}

	public void SetOption1()
	{
		SetUpCurrentPointCode(currentPoint.codeNextPoint[1]);
	}

	public void SetOption2()
	{
		SetUpCurrentPointCode(currentPoint.codeNextPoint[2]);
	}

	public void SetOption3()
	{

		SetUpCurrentPointCode(currentPoint.codeNextPoint[3]);

	}

	private void SetUpCurrentPointCode(int pointToChange)
	{
		currentPointCode = pointToChange;
		mySaveM.SaveProgress(pointToChange);
		SetUpPoint();
	}


}
