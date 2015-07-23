using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class Phase2_script_GiwaAttack : MonoBehaviour
{
	[SerializeField] GameObject leftHP, midHP, rightHP;
	[SerializeField] private Text finalMessage;
	[SerializeField] GameObject arenaPosition, dustParticle;
	enum giwaStates {sleeping, charging, stunned, chasing,waiting, walkingback, dead};
	giwaStates currentState;
	GameObject player, target;
	private float maxSpeed = 30, life = 3;
	private bool isStunned = false, isSleeping = true, isChasing = false, isAlive = true;
	public bool duelStarted = false;
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
		currentState = giwaStates.sleeping;
		duelStarted = GameObject.Find ("EntranceTrigger").GetComponent<EntranceScript> ().isFighting;

	}

	public void startDuel(){
		currentState = giwaStates.charging;
		duelStarted = true;
	}

	void FixedUpdate()
	{
		switch (currentState) {
			case giwaStates.stunned: {
				chargingTime = 8f;
				currentState = giwaStates.walkingback;
			}
			break;
			case giwaStates.charging: {
				Invoke ("charge", chargingTime);
				currentState = giwaStates.waiting;
			}		
			break;
			case giwaStates.chasing:{
				walkToTarget();
			}
			break;
			case giwaStates.walkingback:{
				walkToTarget();
				if (Vector3.Distance (this.transform.position, arenaPosition.transform.position) < 5 && duelStarted){
					this.transform.rotation = originalRotation;
					currentState = giwaStates.charging;
					}
			}
			break;
		}

	}

	void charge()
	{
		isChasing = true;
		isSleeping = false;
		currentState = giwaStates.chasing;
		target = player;
	}

	void walkToTarget(){
		Vector3 targetDirection = new Vector3 (target.transform.position.x, this.transform.position.y, target.transform.position.z);
		transform.LookAt (targetDirection);
		currentRate += Time.deltaTime;
		float vel = Mathf.Lerp (0, maxSpeed, currentRate);
		Vector3 movement = transform.forward * vel;
		movement.y -= 20f * Time.deltaTime;
		transform.position += transform.forward * maxSpeed * Time.deltaTime; 
	}

	void resetPosition(){
		this.GetComponent<Rigidbody> ().velocity = Vector3.zero;
		this.GetComponent<Rigidbody> ().angularVelocity = Vector3.zero;
		currentRate = initialRate;
		chargingTime = 5f;
		target = arenaPosition;
	}

	void boulderHit(){
		life -= 1;
		if (life < 1) {
			midHP.SetActive (false);
		} else if (life < 2) {
			rightHP.SetActive (false);
		} else if (life < 3) {
			leftHP.SetActive (false);
		}
		resetPosition ();
		currentState = giwaStates.stunned;
		if (life <= 0) {
			currentState = giwaStates.dead;
			missionResultMessage(true);
		}
	}


	void disableText(){
		finalMessage.gameObject.SetActive(false);
	}

	void missionResultMessage(bool won = false){
		finalMessage.gameObject.SetActive(true);
		finalMessage.text = won ? "You Won!!!" : "You Lost";
		if (won) {
			finalMessage.color = Color.green;
			Invoke ("loadOware", 1.5f);
		}
		else {
			life = 3;
			midHP.SetActive (false);
			rightHP.SetActive (false);
			leftHP.SetActive (false);
		}
		Invoke("disableText",1.5f);
		GameObject.FindWithTag (Tags.Entrance).GetComponent<Collider> ().enabled = false;
		GameObject.Find ("EntranceTrigger").GetComponent<EntranceScript> ().isFighting = false;
	}

	void loadOware(){
		Build_Scenes.Oware();
	}

	void OnCollisionEnter(Collision other){
		if (other.gameObject.tag == Tags.Boulder) {
			other.gameObject.GetComponent<AudioSource>().Play ();
			other.gameObject.SetActive(false);
			boulderHit ();
			GameObject newSmoke = (GameObject)Instantiate (dustParticle, other.transform.position, this.transform.rotation);
			Destroy (newSmoke, 3f);
		} else if (other.gameObject.tag == Tags.Player) { 
			resetPosition ();
			currentState = giwaStates.walkingback;
			missionResultMessage();
		}
		else if (other.gameObject.tag == Tags.WaterSpirit) {
			currentState = giwaStates.charging;
		}
	}
}