using UnityEngine;
using System.Collections;

public class SharedScoreScript : MonoBehaviour {

	public static int TotalScore;
	public static int Score;
	public static int RIGHTANSWERS;

	void Start () {
		TotalScore = PlayerPrefs.GetInt("TotalScore");
		RIGHTANSWERS = PlayerPrefs.GetInt("RightAnswers");

		Score = 0;
	}

	void OnDestroy() {
		PlayerPrefs.SetInt("TotalScore",TotalScore);
		PlayerPrefs.SetInt("RightAnswers", RIGHTANSWERS);

	}

}
