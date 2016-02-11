using UnityEngine;
using System.Collections;

public class SharedScoreScript : MonoBehaviour {

	public static int TotalScore;
	public static int Score;

	void Start () {
		TotalScore = PlayerPrefs.GetInt("TotalScore");
		Score = 0;
	}

	void OnDestroy() {
		PlayerPrefs.SetInt("TotalScore",TotalScore);
	}

}
