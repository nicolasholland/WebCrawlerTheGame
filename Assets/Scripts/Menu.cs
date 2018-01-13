using UnityEngine;
using System.Collections;
using System.Collections.Generic;


public class Menu : MonoBehaviour {
	string webpageInput;

	void Start() {
		webpageInput = "https://en.wikipedia.org/wiki/Frog";
	}

	void OnGUI () {
		// When the game is started, the crawler loads its contents from the internet.
		if (GUI.Button (new Rect (Screen.width / 2.5f, Screen.height / 3, Screen.width / 5, Screen.height / 10), "Load Game")) {
			Application.LoadLevel(1);
		}

		// End the game
		if (GUI.Button (new Rect (Screen.width / 2.5f, Screen.height / 2, Screen.width / 5, Screen.height / 10), "Exit Game")) {
			Application.Quit();
		}

		//webpageInput = GameObject.Find ("LevelMaker").GetComponent<WebCrawler> ().webpage;

		webpageInput = GUI.TextField (new Rect (Screen.width / 2.5f, Screen.height / 5, Screen.width / 3, Screen.height / 10), webpageInput, 50);
		GameObject.Find ("LevelMaker").GetComponent<WebCrawler> ().webpage = webpageInput;
	}

}
