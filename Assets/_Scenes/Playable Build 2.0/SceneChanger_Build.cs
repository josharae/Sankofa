using UnityEngine;
using System.Collections;

public class SceneChanger_Build : MonoBehaviour {
	
	public void LoadSaves() {
		Build_Scenes.showLoading();
		Build_Scenes.Saves();
	}
	
	public void StartGame() {
		Build_Scenes.showLoading();
		Build_Scenes.Tutorial();
	}
	
	public void StartMenu() {
		Build_Scenes.showLoading();
		Build_Scenes.MainMenu();
	}
	
	public void Inventory() {
		Build_Scenes.showLoading();
		Build_Scenes.Inv();
	}
	
	public void Tutorial() {
		Build_Scenes.showLoading();
		Build_Scenes.Tutorial ();
	}

	public void mainMenu() {
		Build_Scenes.showLoading();
		Build_Scenes.MainMenu ();
	}
	
	public void Oware() {
		Build_Scenes.showLoading();
		Build_Scenes.Oware();
	}
	
	public void Giwa()
	{
		Build_Scenes.showLoading();
		Build_Scenes.LoadGame();
	}

	public void Beginning()
	{
		Build_Scenes.showLoading();
		Build_Scenes.LoadScreen();
	}
}
