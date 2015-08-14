#pragma strict

var mapCam: GameObject;
var toFloor: int;

function OnTriggerEnter(other: Collider) {
	if(other.tag == "Player") {
		mapCam.GetComponent(Scripts_MapFollowScript).currentMap = toFloor;
	}
	Debug.Log("Currently on floor " + mapCam.GetComponent(Scripts_MapFollowScript).currentMap);
}