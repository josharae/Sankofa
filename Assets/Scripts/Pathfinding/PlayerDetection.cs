﻿using UnityEngine;
using System.Collections;

public class PlayerDetection : MonoBehaviour {
	private GameObject player;
	private GameObject onini;
	
	void Awake() {
		player = GameObject.FindGameObjectWithTag (Tags.Player);
		onini = GameObject.FindGameObjectWithTag (Tags.onini);
	}
	
	void OnTriggerEnter(Collider other) {
		if (other.gameObject == player) {
			Debug.Log ("Player collided with vision hitbox");
			
			Vector3 direction = other.transform.position - onini.transform.position;
			
			RaycastHit hit;
			
			if (Physics.Raycast (onini.transform.position, direction.normalized, out hit, 20)) {
				if (hit.collider.gameObject == player) {
					Debug.Log ("Player seen by Onini");
				}
			}
		}
	}
	void OnTriggerStay(Collider other) {
		if (other.gameObject == player) {
			
			Vector3 direction = other.transform.position - onini.transform.position;
			
			RaycastHit hit;
			
			if (Physics.Raycast (onini.transform.position, direction.normalized, out hit, 20)) {
				if (hit.collider.gameObject == player) {
					Debug.Log("Player seen by Onini");
				}
			}
		}
	}
}
