using UnityEngine;
using System.Collections;

public class ThrowObject : MonoBehaviour {

	public GameObject obj;
	private Rigidbody rb;
	private float speed;


	// Use this for initialization
	void Start ()
	{
		rb = obj.GetComponent<Rigidbody> ();
		speed = 5.0f;;
	}
	
	// Update is called once per frame
	void Update () {
		if (Input.GetKey (KeyCode.A)) {
			Throw();
		}
	}

	void Throw()
	{
		Vector3 vector = new Vector3 (0.0f, 5.0f, 10.0f);
		rb.AddForce (vector * speed);
	}
}
