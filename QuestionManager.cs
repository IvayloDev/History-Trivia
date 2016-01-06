using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class QuestionManager : MonoBehaviour {
	[SerializeField]
	private TextAsset questionDataXMLFile;
	private QuestionData questionData;
	private Question currentQuestion;
	public GameObject QuestionText,AnswerAGO,AnswerBGO,AnswerCGO,AnswerDGO;
	private Vector3 Button1Pos = new Vector3( 0, 40, 0);
	private Vector3 Button2Pos = new Vector3( 0, -110, 0);
	private Vector3 Button3Pos = new Vector3( 0, -260, 0);
	private Vector3 Button4Pos = new Vector3( 0, -410, 0);
	private Vector3 QuestionPos = new Vector3(-860,0,0);
	public Animator QuestionAnim,AnswersAnim,RightAnswerAnim;
	
	private int RandomButtPos, q;
	
	void Start() {
		questionData = QuestionData.LoadFromText(questionDataXMLFile.text);
	
		int q = Random.Range(0, questionData.questions.Count);
		currentQuestion = questionData.questions[q];
		
		int RandomButtPos = Random.Range(1,5);


		switch (RandomButtPos){
		case 1:
			AnswerAGO.transform.localPosition = Button1Pos;
			AnswerBGO.transform.localPosition = Button2Pos;
			AnswerCGO.transform.localPosition = Button3Pos;
			AnswerDGO.transform.localPosition = Button4Pos;
			
			break;
		case 2:
			AnswerAGO.transform.localPosition = Button2Pos;
			AnswerBGO.transform.localPosition = Button1Pos;
			AnswerCGO.transform.localPosition = Button4Pos;
			AnswerDGO.transform.localPosition = Button3Pos;
			break;
		case 3:
			AnswerAGO.transform.localPosition = Button3Pos;
			AnswerBGO.transform.localPosition = Button4Pos;
			AnswerCGO.transform.localPosition = Button2Pos;
			AnswerDGO.transform.localPosition = Button1Pos;
			break;
		case 4:
			AnswerAGO.transform.localPosition = Button4Pos;
			AnswerBGO.transform.localPosition = Button3Pos;
			AnswerCGO.transform.localPosition = Button1Pos;
			AnswerDGO.transform.localPosition = Button2Pos;
			break;
		}
		
		//Adding Values To Text
		QuestionText.GetComponent<Text>().text = currentQuestion.questionText;
		
		AnswerAGO.GetComponentInChildren<Text>().text = currentQuestion.answerA;
		AnswerBGO.GetComponentInChildren<Text>().text = currentQuestion.answerB;
		AnswerCGO.GetComponentInChildren<Text>().text = currentQuestion.answerC;
		AnswerDGO.GetComponentInChildren<Text>().text = currentQuestion.answerD;

	}

	// Call This For New Question
	IEnumerator SetNewQuestion () {


		int q = Random.Range(0,questionData.questions.Count);
		//q = Random.Range(0, questionData.questions.Count);
		currentQuestion = questionData.questions[q];
		
		RandomButtPos = Random.Range(1,5);

		yield return new WaitForSeconds(1f);

		QuestionAnim.SetBool("NewQuestionAnimation",true);
		AnswersAnim.SetBool("NewAnswerAnimation",true);

		AnswerAGO.GetComponent<Image>().color = Color.white;
		AnswerBGO.GetComponent<Image>().color = Color.white;
		AnswerCGO.GetComponent<Image>().color = Color.white;
		AnswerDGO.GetComponent<Image>().color = Color.white;

		
		
		AnswerAGO.GetComponent<Button>().enabled = true;
		AnswerBGO.GetComponent<Button>().enabled = true;
		AnswerCGO.GetComponent<Button>().enabled = true;
		AnswerDGO.GetComponent<Button>().enabled = true;

		yield return new WaitForSeconds(0.1f);

		switch (RandomButtPos){
		case 1:
			AnswerAGO.transform.localPosition = Button1Pos;
			AnswerBGO.transform.localPosition = Button2Pos;
			AnswerCGO.transform.localPosition = Button3Pos;
			AnswerDGO.transform.localPosition = Button4Pos;
			
			break;
		case 2:
			AnswerAGO.transform.localPosition = Button2Pos;
			AnswerBGO.transform.localPosition = Button1Pos;
			AnswerCGO.transform.localPosition = Button4Pos;
			AnswerDGO.transform.localPosition = Button3Pos;
			break;
		case 3:
			AnswerAGO.transform.localPosition = Button3Pos;
			AnswerBGO.transform.localPosition = Button4Pos;
			AnswerCGO.transform.localPosition = Button2Pos;
			AnswerDGO.transform.localPosition = Button1Pos;
			break;
		case 4:
			AnswerAGO.transform.localPosition = Button4Pos;
			AnswerBGO.transform.localPosition = Button3Pos;
			AnswerCGO.transform.localPosition = Button1Pos;
			AnswerDGO.transform.localPosition = Button2Pos;
			break;
		}
		
		//Adding Values To Text
		QuestionText.GetComponent<Text>().text = currentQuestion.questionText;
		
		AnswerAGO.GetComponentInChildren<Text>().text = currentQuestion.answerA;
		AnswerBGO.GetComponentInChildren<Text>().text = currentQuestion.answerB;
		AnswerCGO.GetComponentInChildren<Text>().text = currentQuestion.answerC;
		AnswerDGO.GetComponentInChildren<Text>().text = currentQuestion.answerD;

		yield return new WaitForSeconds(0.1f);
		QuestionAnim.SetBool("NewQuestionAnimation",false);
		AnswersAnim.SetBool("NewAnswerAnimation",false);
		
		
	}


	public void OnRightAnswerClick(){

		CorrectAnswerSelected(0);
		RightAnswerAnim.SetTrigger("RightAnswerAnim");

		//TODO add score and reset timer
	}

	public void OnBAnswerClick(){
		AnswerBGO.GetComponent<Image>().color = Color.red;
		WrongQuestion();
	}

	public void OnCAnswerClick(){
		AnswerCGO.GetComponent<Image>().color = Color.red;
		WrongQuestion();
	}
	
	public void OnDAnswerClick(){
		AnswerDGO.GetComponent<Image>().color = Color.red;
		WrongQuestion();
	}

		

	public void WrongQuestion() {
		AnswerAGO.GetComponent<Image>().color = Color.green;
		RightAnswerAnim.SetTrigger("RightAnswerAnim");
		
		AnswerAGO.GetComponent<Button>().enabled = false;
		AnswerBGO.GetComponent<Button>().enabled = false;
		AnswerCGO.GetComponent<Button>().enabled = false;
		AnswerDGO.GetComponent<Button>().enabled = false;

		StartCoroutine(SetNewQuestion());

		//TODO show  end score and restart button


	}


	public bool CorrectAnswerSelected(int selectedAnswerID) {
	
		StartCoroutine(SetNewQuestion());
		
		return selectedAnswerID == currentQuestion.correctAnswerID;
	}
}
