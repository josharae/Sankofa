using UnityEngine.UI;
using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class InventoryScript : MonoBehaviour {
	List<GameObject> Inventory = new List<GameObject>();
	GameObject GameManager;
	// Use this for initialization
	void Start () {
		GameManager = GameObject.Find ("GameManager");
	}
	
	// Update is called once per frame
	public void AddItem(GameObject newItem){
		Inventory.Add (newItem);
		Destroy (newItem);
		if (newItem.name == ItemNames.Mask) {
			GameManager.GetComponent<GameManagerScript> ().updateCollectibleCount(newItem.transform.position, false);
		} else if (newItem.name == ItemNames.Marble) {
			GameManager.GetComponent<GameManagerScript> ().updateCollectibleCount(newItem.transform.position);
		} else
			Inventory.Add (newItem);

	}
}
