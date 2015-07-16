using UnityEngine;
using System.Collections;

public class Oware_Script_MarbleBehavior : MonoBehaviour {

	private bool moving;

	// Use this for initialization
	void Start () {
		moving = false;
	}
	
	// Update is called once per frame
	void Update () {

	}

	void OnCollisonEnter(Collision other){
		Destroy (other.gameObject);
//		if (other.collider.gameObject.CompareTag ("Marble") && moving == true) {
//			Physics.IgnoreCollision(this.GetComponent<Collider>(), other.collider);
//			this.GetComponent<Rigidbody> ().useGravity = false;
//			this.GetComponent<Rigidbody> ().detectCollisions = false;
//		}
	}

	public void SetMovingBool(bool state){
		moving = state;
	}
}
