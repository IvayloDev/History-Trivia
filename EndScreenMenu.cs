using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class EndScreenMenu : MonoBehaviour {

	[SerializeField]
	private Text EndScoreText;

	public GameObject EndScreenGO;

	public Text QuestionText,RightAnswerText,WrongAnswerTimeOut;



	void Start (){
		EndScreenGO.SetActive(false);
			
	}

	void Update () {
		EndScoreText.text = "Верни отговори : " + TopPanelManager.rightAnsw;


		if(TopPanelManager.rightAnsw >=SharedScoreScript.RIGHTANSWERS) {
			SharedScoreScript.RIGHTANSWERS = TopPanelManager.rightAnsw;
		}

		QuestionText.text = QuestionManager.currentQuestion.questionText;
		RightAnswerText.text = QuestionManager.currentQuestion.answerA;
		WrongAnswerTimeOut.text = (QuestionManager.CountDownTime <= 0) ? "Изтече времето" : "Грешен отговор"; 


	}
	

	public void onReplayClick() {
		Application.LoadLevel("Game");
	}

	public void onMenuClick() {
		Application.LoadLevel("MainMenu");
		AdsScript.adCount++;
	}



}
