//using UnityEngine;
//
using UnityEngine;

using System.Collections;

public class ObjectScript : MonoBehaviour {
	GameObject player;
	public bool isCollected = false;
	Vector3 OriginalPosition;
	public bool hasBeenThrown;

	void Start () {
		player = GameObject.Find ("Player");
		OriginalPosition = this.transform.position;
		hasBeenThrown = false;
	}
	
	void OnMouseDown(){
		if (Vector3.Distance (transform.position, player.transform.position) < 20 && !isCollected){
			player.GetComponent<PlayerScript>().getObject(this.gameObject);
		}
	}
	
	void OnCollisionEnter(Collision other){
	}
	
	
	public void TeleportBack(){
		this.transform.position = OriginalPosition;
	}
	
	public void SetThrownBool(bool thrown){
		hasBeenThrown = thrown;
	}
}

