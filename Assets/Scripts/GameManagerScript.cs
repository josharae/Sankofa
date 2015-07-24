using UnityEngine;
using System.Collections;
using UnityStandardAssets.Characters.FirstPerson;
public class GameManagerScript : MonoBehaviour {

	bool isPaused = false, showingInventory = false;
	GameObject[] InGameButtons;
	public GameObject PausePanel, InventoryPanel;
	// Use this for initialization
	void Start () {
		InGameButtons = GameObject.FindGameObjectsWithTag ("InGameButtons");
	}
	
	// Update is called once per frame
	void Update () {
		if(Input.GetKeyDown(KeyCode.P) || Input.GetKeyDown(KeyCode.Escape) && !showingInventory){
			pauseGame();
		}
		if (Input.GetKeyDown (KeyCode.I) && !isPaused)
			showInventory ();
	}
	public void showInventory(){
		showingInventory = !showingInventory;
		if (isPaused)
			pauseGame ();
		InventoryPanel.SetActive (showingInventory);
		Time.timeScale = showingInventory ? 0 : 1;
	}


	public void pauseGame(){
		isPaused = !isPaused;
			foreach (GameObject button in InGameButtons)
				button.SetActive (!isPaused);
		PausePanel.SetActive (isPaused);
		Time.timeScale = isPaused ? 0 : 1;
	}

	public void quitGame(){
		Application.Quit ();
	}

}
