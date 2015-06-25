using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class ItemDatabase : MonoBehaviour {
	public List<Item> items = new List<Item>();
	void Start()
	{
		items.Add (new Item ("Amulet of Prayers", 0, "An amulet enchanted by powerful prayer", 0, 0, Item.ItemType.Quest));
		items.Add (new Item ("White Shirt", 1, "Shirt dyed white", 0, 0, Item.ItemType.Quest));
		items.Add (new Item ("Power Potion", 2, "Works just like steroi- milk.", 0, 0, Item.ItemType.Consumable));
	}

	public Item retrieve(int id)
	{
		//O(n), used for when items are added to database with ids out of order =)
		for (int i = 0; i < items.Count; i++) {
			if(items[i].itemID == id)
			{
				return items[i];
			}
		}
		return null;
	}
}
