#pragma strict

var mapCam: GameObject;
var toFloor: int;

function OnTriggerEnter(other: Collider) {
    if (!checkFloor())
    {
        if(other.tag == "Player")
        {
            mapCam.GetComponent(Scripts_MapFollowScript).switchMap(toFloor);
        }
        Debug.Log("Currently on floor " + toFloor);
    }
}


// Checks if floor is the same as the collider
function checkFloor() {


    return (mapCam.GetComponent(Scripts_MapFollowScript).currentFloor() == toFloor);
}