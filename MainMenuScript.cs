using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class MainMenuScript : MonoBehaviour {

	public Text TotalScoreText,TotalRightAnswers;
	public GameObject WW1n2,WorldHistory;
	public GameObject WW1n2Butt,WorldHistoryButt;



	void Start() {
		
		WW1n2.SetActive(true);
		WorldHistory.SetActive(true);

		WW1n2Butt.GetComponent<Button>().enabled = false;
		WorldHistoryButt.GetComponent<Button>().enabled = false;
	}


	// Update is called once per frame
	void Update () {
	
		if( Input.GetKeyDown(KeyCode.Escape) && Application.loadedLevelName == "MainMenu"){
			Application.Quit();
		}

		TotalRightAnswers.text = "Верни отговори :" + SharedScoreScript.RIGHTANSWERS;
		TotalScoreText.text = "Точки : " + SharedScoreScript.TotalScore;
		
		


		if(SharedScoreScript.TotalScore >= 1000) {
		    WorldHistory.SetActive(false);
			WorldHistoryButt.GetComponent<Button>().enabled = true;
		}
		if(SharedScoreScript.TotalScore >= 2000) {
			WW1n2.SetActive(false);
			WW1n2Butt.GetComponent<Button>().enabled = true;
		}


	}
}
