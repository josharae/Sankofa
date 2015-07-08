using UnityEngine;
using System.Collections;

public class Phase2_script_GiwaAttack : MonoBehaviour
{
	public GameObject Player;
	private float MaxSpeed = 30000;
	public GameObject Target;	
	private bool isSlowing = false;
	//private bool charge = true;
	//private int IntHits = 0;

	private void slowing()
	{
		Rigidbody rb = GetComponent<Rigidbody> ();
		if (rb.velocity.magnitude >= ((Target.transform.position) - (transform.position)).magnitude)
			isSlowing = true;
		else
			isSlowing = false;
	}

	void Start()
	{
		//Target = new GameObject();
		//Target.transform.position.Set (Player.transform.position.x,Player.transform.position.y,Player.transform.position.z);
	}

	void Update()
	{
//		Target.transform.position.Set(Player.transform.position.x,Player.transform.position.y,Player.transform.position.z);
//		slowing ();
		Rigidbody rb = GetComponent<Rigidbody> ();
		//if (rb.velocity <= (new Vector3 (25, 25, 25)))
		//	charge = true;
		if (isSlowing) // WHAT IS THE SLOWING CONDITION
		{
			Vector3 val = rb.velocity;
			rb.AddForce(Vector3.SmoothDamp(Vector3.forward,new Vector3(0,0,0),ref val,2F)); // HOW TO MAKE A REF
		}
		else //if(!isSlowing)//(charge) // What is the charging condition    (NOT SLOWING)
		{
			transform.LookAt(Target.transform);
			Vector3 localVel = transform.InverseTransformDirection(rb.velocity);
			rb.AddForce (new Vector3(localVel.x, 0.0f, localVel.z) * MaxSpeed * Time.smoothDeltaTime);
		}
	}

	void FixedUpdate()
	{
        //useless
	}
}