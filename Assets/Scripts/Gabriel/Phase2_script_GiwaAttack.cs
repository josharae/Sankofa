using UnityEngine;
using System.Collections;

public class Phase2_script_GiwaAttack : MonoBehaviour
{
	GameObject player, target;
	public GameObject arenaPosition;
	private float maxSpeed = 30, hitPoints = 3;
	private bool isStunned = false, isSleeping = true, isChasing = false;
	Vector3 originalPosition;
	Quaternion originalRotation;
	float currentRate, initialRate = 0.02f, chargingTime = 5f;


	void Start()
	{
		player = GameObject.Find ("Player");
		originalPosition = this.transform.position;
		originalRotation = this.transform.rotation;
		currentRate = initialRate;
		target = player;
	}

	void FixedUpdate()
	{
		if (Vector3.Distance (this.transform.position, target.transform.position) < 100){
			if (!isChasing){
				if(Vector3.Distance (this.transform.position, arenaPosition.transform.position) < 5) {
					this.transform.rotation = originalRotation;
					chargingTime = 5f;
					if (isStunned) {
						chargingTime += 3f;
						isStunned = false;
					}
					Invoke ("charge", chargingTime);
				}
				else
					walkToTarget ();
			}else if (isChasing) {
				walkToTarget ();
			}
		} else{
			if(isChasing && !isSleeping)
				resetPosition();
			if(Vector3.Distance (this.transform.position, arenaPosition.transform.position) > 5)
				walkToTarget ();			
		}
	}

	void charge()
	{
		isChasing = true;
		isSleeping = false;
		target = player;
		CancelInvoke ();
	}

	void walkToTarget(){
		Vector3 targetDirection = new Vector3 (target.transform.position.x, this.transform.position.y, target.transform.position.z);
		transform.LookAt (targetDirection);
		currentRate += Time.deltaTime;
		float vel = Mathf.Lerp (0, maxSpeed, currentRate);
		Vector3 movement = transform.forward * vel;
		Debug.Log (vel);
		movement.y = GetComponent<Rigidbody> ().velocity.y;
		transform.position += transform.forward * maxSpeed * Time.deltaTime; 
	}

	void resetPosition(){
		this.GetComponent<Rigidbody> ().velocity = Vector3.zero;
		this.GetComponent<Rigidbody> ().angularVelocity = Vector3.zero;
		currentRate = initialRate;
		target = arenaPosition;
		isChasing = false;
		isSleeping = true;
	}

	void OnCollisionEnter(Collision other){
		if (other.gameObject.tag == Tags.Boulder && other.gameObject.tag != Tags.Player) { //if boulder and not player
			isStunned = true; //stun
			hitPoints--; //-1 hitpoint
			if(hitPoints == 0)
			{
				//congratulations message, win scene, something happens, etc.
			}
		}
		else if (other.gameObject.tag == Tags.Boulder || other.gameObject.tag == Tags.Player) {
			isStunned = true;
			resetPosition();
		}

		else if (other.gameObject.tag == Tags.WaterSpirit) {
			isSleeping = false;

		}
	}
}