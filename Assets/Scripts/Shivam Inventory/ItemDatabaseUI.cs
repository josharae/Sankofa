using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class ItemDatabase : MonoBehaviour
{
	public List<Item> items = new List<Item> ();
	// Use this for initialization
	void Start ()
	{
		items.Add (new Item ("alice_dad", 0, "hi", 5, 7, 9, Item.ItemType.Head));
		items.Add (new Item ("treasurebox", 1, "gold", 6, 8, 10, Item.ItemType.Chest));
		items.Add (new Item ("swordsprite2", 2, "a sword", 7, 5, 9, Item.ItemType.Weapon));
		items.Add (new Item ("spongebobsandy", 3, "a turtle", 1, 2, 3, Item.ItemType.Animal));
	}
	
	// Update is called once per frame
	void Update ()
	{
	
	}
}
