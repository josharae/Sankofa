using UnityEngine;
using System.Collections;

public class BatDetection : MonoBehaviour {
	private GameObject player;
	private GameObject bat;

	public BatController controller;

	private bool isRotating;

	
	void Awake() {
		player = GameObject.FindGameObjectWithTag (Tags.Player);
		bat = GameObject.FindGameObjectWithTag (Tags.Bat);
		isRotating = false;
	}
	
	void OnTriggerEnter(Collider other) {
		if (other.gameObject == player && !(isRotating)) {
			
			Vector3 direction = other.transform.position - bat.transform.position;
			
			RaycastHit hit;
			
			if (Physics.Raycast (bat.transform.position, direction.normalized, out hit, 40)) {
				if (hit.collider.gameObject == player) {
					isRotating = true;
					controller.RotateAroundPlayer();
				}
			}
		}
	}
	void OnTriggerStay(Collider other) {
		if (other.gameObject == player && !(isRotating)) {
			
			Vector3 direction = other.transform.position - bat.transform.position;
			
			RaycastHit hit;
			
			if (Physics.Raycast (bat.transform.position, direction.normalized, out hit, 40)) {
				if (hit.collider.gameObject == player) {
					isRotating = true;
					controller.RotateAroundPlayer();
				}
			}
		}
	}
}
