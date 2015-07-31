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
	private float maxSpeed = 30;
	private int life = 3;
	public bool duelStarted = false;
	Vector3 originalPosition;
	Quaternion originalRotation;
	float currentRate, initialRate = 0.02f, chargingTime = 5f;


	void Start(){
		player = GameObject.FindWithTag (Tags.Player);
		originalPosition = this.transform.position;
		originalRotation = this.transform.rotation;
		currentRate = initialRate;
		currentState = giwaStates.sleeping;
	}

	public void startDuel(){
		currentState = giwaStates.charging;
		life = 3;
		duelStarted = true;
	}

	void FixedUpdate()
	{
		if (Vector3.Distance (this.transform.position, arenaPosition.transform.position) > 250 || Vector3.Distance (this.transform.position, player.transform.position) > 250 && duelStarted) {
			endDuel();
		}
		switch (currentState) {
			case giwaStates.stunned: 
				chargingTime = 8f;
				currentState = giwaStates.walkingback;
			break;
			case giwaStates.charging: 
				Invoke ("attackPlayer", chargingTime);
				currentState = giwaStates.waiting;

			break;
			case giwaStates.chasing:
				walkToTarget();
			break;
			case giwaStates.walkingback:
			{
				walkToTarget();
				if (Vector3.Distance (this.transform.position, arenaPosition.transform.position) < 5 && duelStarted){
					this.transform.rotation = originalRotation;
					this.GetComponent<Rigidbody> ().velocity = Vector3.zero;
					this.GetComponent<Rigidbody> ().angularVelocity = Vector3.zero;
					currentState = giwaStates.charging;
				}
			}
			break;
		}

	}

	void attackPlayer(){
		target = player;
		currentState = giwaStates.chasing;
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

	void endDuel(){
		resetVariables ();
		this.transform.position = arenaPosition.transform.position;
		this.transform.rotation = originalRotation;
		currentState = giwaStates.waiting;
		GameObject.Find ("EntranceTrigger").GetComponent<EntranceScript> ().battleEnded ();
	}

	void resetVariables(){
		this.GetComponent<Rigidbody> ().velocity = Vector3.zero;
		this.GetComponent<Rigidbody> ().angularVelocity = Vector3.zero;
		currentRate = initialRate;
		chargingTime = 5f;
		target = arenaPosition;
	}


	void updateLifeUI(){
		switch (life) {
		case 0:
			midHP.SetActive (false);
			break;
		case 1:
			rightHP.SetActive (false);
			break;
		case 2:
			leftHP.SetActive (false);
			break;
		}
	}

	void boulderHit(GameObject boulder){
		boulder.GetComponent<AudioSource>().Play ();
		boulder.SetActive(false);
		GameObject newSmoke = (GameObject)Instantiate (dustParticle, boulder.transform.position, this.transform.rotation);
		newSmoke.SetActive (true);
		Destroy (newSmoke, 3f);

		life -= 1;
		if (life <= 0) {
			currentState = giwaStates.dead;
			missionResultMessage (true);
		} else
			currentState = giwaStates.stunned;
		updateLifeUI ();
		resetVariables ();
	}

	void wonBattle(){
		resetVariables ();
		this.transform.position = arenaPosition.transform.position;
		this.transform.rotation = originalRotation;
		currentState = giwaStates.waiting;
		missionResultMessage();
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
			midHP.SetActive (false);
			rightHP.SetActive (false);
			leftHP.SetActive (false);
		}
		Invoke("disableText",1.5f);
		GameObject.Find ("EntranceTrigger").GetComponent<EntranceScript> ().battleEnded ();
	}

	public void loadOware(){
		Build_Scenes.showLoading ();
		Build_Scenes.Oware();
	}

	void OnCollisionEnter(Collision other){
		if (other.gameObject.tag == Tags.Boulder) {
			boulderHit (other.gameObject);

		} else if (other.gameObject.tag == Tags.Player) { 
			wonBattle();
		}
		else if (other.gameObject.tag == Tags.WaterSpirit) {
			currentState = giwaStates.charging;
		}
	}
}