﻿using UnityEngine;
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
}


public static class Scenes
{
	public const string MainScene = "terrainScene";
	public const string StartMenu = "ui_startMenu";
	public const string FirstScene = "ui_loadScreen";
	public const string LoadScene = "ui_loadSaves";

}


public class Game{
	public  const bool isPaused = false;

}
