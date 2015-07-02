using UnityEngine;
using System.Collections;

public class ui_changeScene : MonoBehaviour {

	public void LoadGameScene() {
		Application.LoadLevel (Scenes.LoadScene);
	}

	
	public void StartGame() {
		Application.LoadLevel (Scenes.MainScene);
	}

	public void MainMenu() {
		Application.LoadLevel (Scenes.StartMenu);
	}
}
