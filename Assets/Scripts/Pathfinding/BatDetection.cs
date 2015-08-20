using UnityEngine;
using System.Collections;

public class BatDetection : MonoBehaviour {
	private GameObject player;
	private GameObject bat;
	
	void Awake() {
		player = GameObject.FindGameObjectWithTag (Tags.Player);
		bat = GameObject.FindGameObjectWithTag (Tags.Bat);
	}
	
	void OnTriggerEnter(Collider other) {
		if (other.gameObject == player) {
			Debug.Log ("(BAT) Player collided with vision hitbox");
			
			Vector3 direction = other.transform.position - bat.transform.position;
			
			RaycastHit hit;
			
			if (Physics.Raycast (bat.transform.position, direction.normalized, out hit, 40)) {
				if (hit.collider.gameObject == player) {
					Debug.Log ("Player seen by BAT");
				}
			}
		}
	}
	void OnTriggerStay(Collider other) {
		if (other.gameObject == player) {
			
			Vector3 direction = other.transform.position - bat.transform.position;
			
			RaycastHit hit;
			
			if (Physics.Raycast (bat.transform.position, direction.normalized, out hit, 40)) {
				if (hit.collider.gameObject == player) {
					Debug.Log("Player seen by BAT");
				}
			}
		}
	}
}
