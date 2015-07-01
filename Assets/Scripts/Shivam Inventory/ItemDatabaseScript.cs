using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class ItemDatabaseScript : MonoBehaviour
{
	public List<ItemScript> items = new List<ItemScript> ();
	// Use this for initialization
	void Start ()
	{
		items.Add (new ItemScript ("alice_dad", 0, "hi", 5, 7, 9, ItemScript.ItemType.Head));
		items.Add (new ItemScript ("treasurebox", 1, "gold", 6, 8, 10, ItemScript.ItemType.Chest));
		items.Add (new ItemScript ("swordsprite2", 2, "a sword", 7, 5, 9, ItemScript.ItemType.Weapon));
		items.Add (new ItemScript ("spongebobsandy", 3, "a turtle", 1, 2, 3, ItemScript.ItemType.Animal));
	}
	
	// Update is called once per frame
	void Update ()
	{
	
	}
}
