using UnityEngine;
using System.Collections;

public class PlayerScript : MonoBehaviour {
	[SerializeField] float speed = 15f, jumpSpeed = 15f;
	public GameObject camera, Hand;
	GameObject GameManager;
	int DownLimit = 50, UpLimit = -30;
	GameObject Item;
	Vector3 originalPosition;
	float yRotation = 0f, xRotation = 0f, gravity = 20f;
	public bool hasObj = false;
	Vector3 moveDirection;
	CharacterController playerController;
	Quaternion originalRotation;

	void Start () {
		GameManager = GameObject.Find (Tags.GameManager);
		playerController = this.GetComponent<CharacterController> ();
		originalPosition = this.transform.position;
		originalRotation = this.transform.rotation;
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

		if (playerController.isGrounded) {
			moveDirection = new Vector3 (moveHorizontal, 0, moveVertical);
			moveDirection = transform.TransformDirection (moveDirection);
			moveDirection *= speed;

			if (Input.GetKeyDown(KeyCode.Space)) {
				moveDirection.y = jumpSpeed;
			}
		}
		moveDirection.y -= gravity * Time.deltaTime;
		playerController.Move (moveDirection * Time.fixedDeltaTime);
	}
	
	void Update(){

		if (Input.GetMouseButtonDown(1) && hasObj) {
			ChangeObjectRigidBody (true);
			hasObj = false;
		}
		if (Input.GetKeyDown (KeyCode.T) && hasObj) {
			Throw ();
		}

		if (Input.GetKeyDown(KeyCode.Z)) {
			if(speed < 80)
				speed += 5;
		}
		else if (Input.GetKeyDown(KeyCode.X)) {
			if(speed > 15)
				speed -= 5;
		}
		else if (Input.GetKeyDown(KeyCode.Backspace)) {
			speed = 15;
		}
	}
	
	public void ChangeObjectRigidBody(bool Active){
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
				ChangeObjectRigidBody(false);
			}
		}
	}
	
	public GameObject getObject(){
		return Item;
	}
	
	void Throw()
	{
		hasObj = false;
		ChangeObjectRigidBody(true);
		Item.GetComponent<Rigidbody>().AddForce (camera.transform.forward * 3000);
		Item.GetComponent<ObjectScript> ().SetThrownBool(true);
	}

	void OnCollisionEnter(Collision other){
		if (other.gameObject.tag == Tags.Giwa) {
			this.GetComponent<FadingScreen> ().EndScene ();
			this.GetComponent<CharacterController>().Move(Vector3.zero) ;
			this.GetComponent<CharacterController>().SimpleMove(Vector3.zero) ;
			this.transform.position = originalPosition;
			this.transform.rotation = originalRotation;
		}

	}
}

