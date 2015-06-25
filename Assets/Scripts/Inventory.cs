using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Inventory : MonoBehaviour {
	public int slotsX, slotsY;
	public GUISkin skin;
	public GUIStyle myStyle;
	public List<Item> inventory = new List<Item> ();
	public List<Item> slots = new List<Item> ();
	private ItemDatabase database;
	private bool showInventory;
	private bool showTooltip;
	private string tooltip;

	private bool draggingItem;
	private Item draggedItem;
	private int prevIndex;

	void Start () {
		for(int i = 0; i <(slotsX*slotsY);i++)
		{
			slots.Add(new Item());
			inventory.Add(new Item());
		}

//		myStyle = skin.GetStyle ("Slot");
		database = GameObject.FindGameObjectWithTag ("Item Database").GetComponent<ItemDatabase> ();
		//shoves all items in database into inventory >> REMOVE LATER
		for (int i = 0; i < database.items.Count; i++) {
			inventory[i] = database.items[i];
		}
//		inventory [0] = database.items [0];
//		inventory [1] = database.items [1];
//		inventory [2] = database.items [2];
	}

	void Update()
	{
		if (Input.GetButtonDown ("Inventory")) {
			showInventory = !showInventory;
		}
	}

	void OnGUI()
	{
		tooltip = "";
		GUI.skin = skin;
		if (showInventory)
		{
			DrawInventory ();
			if (showTooltip)
				GUI.Box (new Rect (Event.current.mousePosition.x, Event.current.mousePosition.y, 300, 100), tooltip, skin.GetStyle ("tooltip"));
		}
		if (draggingItem) {
			GUI.DrawTexture(new Rect (Event.current.mousePosition.x, Event.current.mousePosition.y, 100, 100), draggedItem.itemIcon);
		}

	}

	void DrawInventory()
	{
		Event e = Event.current;
		int i = 0;
		for(int y = 0;y < slotsY; y++)
		{
			for(int x = 0; x < slotsX; x++)
			{
				Rect slotRect = new Rect(x*110, y*110, 100, 100);
				GUI.Box(slotRect, "", skin.GetStyle ("Slot"));
				slots[i] = inventory[i];
				Item item = slots[i];
				if(slots[i].itemName != null)
				{
					GUI.DrawTexture(slotRect,slots[i].itemIcon);
					if(slotRect.Contains(e.mousePosition))
					{
						if(!draggingItem)
							tooltip = CreateTooltip(slots[i]);
						if(e.isMouse && e.type == EventType.mouseDown && e.button == 1)
						{
							if(item.itemType == Item.ItemType.Consumable)
							{
								Debug.Log("Used Consumable");
							}
						}
						showTooltip = true;
						if(e.button == 0 && e.type == EventType.mouseDrag && !draggingItem)
						{
							draggingItem = true;
							prevIndex = i;
							draggedItem = slots[i];
							inventory [i] = new Item();
						}
						if(e.type == EventType.mouseUp && draggingItem)
						{
							inventory[prevIndex] = inventory[i];
							inventory[i] = draggedItem;
							draggingItem = false;
							draggedItem = null;
						}
					}

				} else {
					if(slotRect.Contains(e.mousePosition))
					{
						if(e.type == EventType.mouseUp && draggingItem)
						{
							inventory[i] = draggedItem;
							draggingItem = false;
							draggedItem = null;
						}
					}
				}
				if(tooltip == "")
				{
					showTooltip = false;
				}
				i++;
			}
		}
	}

	string CreateTooltip(Item item)
	{
		tooltip = item.itemName + "\n\n" + item.itemDesc;
		return tooltip;
	}

//	void AddItem(int id)
//	{
//		for (int c = 0; c < inventory.Count; c++) {
//			if(inventory[c].itemName == null)
//			{
//				for(int d = 0; d < database.items.Count;d++)
//				{
//					if(database.items[d].itemID == id)
//					{
//						inventory[c] = database.items[d];
//					}
//				}
//				break;
//			}
//		}
//	}

	void AddItem (int id)
	{
		Item item = InventoryContains (id);
		if (item != null && item.itemType == Item.ItemType.Consumable) {
			//fill later
		}

		for (int i = 0; i < inventory.Count; i++) {
			if(inventory[i].itemName != null)
			{
				inventory[i] = database.items[id];
				//inventory[i] = database.retrieve(id);
				return;
			}
		}
		Debug.Log ("Could not add requested item.");
		return;
	}
	//return item if it exists already, null otherwise
	Item InventoryContains(int id)
	{
		foreach (Item item in inventory) {
			if(item.itemID == id)
			{
				return item;
			}
		}
		return null;
	}
	//return item if removal was successful, null otherwise
	Item RemoveItem(int id)
	{
		for (int i = 0; i < inventory.Count; i++) {
			if(inventory[i].itemID == id)
			{
				Item item = inventory[i];
				inventory[i] = new Item();
				return item;
			}
		}
		Debug.Log ("Could not remove requested item.");
		return null;
	}

	private void UseConsumable (Item item, int slot, bool deleteItem)
	{
		switch (item.itemID) {
			case 2:
			{
				print("Used 1 " + item.itemName);
				//PlayerStats.IncreaseStat(/*STAT ID, BUFF AMOUNT, BUFF DURATION*/);
				break;
			}
//			case 3:
//			{
//				
//			}
//			case 4:
//			{
//				
//			}
		default:
			break;
		}

	}
}