#pragma strict

var stunTime: float;		//number of seconds that giwa is stunned for
var invulTime: float; 	//number of seconds that giwa cannot be stunned for
var playerEntered: boolean;
enum aiStateGiwa{chasePlayer, stunned, hit, waiting};

private var state: aiStateGiwa;
private var player: GameObject;
private var nav: NavMeshAgent;
private var col: Collider;

private var hasHit: boolean;

function Start () {
	playerEntered = false;
	hasHit = false;
	
	player = GameObject.FindGameObjectWithTag("Player");
	nav = GetComponent(NavMeshAgent);
	col = GetComponent(Collider);
	
	StartCoroutine("FSM");
	state = aiStateGiwa.waiting;
}

function Update () {
	if(playerEntered) {
		state = aiStateGiwa.chasePlayer;
		playerEntered = false;
	}
	if(state == aiStateGiwa.stunned) {
		Debug.Log(state);
	}
}


function FSM() {
	while(true) {
		switch(state) {
			case aiStateGiwa.chasePlayer:
				yield WaitForSeconds(0.001);
				yield nav.SetDestination(player.transform.position);
				break;
			case aiStateGiwa.stunned:
				yield nav.SetDestination(this.transform.position);
				yield WaitForSeconds(stunTime);
				state = aiStateGiwa.chasePlayer;
				break;
			case aiStateGiwa.hit:
				yield nav.SetDestination(this.transform.position);
				yield WaitForSeconds(stunTime);
				state = aiStateGiwa.chasePlayer;
				break;
			case aiStateGiwa.waiting:
				yield nav.SetDestination(this.transform.position);
				yield WaitForSeconds(0.001);
				break;
		}
	}
}


//detects collision with the player and rocks
function OnTriggerEnter(other: Collider) {
	if(other.tag == "Player") {
		Application.LoadLevel(0);
	}
	if(other.tag == "rock" && !hasHit) {
		state = aiStateGiwa.stunned;
		hasHit = true;
		StartCoroutine("Invulnerable");
		Debug.Log("hit a rock");
	}
}

function Invulnerable() {
	yield WaitForSeconds(invulTime);
	hasHit = false;
}
