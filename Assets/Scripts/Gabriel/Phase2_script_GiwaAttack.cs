using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class Phase2_script_GiwaAttack : MonoBehaviour
{
	[SerializeField] GameObject leftHP, midHP, rightHP;
	[SerializeField] private Text finalMessage;
	[SerializeField] GameObject arenaPosition, dustParticle;

	GameObject player, target;
	private float maxSpeed = 30, life = 3;
	private bool isStunned = false, isSleeping = true, isChasing = false, isAlive = true;
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
		if (isAlive) {
			if (Vector3.Distance (this.transform.position, target.transform.position) < 100) {
				if (!isChasing) {
					if (Vector3.Distance (this.transform.position, arenaPosition.transform.position) < 5) {
						this.transform.rotation = originalRotation;
						chargingTime = 5f;
						if (isStunned) {
							chargingTime += 3f;
							isStunned = false;
						}
						Invoke ("charge", chargingTime);
					} else
						walkToTarget ();
				} else if (isChasing) {
					walkToTarget ();
				}
			} else {
				if (isChasing && !isSleeping)
					resetPosition ();
				if (Vector3.Distance (this.transform.position, arenaPosition.transform.position) > 5)
					walkToTarget ();			
			}
		}
		if (life < 1) {
			midHP.SetActive (false);
		} else if (life < 2) {
			rightHP.SetActive (false);
		} else if (life < 3) {
			leftHP.SetActive(false);
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

	void boulderHit(){
		life -= 1;
		isStunned = true;
		resetPosition();
		if (life <= 0) {
			isAlive = false;
			missionResultMessage(true);
		}
	}


	void disableText(){
		finalMessage.gameObject.SetActive(false);
	}

	void missionResultMessage(bool won = false){
		finalMessage.gameObject.SetActive(true);
		finalMessage.text = won ? "You Won!!!" : "You Lost";
		if (won)
			finalMessage.color = Color.green;
		Invoke("disableText",1.5f);
	}

	void OnCollisionEnter(Collision other){
		if (other.gameObject.tag == Tags.Boulder) {
			Destroy (other.gameObject);
			boulderHit ();
			GameObject newSmoke = (GameObject)Instantiate (dustParticle, other.transform.position, this.transform.rotation);
			Destroy (newSmoke, 3f);
		} else if (other.gameObject.tag == Tags.Player) { 
			resetPosition ();
			missionResultMessage();
		}
		else if (other.gameObject.tag == Tags.WaterSpirit) {
			isSleeping = false;
		}
	}
}