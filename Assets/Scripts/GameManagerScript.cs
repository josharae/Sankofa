using UnityEngine;
using System.Collections;
using UnityStandardAssets.Characters.FirstPerson;
using UnityEngine.UI;

public class GameManagerScript : MonoBehaviour {

	bool isPaused = false, showingInventory = false;
	public Text marbleText, maskText;
	int marbles =0, masks= 0;
	GameObject[] InGameButtons;
	public GameObject PausePanel, InventoryPanel;
	// Use this for initialization
	void Start () {
		InGameButtons = GameObject.FindGameObjectsWithTag ("InGameButtons");

	}
	
	// Update is called once per frame
	void Update () {
		if(Input.GetKeyDown(KeyCode.P) && !showingInventory){
			pauseGame();
		}
		if (Input.GetKeyDown(KeyCode.Escape)){
			if(showingInventory)
				showInventory ();
			else
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

	public void updateCollectibleCount(bool isMarble = true){
		if (isMarble)
			marbles += 1;
		else
			masks += 1;

		setItemsText ();
	}

	private void setItemsText(){
		marbleText.text = "Marbles: " + marbles + "/20";
		maskText.text = "Masks x " + masks;
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
