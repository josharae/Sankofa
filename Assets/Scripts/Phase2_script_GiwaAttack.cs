using UnityEngine;
using System.Collections;

public class Phase2_script_GiwaAttack : MonoBehaviour
{
	GameObject player;
	public GameObject arenaPosition;
	private float MaxSpeed = 2500;
	private bool isStunned = false, isSleeping = true, isChasing = false;
	Vector3 OriginalPosition;

//	private void slowing()
//	{
//		Rigidbody rb = GetComponent<Rigidbody> ();
//		if (rb.velocity.magnitude >= ((player.transform.position) - (transform.position)).magnitude)
//			isSlowing = true;
//		isSlowing = false;
//	}

	void Start()
	{
		player = GameObject.Find ("Player");
		OriginalPosition = this.transform.position;
		//Target = new GameObject();
		//Target.transform.position.Set (Player.transform.position.x,Player.transform.position.y,Player.transform.position.z);
	}

	void Update()
	{
		//Target.transform.position.Set(Player.transform.position.x,Player.transform.position.y,Player.transform.position.z);
		//slowing ();
		Rigidbody rb = GetComponent<Rigidbody> ();
		//if (rb.velocity <= (new Vector3 (25, 25, 25)))
		//	charge = true;
//		if (isSlowing) // WHAT IS THE SLOWING CONDITION
//		{
//			Vector3 val = rb.velocity;
//			rb.AddForce(Vector3.forward * MaxSpeed);
//				//Vector3.SmoothDamp(Vector3.forward,new Vector3(0,0,0),ref val,2F)); // HOW TO MAKE A REF
//		}
		if(Vector3.Distance(this.transform.position,player.transform.position) < 150)
		{
			transform.LookAt(player.transform);
			if(!isChasing) Invoke ("charge",5f);
			else if(isChasing) this.GetComponent<Rigidbody>().AddRelativeForce  (Vector3.forward * MaxSpeed);
		}
	}

	void charge()
	{
		isChasing = true;

	}

	void OnCollisionEnter(Collision other){
		if (other.gameObject.tag == Tags.Boulder)
			isStunned = true;
		else if (other.gameObject.tag == Tags.WaterSpirit) {
			isSleeping = false;
			this.transform.position = arenaPosition.transform.position;
		}
	}
}