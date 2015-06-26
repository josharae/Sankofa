#define TESTING

using UnityEngine;
using System.Collections;

public class InventoryWindow : MonoBehaviour {

	//1100 for width fits my screen
	//635 for height fits my screen 
	public int slotsX, slotsY;
	public Rect megaWindow;
	public bool showingInventory;
	private GUI.WindowFunction funct;

	void Start () {
#if (TESTING)
		showingInventory = true;
#endif
		megaWindow = new Rect(15, 15, 1100, 615);
	}

	void Update () {
		if (Input.GetButtonDown ("Inventory")) {
			showingInventory = !showingInventory;
		}
	}

	void OnGUI()
	{
		if (showingInventory) {
			drawWindow ();
		}
	}

	void drawWindow()
	{ 
		megaWindow = GUI.Window (0, megaWindow, winFunct, "Hello World!");
	}

	void winFunct(int id)
	{
		for (int y = 0; y < slotsY; y++) {
			for(int x = 0; x < slotsX; x++)
			{
		GUI.Box(new Rect((megaWindow.x + 15) + x*271, (megaWindow.y + 15) + y*271, 256, 256), "Foo");
			}
		}
	}
}
