using UnityEngine;
using System.Collections;

public class TutorialPlayer : MonoBehaviour {
	float eggSpeed = 100f,speed = 15f, piecesSpeed = 1000f;
	public GameObject Hand;
	GameObject GameManager, myCamera;
	GameObject Item;
	int DownLimit = 50, UpLimit = -30;
	float yRotation = 0f, xRotation = 0f;
	public bool hasObj = false;
	Vector3 pos, moveDirection;
	CharacterController playerController;
	
	void Start ()
	{
		GameManager = GameObject.Find ("GameManager");
		myCamera = GameObject.Find ("Main Camera");
		playerController = this.GetComponent<CharacterController> ();
		pos = Hand.transform.position;
	}

	void FixedUpdate(){
//		if(hasObj)
//			Item.transform.position = Hand.transform.position;
//		float mouseHorizontal = Input.GetAxis ("Mouse X");
//		yRotation += mouseHorizontal;
//		transform.eulerAngles = new Vector3 (0, yRotation, 0);
//		
//		if (xRotation <= DownLimit && xRotation >= UpLimit) {
//			//myCamera.transform.eulerAngles = new Vector3 (xRotation, yRotation, 0);
//			this.transform.eulerAngles = new Vector3 (xRotation, yRotation, 0);
//		} else {
//			if (xRotation > DownLimit)
//				xRotation = DownLimit;
//			if (xRotation < UpLimit)
//				xRotation = UpLimit;
//		}
		if (hasObj) //move bone with player
			Item.transform.position = Hand.transform.position;
		
		//rotation
		float mouseHorizontal = Input.GetAxis ("Mouse X");
		float mouseVertical = Input.GetAxis ("Mouse Y");
		yRotation += mouseHorizontal;
		xRotation += mouseVertical * -1;
		transform.eulerAngles = new Vector3 (0, yRotation, 0);
		
		if (xRotation <= DownLimit && xRotation >= UpLimit) {
			this.transform.eulerAngles = new Vector3 (xRotation, yRotation, 0);
		} else {
			if (xRotation > DownLimit)
				xRotation = DownLimit;
			if (xRotation < UpLimit)
				xRotation = UpLimit;
		}
		
		//movement
		float moveVertical = Input.GetAxis ("Vertical");
		float moveHorizontal = Input.GetAxis ("Horizontal");
		
		if (playerController.isGrounded) {
			moveDirection = new Vector3 (moveHorizontal, 0, moveVertical);
			moveDirection = transform.TransformDirection (moveDirection);
			moveDirection *= speed;
		}
		playerController.Move (moveDirection * Time.fixedDeltaTime);

	}
	void Update()
	{
		if (Input.GetKeyDown (KeyCode.Space) || Input.GetMouseButtonDown (1) && hasObj)
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
				//this.GetComponent<InventoryScript>().AddItem(newItem);
			}
				hasObj = true;
				Item = newItem;
				ChangeBoneRigidBody(false);
		}
	}
	
	public GameObject getObject(){
		return Item;
	}
	
	void Throw()
	{
		float objSpeed = 0;
		hasObj = false;
		ChangeBoneRigidBody(true);
		if (Item.tag == Tags.cosmicEgg) {
			EggScript bs = Item.GetComponent<EggScript> ();
			bs.SetThrownBool (true);
			objSpeed = eggSpeed;
		}	
		else
			objSpeed = piecesSpeed;
		Debug.Log (this.transform.forward);
		Item.GetComponent<Rigidbody>().AddForce (this.transform.forward * objSpeed,ForceMode.Acceleration);
	}
}

