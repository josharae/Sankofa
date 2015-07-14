using UnityEngine;
using System.Collections;

public class TutorialPlayer : MonoBehaviour {
	private float speed = 15f;
	public GameObject Hand;
	GameObject GameManager, myCamera;
	GameObject Item;
	int DownLimit = 50, UpLimit = -30;
	float yRotation = 0f, xRotation = 0f;
	public bool hasObj = false;
	Vector3 pos;
	
	
	void Start ()
	{
		GameManager = GameObject.Find ("GameManager");
		myCamera = GameObject.Find ("Main Camera");
		pos = Hand.transform.position;
	}

	void FixedUpdate(){
		float mouseHorizontal = Input.GetAxis ("Mouse X");
		yRotation += mouseHorizontal;
		transform.eulerAngles = new Vector3 (0, yRotation, 0);
		
		if (xRotation <= DownLimit && xRotation >= UpLimit) {
			myCamera.transform.eulerAngles = new Vector3 (xRotation, yRotation, 0);
		} else {
			if (xRotation > DownLimit)
				xRotation = DownLimit;
			if (xRotation < UpLimit)
				xRotation = UpLimit;
		}

	}
	void Update()
	{
		if(hasObj)
			Item.transform.position = Hand.transform.position;
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
		Item.GetComponent<Rigidbody>().AddRelativeForce (this.transform.forward * 100);
		EggScript bs = Item.GetComponent<EggScript> ();
		bs.SetThrownBool (true);
	}
}

