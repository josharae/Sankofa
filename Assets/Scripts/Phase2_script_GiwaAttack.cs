using UnityEngine;
using System.Collections;

public class Phase2_script_GiwaAttack : MonoBehaviour
{
	GameObject player;
	public GameObject arenaPosition;
	private float MaxSpeed = 30;
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

	void Start()
	{
		player = GameObject.Find ("Player");
		originalPosition = this.transform.position;
		originalRotation = this.transform.rotation;
		currentRate = initialRate;
		//Target = new GameObject();
		//Target.transform.position.Set (Player.transform.position.x,Player.transform.position.y,Player.transform.position.z);
	}

	void FixedUpdate()
	{
		//Target.transform.position.Set(Player.transform.position.x,Player.transform.position.y,Player.transform.position.z);
		//slowing ();
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
				//GetComponent<Rigidbody> ().velocity =  movement;
				transform.Translate(MaxSpeed*Vector3.forward*Time.deltaTime);
			}
			//	this.GetComponent<Rigidbody>().AddRelativeForce(Vector3.forward * MaxSpeed);
		}
	}

	void charge()
	{
		isChasing = true;
		CancelInvoke ();
	}

	void resetPosition(){
		this.GetComponent<Rigidbody> ().velocity = Vector3.zero;
		this.GetComponent<Rigidbody> ().angularVelocity = Vector3.zero;
		this.transform.position = arenaPosition.transform.position;
		this.transform.rotation = originalRotation;
		currentRate = initialRate;
		isChasing = false;
	}

	void OnCollisionEnter(Collision other){
		if (other.gameObject.tag == Tags.Boulder || other.gameObject.tag == Tags.Player) {
			isStunned = true;
			resetPosition();
		}

		else if (other.gameObject.tag == Tags.WaterSpirit) {
			isSleeping = false;

		}
	}
}