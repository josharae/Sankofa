using UnityEngine;
using System.Collections;

public class BatController : MonoBehaviour {

	public float moveSpeed = 4;
	private int moveTick;
	private float xRand;
	private float yRand;
	private bool toggle;

	void Start() {
		moveTick = 300;
		xRand = Random.value;
		yRand = Random.value;
		toggle = true;
	}

	void Update() {
		moveTick--;
		if (moveTick == 0) {
			xRand = Random.value;
			yRand = Random.value;
			moveTick = 300;
		}

		if (toggle) {
			transform.position = Vector3.Lerp (transform.position,
		                                   transform.position + new Vector3 ((xRand - 0.5f) * moveSpeed, 0, (yRand - 0.5f) * moveSpeed),
		                                   Time.deltaTime);
		} else {
			transform.position = Vector3.Lerp (transform.position,
			                               transform.position - new Vector3 ((xRand - 0.5f) * moveSpeed, 0, (yRand - 0.5f) * moveSpeed),
			                               Time.deltaTime);
		}
	}

	public void RotateAroundPlayer() {
		//where you at
	}

	void OnTriggerEnter(Collider other) {
		if (toggle) {
			toggle = false;
		} else {
			toggle = true;
		}
	}
}
