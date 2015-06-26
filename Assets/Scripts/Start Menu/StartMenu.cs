using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class StartMenu : MonoBehaviour {
	
	public bool hasSaveFiles;
	public bool showSaves;
	public string newGameName;
	public Rect megaWindow;
	void Start () {
		megaWindow = new Rect (1, 1, 1100, 635);
		hasSaveFiles = true;
		//hasSaveFiles = checkSaveFiles(); >> IMPLEMENT LATER
	}


	void Update () {
	
	}

	void OnGUI()
	{

		GUI.Window (0, megaWindow, mWinFunc, "Sankofa");
	}

	void mWinFunc(int id)
	{
		string newName = "";
		if (!showSaves) {
			GUI.DrawTexture (new Rect (400, 300, 300, 120), Resources.Load<Texture2D> ("Buttons-Start Menu/New_Game"));
			if (GUI.Button (new Rect (400, 300, 300, 120), "")) {
				newName = enterName (newName);
			}
			if (hasSaveFiles) {
				GUI.DrawTexture (new Rect (400, 450, 300, 120), Resources.Load<Texture2D> ("Buttons-Start Menu/Enabled_Load"));
				if (GUI.Button (new Rect (400, 450, 300, 120), "")) {
					showSaves = true;
				}
			} else {
				GUI.DrawTexture (new Rect (400, 450, 300, 120), Resources.Load<Texture2D> ("Buttons-Start Menu/Disabled_Load"));
			}
		}//end (!showSaves)
		else if(showSaves){ //Save File Screen

			Rect buttons = new Rect(100, 50, 250, 150);
			Rect characterInfo = new Rect(450, 50, 600, 150);
			Rect owareDisplay = new Rect(characterInfo.x + 520, characterInfo.y + 110, 47, 20);
			Rect icons1 = new Rect(characterInfo.x + 30, characterInfo.y + 70, 64, 64);
			Rect icons3 = new Rect(icons1.x + 250, icons1.y, icons1.width, icons1.height);
			Rect icons2 = new Rect(icons1.x + 125, icons1.y - 50, icons1.width, icons1.height);
			Rect icons4 = new Rect(icons2.x + 250, icons2.y, icons2.width, icons2.height);

			int owarePieces1 = 24, owarePieces2 = 12, owarePieces3 = 0;
			string pieces1 = owarePieces1 + " of 24", pieces2 = owarePieces2 + " of 24", pieces3 = owarePieces3 + " of 24";

			if (GUI.Button (buttons, "Save File 1")) {
				Debug.Log ("Got a click");
			}
			GUI.Box(characterInfo, "Character Information goes here");
			GUI.Label(owareDisplay, pieces1);
			GUI.DrawTexture(icons1, Resources.Load<Texture2D> ("Buttons-Start Menu/Achievement_Icon1"));
			GUI.DrawTexture(icons2, Resources.Load<Texture2D> ("Buttons-Start Menu/Achievement_Icon1"));
			GUI.DrawTexture(icons3, Resources.Load<Texture2D> ("Buttons-Start Menu/Achievement_Icon1"));
			GUI.DrawTexture(icons4, Resources.Load<Texture2D> ("Buttons-Start Menu/Achievement_Icon1"));

			if (GUI.Button (new Rect(buttons.x, buttons.y + 162, buttons.width, buttons.height), "Save File 2")) {
				Debug.Log ("Got a click");
			}
			GUI.Box(new Rect(characterInfo.x, characterInfo.y + 162, characterInfo.width, characterInfo.height), "Character Information goes here");
			GUI.Label(new Rect(owareDisplay.x, owareDisplay.y + 162, owareDisplay.width, owareDisplay.height), pieces2);
			GUI.DrawTexture(new Rect(icons1.x,icons1.y + 162, icons1.width, icons1.height), Resources.Load<Texture2D> ("Buttons-Start Menu/Achievement_Icon1"));
			GUI.DrawTexture(new Rect(icons2.x,icons1.y + 162, icons1.width, icons1.height), Resources.Load<Texture2D> ("Buttons-Start Menu/Achievement_Icon1"));
			GUI.DrawTexture(new Rect(icons3.x,icons1.y + 162, icons1.width, icons1.height), Resources.Load<Texture2D> ("Buttons-Start Menu/Achievement_Icon1"));
			GUI.DrawTexture(new Rect(icons4.x,icons1.y + 162, icons1.width, icons1.height), Resources.Load<Texture2D> ("Buttons-Start Menu/Achievement_Icon1"));

			if (GUI.Button (new Rect(buttons.x, buttons.y + 325, buttons.width, buttons.height), "Save File 3")) {
				Debug.Log ("Got a click");
			}
			GUI.Box(new Rect(characterInfo.x, characterInfo.y + 325, characterInfo.width, characterInfo.height), "Character Information goes here");
			GUI.Label(new Rect(owareDisplay.x, owareDisplay.y + 325, owareDisplay.width, owareDisplay.height), pieces3);
			GUI.DrawTexture(new Rect(icons1.x,icons1.y + 325, icons1.width, icons1.height), Resources.Load<Texture2D> ("Buttons-Start Menu/Achievement_Icon1"));
			GUI.DrawTexture(new Rect(icons2.x,icons1.y + 325, icons1.width, icons1.height), Resources.Load<Texture2D> ("Buttons-Start Menu/Achievement_Icon1"));
			GUI.DrawTexture(new Rect(icons3.x,icons1.y + 325, icons1.width, icons1.height), Resources.Load<Texture2D> ("Buttons-Start Menu/Achievement_Icon1"));
			GUI.DrawTexture(new Rect(icons4.x,icons1.y + 325, icons1.width, icons1.height), Resources.Load<Texture2D> ("Buttons-Start Menu/Achievement_Icon1"));

			if(GUI.Button(new Rect(450,550,200,50), "Back to Title Screen")){
				showSaves = false;
			}
		}

	}//end mWinFunc()
	string enterName(string name)
	{
		GUI.TextField (new Rect (450, 200, 200, 20), name, 16);
		Debug.Log (name);
		return name;
	}
}