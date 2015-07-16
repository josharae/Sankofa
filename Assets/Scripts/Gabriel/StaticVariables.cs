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
}


public static class Scenes
{
	public const string MainScene = "MainTerrainScene";
	public const string StartMenu = "ui_startMenu";
	public const string FirstScene = "ui_loadScreen";
	public const string LoadScene = "ui_loadSaves";
	public const string Inventory = "InventoryScene";
	public const string Tutorial = "tutorialScene";
	public const string Oware = "owareScene";
	public static void LoadGame(){
		Application.LoadLevel (Scenes.MainScene);
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


