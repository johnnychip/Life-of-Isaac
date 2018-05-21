using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEditor.SceneManagement;
using DG.Tweening;

public class GameManager : MonoBehaviour {

	[SerializeField]
	private DataBase myDataBase;

	[SerializeField]
	private Image myImage;

	[SerializeField]
	private Button[] myButtons;

	[SerializeField]
	private SaveGameFunc mySaveM;

	[SerializeField]
	private AudioSource myAudio;

	[SerializeField]
	private AudioSource myMusic;

	private int currentPointCode;

	private DecisionPoint currentPoint;

	// Use this for initialization
	void Start () {
		SetUpPoint();
		DOTween.Init(false, true, LogBehaviour.ErrorsOnly);
	}

	public void SetUpPoint()
	{
		currentPointCode = mySaveM.LoadGame();

		currentPoint = myDataBase.decision[currentPointCode];

		if(currentPoint.myClip!=null)
		{
			myAudio.clip = currentPoint.myClip;

			myAudio.Play();
		}

		if(currentPoint.isTimeToChangeSong)
		{
			FadeOut(currentPoint.song);
		}

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

	public void FadeOut(AudioClip newSong)
	{

		myMusic.DOFade(0f,0.3f);
		StartCoroutine(Fade(newSong));

	}

	public void FadeIn(AudioClip newSong)
	{
		
		myMusic.clip = newSong;
		myMusic.Play();
		myMusic.DOFade(1f, 0.15f);
	}	

	IEnumerator Fade(AudioClip newSong) {
        yield return new WaitForSeconds(0.15f);
		FadeIn(newSong);
    
}

	public void SetOption0()
	{
		if(currentPoint.isFinalFrame)
		{
			NextScene(currentPoint.nextScene);
		}else
		{
			SetUpCurrentPointCode(currentPoint.codeNextPoint[0]);
		}
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

	public void NextScene(int sceneNum)
	{
		EditorSceneManager.LoadScene(sceneNum);
	}


}
