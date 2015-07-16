using UnityEngine;
using System.Collections;

public class StaticVariables: MonoBehaviour {

}

public static class Missions
{
	public const string MarketPlace = "MarketPlace";
	public const string Tutorial = "Tutorial";
	public const string Game = "FinalGamePlay";
}


public static class Tags
{
	public const string Player = "Player";
	public const string Mission = "Mission";
	public const string Collectible = "Collectible";
	public const string MisteriousEgg = "MisteriousEgg";
	public const string PickupItem = "PickupItem";
	public const string Boulder = "Boulder";
	public const string WaterSpirit = "WaterSpirit";
	public const string Giwa = "Giwa";
	public const string Entrance = "Entrance";

}

public static class Scenes
{
	public const string MainScene = "MainTerrainScene";
	public const string StartMenu = "ui_startMenu";
	public const string FirstScene = "ui_loadScreen";
	public const string LoadScene = "ui_loadSaves";
	public const string Inventory = "InventoryScene";
	public const string TutorialScene = "tutorialScene";
	public const string OwareScene = "owareScene";
	public const string HutScene = "Hut_Interior";
	public const string SpiritIntro = "Phase1_village_spiritintro";
	public const string jungle = "newpeter";
	public static void LoadGame(){
		Application.LoadLevel (Scenes.MainScene);
	}
	public static void Hut()
	{
		Application.LoadLevel (Scenes.HutScene);
	}
	public static void SptIntro(){
		Application.LoadLevel (Scenes.SpiritIntro);
	}
	public static void MainMenu(){
		Application.LoadLevel (Scenes.StartMenu);
	}
	public static void Saves(){
		Application.LoadLevel (Scenes.LoadScene);
	}
	public static void Inv(){
		Application.LoadLevel (Scenes.Inventory);
	}
	public static void Tutorial(){
		Application.LoadLevel (Scenes.TutorialScene);
	}
	public static void Oware(){
		Application.LoadLevel (Scenes.OwareScene);
	}
	public static void Jungle(){
		Application.LoadLevel (Scenes.jungle);
	}
}

public static class Build_Scenes
{
	public const string MainScene = "Giwa_Build";
	public const string StartMenu = "StartMenu_Build";
	public const string FirstScene = "Beginning_Build";
	public const string LoadScene = "LoadSaves_Build";
	public const string Inventory = "Inventory_Build";
	public const string Tutorial = "tutorial_Build";
	public const string Oware = "Oware_Build";
}


public class Game{
	public  const bool isPaused = false;

}


