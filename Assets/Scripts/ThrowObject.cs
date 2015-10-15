using UnityEngine;
using System.Collections;

public class ThrowObject : MonoBehaviour {
	
	private Rigidbody rb;
	private float speed;
	private bool hasBeenThrown;


	// Use this for initialization
	void Start ()
	{
		rb = this.GetComponent<Rigidbody> ();
		speed = 5.0f;
		hasBeenThrown = false;
	}
	
	// Update is called once per frame
	void Update () {
		if (Input.GetKey (KeyCode.A)) {
			Throw();
		}
	}

	void Throw()
	{
		Vector3 vector = new Vector3 (-10.0f, 5.0f, 0);
		rb.AddForce (vector * speed);
		hasBeenThrown = true;
	}

	public bool CheckIfHasBeenThrown(){
		return hasBeenThrown;
	}
}
