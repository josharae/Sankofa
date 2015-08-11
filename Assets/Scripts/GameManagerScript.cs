using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;

public class GameManagerScript : MonoBehaviour {

	bool isPaused = false, showingInventory = false;
	Dictionary<int, List<Vector3>> collectedItems = new Dictionary<int, List<Vector3>>();
	Dictionary<int, int> itemsToCollect = new Dictionary<int, int>();
	public Text marbleText, maskText;
	int marbles =0, masks= 0, currentLevel;
	GameObject[] InGameButtons;
	public GameObject PausePanel, InventoryPanel;
	// Use this for initialization
	void Start () {
		InGameButtons = GameObject.FindGameObjectsWithTag ("InGameButtons");

	}

	void OnLevelWasLoaded(int level) {
		currentLevel = level;
		checkCollectedItems ();
	}

	void checkCollectedItems(){
		GameObject[] collectibles = GameObject.FindGameObjectsWithTag (Tags.Collectible);
		if (collectedItems.ContainsKey (currentLevel) && itemsToCollect.ContainsKey(currentLevel)){
		    if(itemsToCollect[currentLevel] < collectibles.Length) {
				Debug.Log(collectibles.Length);
				Debug.Log(collectedItems[currentLevel].Count);
			for (int i =0; i<collectibles.Length; i++) {
				for (int x =0; x<collectedItems[currentLevel].Count; x++) {
					Debug.Log(collectibles [i].transform.position + "  " + collectedItems [currentLevel] [x]);
					if (Vector3.Distance (collectibles [i].transform.position, collectedItems [currentLevel] [x]) < 5) {
						collectibles [i].SetActive (false);
					}
				}
			}
		}
		} else
			itemsToCollect.Add (currentLevel, collectibles.Length);
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

	public void updateCollectibleCount(Vector3 itemPosition,bool isMarble = true){
		if (isMarble)
			marbles += 1;
		else
			masks += 1;

		if (collectedItems.ContainsKey (currentLevel))
			collectedItems [currentLevel].Add (itemPosition);
		else{
			List<Vector3> newList = new List<Vector3>();
			newList.Add(itemPosition);
			collectedItems.Add (currentLevel,newList);
		}
		itemsToCollect [currentLevel] -= 1;
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
