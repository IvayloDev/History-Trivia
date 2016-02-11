using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class TopPanelManager : MonoBehaviour {

	[SerializeField]
	private Text ScoreText,TopicText;

	public static string Topic;
	public static int rightAnsw = 0;

	void Start() {
		rightAnsw = 0;
	}

	// Update is called once per frame
	void Update () {

		TopicText.text = Topic;

		//Shows how many right answers you have answered in a row
		ScoreText.text = "" + rightAnsw;

	}
}
