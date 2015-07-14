using UnityEngine;
using System.Collections;

public class SceneChanger_Build : MonoBehaviour {
	
	public void LoadGameScene() {
		Application.LoadLevel (Build_Scenes.LoadScene);
	}
	
	public void StartGame() {
		Application.LoadLevel (Build_Scenes.MainScene);
	}
	
	public void MainMenu() {
		Application.LoadLevel (Build_Scenes.StartMenu);
	}
	
	public void Inventory() {
		Application.LoadLevel (Build_Scenes.Inventory);
	}
	
	public void Tutorial() {
		Application.LoadLevel (Build_Scenes.Tutorial);
	}
	
	public void Oware() {
		Application.LoadLevel (Build_Scenes.Oware);
	}
	
	public void Giwa()
	{
		Application.LoadLevel (Build_Scenes.MainScene);
	}
}
