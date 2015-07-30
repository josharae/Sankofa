using UnityEngine;
using System.Collections;

public class PlayerController : MonoBehaviour {
	public float movespeed = 10f;
	public float turnSpeed = 50f;
	public Rigidbody rb;

	void Awake() {
		rb = this.GetComponent<Rigidbody>();
	}

	void Update () {
		rb.WakeUp ();

		if (Input.GetKey (KeyCode.W)) {
			transform.Translate (Vector3.forward * movespeed * Time.deltaTime);
		}

		if (Input.GetKey (KeyCode.S)) {
			transform.Translate (-Vector3.forward * movespeed * Time.deltaTime);
		}

		if(Input.GetKey(KeyCode.A))
			transform.Rotate(Vector3.up, -turnSpeed * Time.deltaTime);
		
		if(Input.GetKey(KeyCode.D))
			transform.Rotate(Vector3.up, turnSpeed * Time.deltaTime);
	}
}
