	using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnityEngine.EventSystems;
public class SlotScript : MonoBehaviour,IPointerDownHandler, IPointerEnterHandler, IPointerExitHandler,IDragHandler
{
	public Item item;
	Image item_image;
	public int slot_number;
	Inventory inventory;
	
	Text itemAmount;

	// Use this for initialization
	void Start ()
	{
		itemAmount = gameObject.transform.GetChild (1).GetComponent<Text> ();
		inventory = GameObject.FindGameObjectWithTag ("Inventory").GetComponent<Inventory> ();
		item_image = gameObject.transform.GetChild (0).GetComponent<Image> ();
	}
		
	// Update is called once per frame
	void Update ()
	{

		if (inventory.Items [slot_number].item_name != null) {
			item = inventory.Items [slot_number];
			item_image.enabled = true;
			item_image.sprite = inventory.Items [slot_number].item_icon;
			if (inventory.Items [slot_number].item_type == Item.ItemType.Consumable) {
				itemAmount.enabled = true;
				itemAmount.text = "" + inventory.Items [slot_number].item_value;
			}
			
		} else {
			item_image.enabled = false;

		}
		
	}

	public void OnPointerDown (PointerEventData data)
	{
		if (inventory.Items [slot_number].item_name == null && inventory.draggingItem) {
			inventory.Items [slot_number] = inventory.draggedItem;
			inventory.closeDraggedItem ();
		} else if (inventory.draggingItem && inventory.Items [slot_number].item_name != null) {
			inventory.Items [inventory.indexOfDraggedItem] = inventory.Items [slot_number];
			inventory.Items [slot_number] = inventory.draggedItem;
			inventory.closeDraggedItem ();
		}
	}

	public void OnPointerEnter (PointerEventData data)
	{
		if (inventory.Items [slot_number].item_name != null && ! inventory.draggingItem) {
			inventory.showTooltip (inventory.Slots [slot_number].GetComponent<RectTransform> ().localPosition, inventory.Items [slot_number]);
			//inventory.showToolTip(inventory.slots[slot_number]
		}
	}

	public void OnPointerExit (PointerEventData data)
	{
		if (inventory.Items [slot_number].item_name != null) {
			inventory.closeTooltip ();
		}
	}
		
	public void OnDrag (PointerEventData data)
	{
		if (inventory.Items [slot_number].item_name != null) {
			inventory.ShowDraggedItem (inventory.Items [slot_number], slot_number);
			inventory.Items [slot_number] = new Item ();
		}	
	}
		

}
