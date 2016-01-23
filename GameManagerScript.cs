using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class GameManagerScript : MonoBehaviour {

	public GameObject X1,X2,X3,fiftyFifty,callAFriend,helpFromAudience;

	[SerializeField]
	private GameObject AnswerB,AnswerC,AnswerD;

	public GameObject CharA,CharB,CharC,CharD;

	public GameObject Button1,Button2,Button3,Button4;

	public Text CorrectAnswerGO,Wrong1,Wrong2,Wrong3;

	public GameObject Panel;
	public Text FriendAdviceText;

	public static int NumForFiftyFifty = 0;
	


	// Use this for initialization
	void Start () {


		fiftyFifty.GetComponent<Button>().enabled = true;
		callAFriend.GetComponent<Button>().enabled = true;
		helpFromAudience.GetComponent<Button>().enabled = true;
		Panel.SetActive(false);
		

		//hide "cross" images
		X1.SetActive(false);
		X2.SetActive(false);
		X3.SetActive(false);
		
	}
	
	public void onJoker1Click(){
		//Disable button and show cross
		fiftyFifty.GetComponent<Button>().enabled = false;
		X1.SetActive(true);
		fiftyFiftyJoker();
	}
	
	public void onJoker2Click(){
		//Disable button and show cross
		callAFriend.GetComponent<Button>().enabled = false;
		X2.SetActive(true);
		CallAFriend();
	}
	
	public void onJoker3Click(){
		//Disable button and show cross
		helpFromAudience.GetComponent<Button>().enabled = false;
		X3.SetActive(true);
		AudienceChoice();
	}


	public void AudienceChoice() {

		QuestionManager.NewQuestionBool = true;

		int CorrectAnswer = Random.Range(50,100);
		int BAnswer = Random.Range(5,50);
		int CAnswer = Random.Range(5,50);
		int DAnswer = Random.Range(5,50);

		if(QuestionManager.NewQuestionBool){

		CorrectAnswerGO.text = CorrectAnswer + " %";

			if(AnswerB.activeInHierarchy){
			Wrong1.text = BAnswer + " %";
			}

			if(AnswerC.activeInHierarchy){
			Wrong2.text = CAnswer + " %";
			}

			if(AnswerD.activeInHierarchy){
			Wrong3.text = DAnswer + " %";
			}
		}
	}

	public void OnOkClick(){
		Panel.SetActive(false);
		
		Button1.GetComponent<Button>().enabled = true;
		Button2.GetComponent<Button>().enabled = true;
		Button3.GetComponent<Button>().enabled = true;
		Button4.GetComponent<Button>().enabled = true;
	}

	public void CallAFriend(){

		Button1.GetComponent<Button>().enabled = false;
		Button2.GetComponent<Button>().enabled = false;
		Button3.GetComponent<Button>().enabled = false;
		Button4.GetComponent<Button>().enabled = false;
		
		Panel.SetActive(true);

		int Chance = Random.Range(0,10);

		if(Chance == 5){
		FriendAdviceText.text = "Мисля, че верният" + "\n" + "отговор е: " + QuestionManager.currentQuestion.answerB;
		}
		else{
		FriendAdviceText.text = "Мисля, че верният" + "\n" + "отговор е: " + QuestionManager.currentQuestion.answerA;
		}
	}

	public void fiftyFiftyJoker() {

		NumForFiftyFifty = Random.Range(1,4);
		switch (NumForFiftyFifty) {
		case 1:
			AnswerB.SetActive(false);
			Wrong1.text = "";
			AnswerC.SetActive(false);
			Wrong2.text = "";
			
			break;
		case 2:
			AnswerB.SetActive(false);
			Wrong1.text = "";
			AnswerD.SetActive(false);
			Wrong3.text = "";
					
			break;
		case 3:
			AnswerC.SetActive(false);
			Wrong2.text = "";
			AnswerD.SetActive(false);
			Wrong3.text = "";
			
			break;

		}

	}
}
