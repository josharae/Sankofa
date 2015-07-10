using UnityEngine;
using System.Collections;

public class ui_changeScene : MonoBehaviour {

	public void LoadGameScene() {
		Application.LoadLevel (Scenes.LoadScene);
	}

	
	public void StartGame() {
		Application.LoadLevel (Scenes.TutorialScene);
	}

	public void MainMenu() {
		Application.LoadLevel (Scenes.StartMenu);
	}

	public void Oware() {
		Application.LoadLevel (Scenes.OwareScene);
	}

	public void Inventory()	{
		Application.LoadLevel (Scenes.Inventory);
	}

	public void Giwa() { 
		Application.LoadLevel (Scenes.MainScene);
	}
}
