using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;

public class Inventory : MonoBehaviour
{

	public List<GameObject> Slots = new List<GameObject> ();
	public List<Item> Items = new List<Item> ();
	
	public GameObject slots;
	public GameObject tooltip;
	
	public GameObject draggedItemGameObject;
	public bool draggingItem = false;
	public Item draggedItem;
	public int indexOfDraggedItem;
	
	ItemDatabase database;
	
	int x = -110;
	int y = 110;
	
	// Use this for initialization
	
	void Update ()
	{
		if (draggingItem) {
			Vector3 pos = (Input.mousePosition - GameObject.FindGameObjectWithTag ("Canvas").GetComponent<RectTransform> ().localPosition);
			draggedItemGameObject.GetComponent<RectTransform> ().localPosition = new Vector3 (pos.x + 15, pos.y - 15, pos.z);
		}
	}


	public void showTooltip (Vector3 toolPosition, Item item)
	{
		tooltip.SetActive (true);
		tooltip.GetComponent<RectTransform> ().localPosition = new Vector3 (toolPosition.x + 360, toolPosition.y, toolPosition.z);
	}
	
	
	public void ShowDraggedItem (Item item, int slotNumber)
	{
		indexOfDraggedItem = slotNumber;
		closeTooltip ();
		draggedItemGameObject.SetActive (true);
		draggedItem = item;
		draggingItem = true;
		draggedItemGameObject.GetComponent<Image> ().sprite = item.item_icon;
		
		
	}
	
	
	public void closeDraggedItem ()
	{
		draggingItem = false;
		draggedItemGameObject.SetActive (false);
	}

	public void closeTooltip ()
	{
		tooltip.SetActive (false);
	}


	void Start ()
	{

		int slot_amount = 0;

		database = GameObject.FindGameObjectWithTag ("ItemDatabase").GetComponent<ItemDatabase> ();

		for (int i = 1; i < 6; i++) {
			for (int k = 1; k < 6; k++) {
				GameObject slot = (GameObject)Instantiate (slots);
				slot.GetComponent<SlotScript> ().slot_number = slot_amount;
				Slots.Add (slot);
				Items.Add (new Item ());
				slot.transform.parent = this.gameObject.transform;
				slot.name = "Slot" + i + "." + k; 
				slot.GetComponent<RectTransform> ().localPosition = new Vector3 (x, y, 0);
				x = x + 55;
				if (k == 5) {
					x = -110;
					y = y - 55;
				}
				slot_amount++;
			}
		}


		addItem (0);
		addItem (1);
		addItem (2);
		addItem (3);
		Debug.Log (Items [0].item_name);
		Debug.Log (Items [1].item_name);
		Debug.Log (Items [2].item_name);
		Debug.Log (Items [3].item_name);
	
	}

	void addItem (int id)
	{
		for (int i = 0; i < database.items.Count; i++) {
			if (database.items [i].item_id == id) {
				Item item = database.items [i];
				addItemAtEmptySlot (item);
				break;
			}
		}
	}


	void addItemAtEmptySlot (Item item)
	{
		for (int i = 0; i < Items.Count; i++) {
			if (Items [i].item_name == null) {
				Items [i] = item;
				break;
			}
		}
	}

	



}
