#pragma strict

var giwa: GameObject;

function Start () {

}

function Update () {

}

function OnTriggerEnter(other: Collider) {
	if(other.tag == "Player") {
		giwa.GetComponent(Scripts_GiwaScript).playerEntered = true;
	}
}