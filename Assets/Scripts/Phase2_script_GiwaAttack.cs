using UnityEngine;
using System.Collections;

public class Phase2_script_GiwaAttack : MonoBehaviour
{
<<<<<<< HEAD
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
=======
	GameObject player;
	public GameObject arenaPosition;
	private float MaxSpeed = 20;
	private bool isStunned = false, isSleeping = true, isChasing = false;
	Vector3 originalPosition;
	Quaternion originalRotation;
	float currentRate, initialRate = 0.02f, chargingTime = 5f;
//	private void slowing()
//	{
//		Rigidbody rb = GetComponent<Rigidbody> ();
//		if (rb.velocity.magnitude >= ((player.transform.position) - (transform.position)).magnitude)
//			isSlowing = true;
//		isSlowing = false;
//	}
>>>>>>> origin/master

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
<<<<<<< HEAD
			Vector3 val = rb.velocity;
			rb.AddForce(Vector3.SmoothDamp(Vector3.forward,new Vector3(0,0,0),ref val,2F)); // HOW TO MAKE A REF
		}
		else //if(!isSlowing)//(charge) // What is the charging condition    (NOT SLOWING)
		{
			transform.LookAt(Target.transform);
<<<<<<< HEAD
			Vector3 localVel = transform.InverseTransformDirection(rb.velocity);
			rb.AddForce (new Vector3(localVel.x, 0.0f, localVel.z) * MaxSpeed * Time.smoothDeltaTime);
=======
			rb.AddRelativeForce (Vector3.forward * MaxSpeed * Time.smoothDeltaTime);
=======
			if(!isChasing){
				chargingTime = 5f;
				if(isStunned){
					chargingTime += 3f;
					isStunned = false;
				}
				Invoke ("charge",chargingTime);
			}
			else if(isChasing){
				//transform.LookAt(player.transform);
				Vector3 target = new Vector3(player.transform.position.x, this.transform.position.y, player.transform.position.z);
				transform.LookAt(target);
				currentRate+=Time.deltaTime;
				float vel = Mathf.Lerp(0,MaxSpeed,currentRate);
				Vector3 movement = transform.forward * vel;
				Debug.Log(vel);
				movement.y = GetComponent<Rigidbody> ().velocity.y;
				GetComponent<Rigidbody> ().velocity =  movement;
				//transform.Translate(MaxSpeed*Vector3.forward*Time.deltaTime);
			}
			//	this.GetComponent<Rigidbody>().AddRelativeForce(Vector3.forward * MaxSpeed);
>>>>>>> origin/master
>>>>>>> origin/master
		}
	}

	void FixedUpdate()
	{
        //useless
	}
}