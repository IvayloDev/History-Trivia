using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class MainScreenButtons : MonoBehaviour {

	public GameObject[] Category;
	public GameObject PlayBtn,ExitBtn;
	public static int CategoryInt;

	void Start(){
		foreach (var Cat in Category) {
			Cat.SetActive(false);
			PlayBtn.SetActive(true);
			ExitBtn.SetActive(true);
		}
	}

	public void OnPlayClick() {

		//Show Categories
		foreach (var Cat in Category) {
			Cat.SetActive(true);
			//Disable Play Buttton
			PlayBtn.SetActive(false);
			ExitBtn.SetActive(false);
		}

	}

	public void OnExitClick() {
		Application.Quit();
	}


	public void OnCategory1Click() {
		Application.LoadLevel("Game");
		CategoryInt = 1;
		TopPanelManager.Topic = "Българска История";
	}
	
	public void OnCategory2Click() {
		Application.LoadLevel("Game");
		CategoryInt = 2;
		TopPanelManager.Topic = "Световна История";
	}
	
	public void OnCategory3Click() {
		Application.LoadLevel("Game");
		CategoryInt = 3;
		TopPanelManager.Topic = "I и II Световна война";
	}


}
