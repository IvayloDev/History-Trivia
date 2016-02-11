using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class TopPanelManager : MonoBehaviour {

	[SerializeField]
	private Text ScoreText,TopicText;
	public static int rightAnsw;
	public static string Topic;

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
