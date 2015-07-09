using UnityEngine;
using System.Collections;

public class TutorialPlayer : MonoBehaviour {
	private float speed = 15f;
	public GameObject Hand;
	GameObject GameManager;
	GameObject Item;
	float yRotation = 0f, xRotation = 0f;
	public bool hasObj = false;
	Vector3 pos;
	
	
	void Start ()
	{
		GameManager = GameObject.Find ("GameManager");
		pos = Hand.transform.position;
	}
	
	void FixedUpdate ()
	{
		if (hasObj) //move bone with player
			Item.transform.position = pos;
		
		//rotation
		float mouseHorizontal = Input.GetAxis ("Mouse X");
		float mouseVertical = Input.GetAxis ("Mouse Y");
		yRotation += mouseHorizontal;
		xRotation += mouseVertical * -1;
		transform.eulerAngles = new Vector3 (0, yRotation, 0);

		
		//movement
		float moveVertical = Input.GetAxis ("Vertical");
		float moveHorizontal = Input.GetAxis ("Horizontal");
		
		Vector3 movement = (transform.forward * moveVertical + transform.right * moveHorizontal) * speed;
		movement.y = GetComponent<Rigidbody> ().velocity.y;
		GetComponent<Rigidbody> ().velocity =  (movement);
		
	}
	
	void Update()
	{
		if (Input.GetMouseButtonDown(1) && hasObj) 
		{
			ChangeBoneRigidBody (true);
			hasObj = false;
		}
		if (Input.GetKeyDown (KeyCode.Space) && hasObj)
		{
			Throw ();
		}
	}
	
	public void ChangeBoneRigidBody(bool Active){
		Item.GetComponent<Rigidbody> ().velocity = Vector3.zero;
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
				ChangeBoneRigidBody(false);
			}
		}
	}
	
	public GameObject getObject(){
		return Item;
	}
	
	void Throw()
	{
		hasObj = false;
		ChangeBoneRigidBody(true);
		Item.GetComponent<Rigidbody>().AddRelativeForce (this.transform.forward * 30);
		BoneScript bs = Item.GetComponent<BoneScript> ();
		bs.SetThrownBool (true);
	}
}

