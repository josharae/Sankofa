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
	public const string GameManager = "GameManager";
	public const string Entrance = "Entrance";
	public const string StaticObject = "staticObject";
	public const string onini = "onini";
	public const string waypoint = "waypoint";
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
	public const string market = "Marketplace_Placeholder_Max";
	public static void LoadGame(){
		Application.LoadLevel (Scenes.MainScene);
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
	public static void LoadJungle(){
		Application.LoadLevel (Scenes.jungle);
	}
	public static void LoadMarket(){
		Application.LoadLevel (Scenes.market);
	}
	public static void LoadHut(){
		Application.LoadLevel (Scenes.HutScene);
	}
}

public static class Build_Scenes
{
	public const string MainScene = "MainTerrain_Build";
	public const string CastleScene = "Castle_Build";
	public const string StartMenu = "StartMenu_Build";
	public const string FirstScene = "LoadScreen_Build";
	public const string LoadScene = "LoadSaves_Build";
	public const string Inventory = "Inventory_Build";
	public const string tutorial = "Tutorial_Build";
	public const string OwareScene = "Oware_Build";
	public const string market = "Market_Build";
	public const string village = "Village_Build";
	public const string hut = "Hut_Build";
	public const string jungle = "MainTerrain_Build";
	public const string onini = "onini_Build";
	public static void LoadGame(){
		Application.LoadLevel (Build_Scenes.MainScene);
	}
	public static void MainMenu(){
		Application.LoadLevel (Build_Scenes.StartMenu);
	}
	public static void Saves(){
		Application.LoadLevel (Build_Scenes.LoadScene);
	}
	public static void Inv(){
		Application.LoadLevel (Build_Scenes.Inventory);
	}
	public static void Tutorial(){
		Application.LoadLevel (Build_Scenes.tutorial);
	}
	public static void Oware(){
		Application.LoadLevel (Build_Scenes.OwareScene);
	}
	public static void LoadJungle(){
		Application.LoadLevel (Build_Scenes.jungle);
	}
	public static void LoadMarket(){
		Application.LoadLevel (Build_Scenes.market);
	}
	public static void LoadHut(){
		Application.LoadLevel (Build_Scenes.hut);
	} 
	public static void LoadVillage(){
		Application.LoadLevel (Build_Scenes.village);
	}
	public static void LoadScreen(){
		Application.LoadLevel (Build_Scenes.FirstScene);
	}
	public static void LoadCastle(){
		Application.LoadLevel (Build_Scenes.CastleScene);
	}
	public static void LoadOnini(){
		Application.LoadLevel (Build_Scenes.onini);
	}
	public static void showLoading(){
		GameObject staticObj = GameObject.FindWithTag (Tags.StaticObject);
		if(staticObj != null)
			staticObj.GetComponent<GlobalVariablesScript>().loadingNewSCene();
	}
}


public class ItemNames{
	public const string Marble = "Marble";
	public const string GameManager = "GameManager";
	public const string Mask = "Mask";
	public const string Tusk = "Tusk";

}


