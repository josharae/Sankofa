using UnityEngine;
using System.Collections;

public class ItemScript
{

	public string item_name;
	public int item_id;
	public string item_desc;
	public Sprite item_icon;
	public GameObject item_model;
	public int item_power;
	public int item_speed;
	public int item_value;
	public ItemType item_type;

	public enum ItemType
	{
		Weapon,
		Consumable,
		Quest,
		Head,
		Shoes,
		Chest,
		Trousers,
		Animal
	}

	public ItemScript (string name,int id,string desc, int power, int speed, int value, ItemType type)
	{
		item_name = name;
		item_id = id;
		item_desc = desc;
		item_speed = speed;
		item_value = value;
		item_type = type;
		item_icon = Resources.Load<Sprite> ("" + name);
	}

	public ItemScript()
	{

	}
}
