using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class TopPanelManager : MonoBehaviour {

	[SerializeField]
	private Text ScoreText,TopicText;

	public static int Score;

	// Update is called once per frame
	void Update () {
		//Topic and Score Text
		//TopicText.text = "" + !!TOPIC!!;
		ScoreText.text = "Точки:"+ "\n" + Score;

	}
}
