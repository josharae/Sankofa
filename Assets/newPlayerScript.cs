using UnityEngine;
using System.Collections;

public class newPlayerScript : MonoBehaviour {
	float speed = 50f;
	public GameObject Hand;
	GameObject GameManager;

	GameObject Item;

	public bool hasObj = false;
	
	void Start () {
		GameManager = GameObject.Find ("GameManager");
	}
	
	void FixedUpdate () {
		if (hasObj) //move bone with player
			Item.transform.position = Hand.transform.position;
	}
	
	void Update(){
		if (Input.GetMouseButtonDown(1) && hasObj) {
			ChangeObjRigidBody (true);
			hasObj = false;
		}
		if (Input.GetKeyDown (KeyCode.Space) && hasObj) {
			Throw ();
		}
	}
	
	public void ChangeObjRigidBody(bool Active){
		Active = false;
		Item.GetComponent<Rigidbody> ().useGravity = Active;
		Item.GetComponent<Rigidbody> ().detectCollisions = Active;
	}
	
	public void getObject(GameObject newItem){
		if (!hasObj)
		{
			if(newItem.tag == Tags.Collectible){
				GameManager.GetComponent<ItemPanelScript>().ShowItemPanel(newItem);
				this.GetComponent<InventoryScript>().AddItem(newItem);
			}
			else {
				hasObj = true;
				Item = newItem;
				ChangeObjRigidBody(false);
			}
		}
	}
	
	public GameObject getObject(){
		return Item;
	}
	
	void Throw()
	{
		hasObj = false;
		Item.GetComponent<Rigidbody>().AddRelativeForce (this.transform.forward * speed);
	}
}
