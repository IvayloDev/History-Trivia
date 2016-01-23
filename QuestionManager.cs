using UnityEngine;
using System.Collections;
using UnityEngine.UI;


public class QuestionManager : MonoBehaviour {

	[SerializeField]
	private TextAsset questionDataXMLFile;
	private QuestionData questionData;
	public static Question currentQuestion;
	public GameObject QuestionText,AnswerAGO,AnswerBGO,AnswerCGO,AnswerDGO;
	private Vector3 Button1Pos = new Vector3( 0, 40, 0);
	private Vector3 Button2Pos = new Vector3( 0, -110, 0);
	private Vector3 Button3Pos = new Vector3( 0, -260, 0);
	private Vector3 Button4Pos = new Vector3( 0, -410, 0);
	private Vector3 QuestionPos = new Vector3(-860,0,0);
	private Vector3 Audience1Pos = new Vector3( 245, 40, 0);
	private Vector3 Audience2Pos = new Vector3( 245, -110, 0);
	private Vector3 Audience3Pos = new Vector3( 245, -260, 0);
	private Vector3 Audience4Pos = new Vector3( 245, -410, 0);
	public Animator QuestionAnim,AnswersAnim,RightAnswerAnim;

	public Text TimerText;

	public int r,i;

	public Question tmp;

	public GameObject CorrectAnswerGO,Wrong1,Wrong2,Wrong3;

	public static bool Case1True,Case2True,Case3True,Case4True;

	public GameObject CharA,CharB,CharC,CharD;
	private int RandomButtPos, q;
	public float CountDownTime;

	public static bool NewQuestionBool;


	//public	System.Random random = new System.Random();

	void Update() {


		//Show only first digit on Timer Text
		TimerText.text = "" + CountDownTime.ToString("f0");

		//Countdown
		CountDownTime -= Time.deltaTime;


		
		//Keep Chars next to the relative question
		if(AnswerAGO.transform.localPosition == Button1Pos){
			CharA.GetComponentInChildren<Text>().text = "A:";
		}
		if(AnswerBGO.transform.localPosition == Button1Pos){
			CharB.GetComponentInChildren<Text>().text = "A:";
		}
		if(AnswerCGO.transform.localPosition == Button1Pos){
			CharC.GetComponentInChildren<Text>().text = "A:";
		}
		if(AnswerDGO.transform.localPosition == Button1Pos){
			CharD.GetComponentInChildren<Text>().text = "A:";
		}



		if(AnswerAGO.transform.localPosition == Button2Pos){
			CharA.GetComponentInChildren<Text>().text = "B:";
		}
		if(AnswerBGO.transform.localPosition == Button2Pos){
			CharB.GetComponentInChildren<Text>().text = "B:";
		}
		if(AnswerCGO.transform.localPosition == Button2Pos){
			CharC.GetComponentInChildren<Text>().text = "B:";
		}
		if(AnswerDGO.transform.localPosition == Button2Pos){
			CharD.GetComponentInChildren<Text>().text = "B:";
		}



		if(AnswerAGO.transform.localPosition == Button3Pos){
			CharA.GetComponentInChildren<Text>().text = "C:";
		}
		if(AnswerBGO.transform.localPosition == Button3Pos){
			CharB.GetComponentInChildren<Text>().text = "C:";
		}
		if(AnswerCGO.transform.localPosition == Button3Pos){
			CharC.GetComponentInChildren<Text>().text = "C:";
		}
		if(AnswerDGO.transform.localPosition == Button3Pos){
			CharD.GetComponentInChildren<Text>().text = "C:";
		}



		if(AnswerAGO.transform.localPosition == Button4Pos){
			CharA.GetComponentInChildren<Text>().text = "D:";
		}
		if(AnswerBGO.transform.localPosition == Button4Pos){
			CharB.GetComponentInChildren<Text>().text = "D:";
		}
		if(AnswerCGO.transform.localPosition == Button4Pos){
			CharC.GetComponentInChildren<Text>().text = "D:";
		}
		if(AnswerDGO.transform.localPosition == Button4Pos){
			CharD.GetComponentInChildren<Text>().text = "D:";
		}

	}



	void Start() {

		//get question data from xml file
		questionData = QuestionData.LoadFromText(questionDataXMLFile.text);

		CountDownTime = 20;
		
		//Get random question
		for (i = questionData.questions.Count - 1; i > 0; i--) {  // get the count of the array an shuffle all the elements   begin from end to start of the array 
			r = Random.Range(0, i);												   //	get a random number from 0 to array count
			tmp = questionData.questions[i];							   //	swap the random place (eg: 3) and assign it to tmp 
			questionData.questions[i] = questionData.questions[r];  // swap the i(current number) with tmp
			questionData.questions[r] = tmp;                            // swap the tmp with the value of i
		}

			currentQuestion = questionData.questions[r++];


		int RandomButtPos = Random.Range(1,5);
		//Random Button placement

		switch (RandomButtPos){
		case 1:
			AnswerAGO.transform.localPosition = Button1Pos;
			AnswerBGO.transform.localPosition = Button2Pos;
			AnswerCGO.transform.localPosition = Button3Pos;
			AnswerDGO.transform.localPosition = Button4Pos;


			//Percents from Audience choice
			CorrectAnswerGO.transform.localPosition = Audience1Pos;
			Wrong1.transform.localPosition = Audience2Pos;
			Wrong2.transform.localPosition = Audience3Pos;
			Wrong3.transform.localPosition = Audience4Pos;
			

			break;
		case 2:
			AnswerAGO.transform.localPosition = Button2Pos;
			AnswerBGO.transform.localPosition = Button1Pos;
			AnswerCGO.transform.localPosition = Button4Pos;
			AnswerDGO.transform.localPosition = Button3Pos;

			CorrectAnswerGO.transform.localPosition = Audience2Pos;
			Wrong1.transform.localPosition = Audience1Pos;
			Wrong2.transform.localPosition = Audience4Pos;
			Wrong3.transform.localPosition = Audience3Pos;

			break;
		case 3:

			AnswerAGO.transform.localPosition = Button3Pos;
			AnswerBGO.transform.localPosition = Button4Pos;
			AnswerCGO.transform.localPosition = Button2Pos;
			AnswerDGO.transform.localPosition = Button1Pos;
			
			CorrectAnswerGO.transform.localPosition = Audience3Pos;
			Wrong1.transform.localPosition = Audience4Pos;
			Wrong2.transform.localPosition = Audience2Pos;
			Wrong3.transform.localPosition = Audience1Pos;
			
			break;
		case 4:
			AnswerAGO.transform.localPosition = Button4Pos;
			AnswerBGO.transform.localPosition = Button3Pos;
			AnswerCGO.transform.localPosition = Button1Pos;
			AnswerDGO.transform.localPosition = Button2Pos;
			
			CorrectAnswerGO.transform.localPosition = Audience4Pos;
			Wrong1.transform.localPosition = Audience3Pos;
			Wrong2.transform.localPosition = Audience1Pos;
			Wrong3.transform.localPosition = Audience2Pos;


			break;
		}
		
		//Adding Values To Text
		QuestionText.GetComponent<Text>().text = currentQuestion.questionText;

		//setting question's possible answers 
		AnswerAGO.GetComponentInChildren<Text>().text = currentQuestion.answerA;
		AnswerBGO.GetComponentInChildren<Text>().text = currentQuestion.answerB;
		AnswerCGO.GetComponentInChildren<Text>().text = currentQuestion.answerC;
		AnswerDGO.GetComponentInChildren<Text>().text = currentQuestion.answerD;

	}


	// Call This For New Question
	IEnumerator SetNewQuestion () {

		CountDownTime = 20;
		
		if (r  >= questionData.questions.Count ) {
			for (i = questionData.questions.Count - 1; i > 0; i--) {  // get the count of the array an shuffle all the elements   begin from end to start of the array 
				r = Random.Range(0, i);												   //	get a random number from 0 to array count
				tmp = questionData.questions[i];							   //	swap the random place (eg: 3) and assign it to tmp 
				questionData.questions[i] = questionData.questions[r];  // swap the i(current number) with tmp
				questionData.questions[r] = tmp;                            // swap the tmp with the value of i
			}
		}
			currentQuestion = questionData.questions[r++];
		
		
		RandomButtPos = Random.Range(1,5);

		yield return new WaitForSeconds(1f);



		//transition animations
		QuestionAnim.SetBool("NewQuestionAnimation",true);
		AnswersAnim.SetBool("NewAnswerAnimation",true);

		//reset color
		AnswerAGO.GetComponent<Image>().color = Color.white;
		AnswerBGO.GetComponent<Image>().color = Color.white;
		AnswerCGO.GetComponent<Image>().color = Color.white;
		AnswerDGO.GetComponent<Image>().color = Color.white;

		

		AnswerAGO.GetComponent<Button>().enabled = true;
		AnswerBGO.GetComponent<Button>().enabled = true;
		AnswerCGO.GetComponent<Button>().enabled = true;
		AnswerDGO.GetComponent<Button>().enabled = true;

		yield return new WaitForSeconds(0.1f);

		//disable audience
		CorrectAnswerGO.GetComponent<Text>().text = " ";
		Wrong1.GetComponent<Text>().text = " ";
		Wrong2.GetComponent<Text>().text = " ";
		Wrong3.GetComponent<Text>().text =  " ";

		//make active
		AnswerAGO.SetActive(true);
		AnswerBGO.SetActive(true);
		AnswerCGO.SetActive(true);
		AnswerDGO.SetActive(true);
		
		//make active
		CharA.SetActive(true);
		CharB.SetActive(true);
		CharC.SetActive(true);
		CharD.SetActive(true);

		switch (RandomButtPos){
		case 1:
			AnswerAGO.transform.localPosition = Button1Pos;
			AnswerBGO.transform.localPosition = Button2Pos;
			AnswerCGO.transform.localPosition = Button3Pos;
			AnswerDGO.transform.localPosition = Button4Pos;
			
			CorrectAnswerGO.transform.localPosition = Audience1Pos;
			Wrong1.transform.localPosition = Audience2Pos;
			Wrong2.transform.localPosition = Audience3Pos;
			Wrong3.transform.localPosition = Audience4Pos;
			
			
			break;
		case 2:
			AnswerAGO.transform.localPosition = Button2Pos;
			AnswerBGO.transform.localPosition = Button1Pos;
			AnswerCGO.transform.localPosition = Button4Pos;
			AnswerDGO.transform.localPosition = Button3Pos;
			
			CorrectAnswerGO.transform.localPosition = Audience2Pos;
			Wrong1.transform.localPosition = Audience1Pos;
			Wrong2.transform.localPosition = Audience4Pos;
			Wrong3.transform.localPosition = Audience3Pos;
			
			
			break;
		case 3:
			AnswerAGO.transform.localPosition = Button3Pos;
			AnswerBGO.transform.localPosition = Button4Pos;
			AnswerCGO.transform.localPosition = Button2Pos;
			AnswerDGO.transform.localPosition = Button1Pos;
			
			CorrectAnswerGO.transform.localPosition = Audience3Pos;
			Wrong1.transform.localPosition = Audience4Pos;
			Wrong2.transform.localPosition = Audience2Pos;
			Wrong3.transform.localPosition = Audience1Pos;
			
			
			break;
		case 4:
			AnswerAGO.transform.localPosition = Button4Pos;
			AnswerBGO.transform.localPosition = Button3Pos;
			AnswerCGO.transform.localPosition = Button1Pos;
			AnswerDGO.transform.localPosition = Button2Pos;
			
			CorrectAnswerGO.transform.localPosition = Audience4Pos;
			Wrong1.transform.localPosition = Audience3Pos;
			Wrong2.transform.localPosition = Audience1Pos;
			Wrong3.transform.localPosition = Audience2Pos;
			
			
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

		//Add score and trigger animation
		TopPanelManager.Score += 10 + (int)CountDownTime;
		CorrectAnswerSelected(0);
		RightAnswerAnim.SetTrigger("RightAnswerAnim");

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
		//Show right answer and
		AnswerAGO.GetComponent<Image>().color = Color.green;
		RightAnswerAnim.SetTrigger("RightAnswerAnim");
		StartCoroutine(SetNewQuestion());

		//disable buttons so they cannot be pressed while transitioning to new question
		AnswerAGO.GetComponent<Button>().enabled = false;
		AnswerBGO.GetComponent<Button>().enabled = false;
		AnswerCGO.GetComponent<Button>().enabled = false;
		AnswerDGO.GetComponent<Button>().enabled = false;


		//TODO show  end score and restart button


	}


	public bool CorrectAnswerSelected(int selectedAnswerID) {
	
		//New question
		StartCoroutine(SetNewQuestion());
		
		return selectedAnswerID == currentQuestion.correctAnswerID;
	}
}
