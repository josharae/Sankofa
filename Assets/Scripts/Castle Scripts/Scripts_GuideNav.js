#pragma strict

var movespeed:float;
var detectrad:float;
//may need multiple for different paths
var destinations:Transform[];

enum aiState{waiting, leading, finished};
var state: aiState;

private var player: GameObject;
private var nav: NavMeshAgent;
private var currentDestinationNumber: int;

function Start () {
	nav = GetComponent(NavMeshAgent);
	player = GameObject.FindGameObjectWithTag("Player");
	//need a set of destinations
	state = aiState.waiting;
	StartCoroutine("FSM");
}

function Update () { //maybe remove everything from the update method to save cpu after, the guide finishes maybe guide disappears?
	
}

function FSM() {
	while(true) {
		switch(state) {
			case aiState.finished:
				break;
			case aiState.waiting:
				WaitForPlayer();
				break;
			case aiState.leading:
				Travel();
				break;
			
		}
	}
}

//lead the player through all the points in the destinations[] array
function Travel() {
	//might have to become a coroutine
}

//lead the player to the next destination
function ToNextDest(destination:Vector3) {
	nav.SetDestination(destination);
}

function WaitForPlayer() {

}

function OnTriggerEnter(other: Collider) {
	Debug.Log("Object is in");
}


