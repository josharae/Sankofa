using UnityEngine;
using System.Collections;

public class SceneChanger_Build : MonoBehaviour {
	
	public void LoadSaves() {
		Build_Scenes.Saves();
	}
	
	public void StartGame() {
		Build_Scenes.Tutorial();
	}
	
	public void StartMenu() {
		Build_Scenes.MainMenu();
	}
	
	public void Inventory() {
		Build_Scenes.Inv();
	}
	
	public void Tutorial() {
		Build_Scenes.Tutorial ();
	}
	
	public void Oware() {
		Build_Scenes.Oware();
	}
	
	public void Giwa()
	{
		Build_Scenes.LoadGame();
	}

	public void Beginning()
	{
		Build_Scenes.LoadScreen();
	}
}
