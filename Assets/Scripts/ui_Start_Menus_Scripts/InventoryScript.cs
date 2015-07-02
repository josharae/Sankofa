using UnityEngine.UI;
using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class InventoryScript : MonoBehaviour {
	List<GameObject> Inventory = new List<GameObject>();
	GameObject Panel;
	public Text itemList;
	bool isShowing = true;
	// Use this for initialization
	void Start () {
		Panel = GameObject.Find ("Inventory");
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
		//Destroy (newItem);
		newItem.SetActive (false);
		setPanelText ();
	}

	public void ShowInventory(){
		isShowing = !isShowing;
		Panel.gameObject.SetActive (isShowing);
	}
}
