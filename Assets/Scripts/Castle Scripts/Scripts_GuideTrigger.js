#pragma strict

var startRad: float;
static var hasEntered = false;

private var col: SphereCollider;

function Start () {
	col = GetComponent(SphereCollider);
	col.radius = startRad;
}

function OnTriggerEnter(other : Collider) {
	if(other.tag == "Player") {
		hasEntered = true;
	}
}

function Update () {

}

