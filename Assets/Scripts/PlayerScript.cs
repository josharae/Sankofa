using UnityEngine;
using System.Collections;

public class PlayerScript : MonoBehaviour {
	private float speed = 2000f;
	public GameObject camera;
	public GameObject Hand;
	int DownLimit = 50, UpLimit = -30;
	GameObject Bone;
	float yRotation = 0f, xRotation = 0f;
	public bool hasObj = false;

	void Start () {
	}

	void FixedUpdate () {
			if (hasObj) //move bone with player
				Bone.transform.position = Hand.transform.position;

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
	}

	public void ChangeBoneRigidBody(bool Active = false){
		Bone.GetComponent<Rigidbody> ().useGravity = Active;
		Bone.GetComponent<Rigidbody> ().detectCollisions = Active;
	}

	public void getObject(GameObject bone){
        if (!hasObj)
        {
            hasObj = true;
            Bone = bone;
            ChangeBoneRigidBody();
        }
	}
}
