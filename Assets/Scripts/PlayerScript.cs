using UnityEngine;
using System.Collections;

public class PlayerScript : MonoBehaviour {
	private float speed = 2000f;
	public GameObject camera, Hand;
	GameObject GameManager;
	int DownLimit = 50, UpLimit = -30;
	GameObject Item;
	float yRotation = 0f, xRotation = 0f;
	public bool hasObj = false;

	void Start () {
		GameManager = GameObject.Find ("GameManager");
	}

	void FixedUpdate () {
			if (hasObj) //move bone with player
				Item.transform.position = Hand.transform.position;

			//rotation
			float mouseHorizontal = Input.GetAxis ("Mouse X");
			float mouseVertical = Input.GetAxis ("Mouse Y");
			yRotation += mouseHorizontal;
			xRotation += mouseVertical * -1;
			transform.eulerAngles = new Vector3 (0, yRotation, 0);

			if (xRotation <= DownLimit && xRotation >= UpLimit) {
				camera.transform.eulerAngles = new Vector3 (xRotation, yRotation, 0);
			} else {
				if (xRotation > DownLimit)
					xRotation = DownLimit;
				if (xRotation < UpLimit)
					xRotation = UpLimit;
			}

			//movement
			float moveVertical = Input.GetAxis ("Vertical");
			float moveHorizontal = Input.GetAxis ("Horizontal");
			Vector3 movement = new Vector3 (moveHorizontal, 0.0f, moveVertical);

			GetComponent<Rigidbody> ().velocity = Vector3.zero;

			GetComponent<Rigidbody> ().AddRelativeForce (movement * speed);

	}

	void Update(){
		if (Input.GetMouseButtonDown(1) && hasObj) {
			ChangeBoneRigidBody (true);
			hasObj = false;
		}
		if (Input.GetKeyDown (KeyCode.Space) && hasObj) {
			Throw ();
		}
	}

	public void ChangeBoneRigidBody(bool Active = false){
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
	            ChangeBoneRigidBody();
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
