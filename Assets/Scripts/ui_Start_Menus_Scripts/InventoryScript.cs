using UnityEngine.UI;
using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class InventoryScript : MonoBehaviour {
	List<GameObject> Inventory = new List<GameObject>();
	GameObject GameManager;
	public Text itemList;
	private int marbles = 0, masks = 0;
	// Use this for initialization
	void Start () {
		GameManager = GameObject.Find ("GameManager");
	}

	void setPanelText(){
		itemList.text = "";
		itemList.alignment = TextAnchor.MiddleLeft;
		for (int i =0; i< Inventory.Count; i++) {
			itemList.text += "<color=#00ff00ff> - " + Inventory [i].name + "</color>" + '\n';			
		}
	}
	
	// Update is called once per frame
	public void AddItem(GameObject newItem){
		Inventory.Add (newItem);
		Destroy (newItem);
		if (newItem.name == ItemNames.Mask) {
			masks += 1;
		} else if (newItem.name == ItemNames.Marble) {
			marbles += 1;
		} else
			Inventory.Add (newItem);
		GameManager.GetComponent<GameManagerScript> ().setItemsText (marbles, masks);
	}
}
