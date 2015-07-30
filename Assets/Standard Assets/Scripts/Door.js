#pragma strict

class Door extends InteractiveObject
{
	private var isOpen = false;
	private var isInteracting = false;
}

function Start () {

}

function Update () {

}

function Interact(v : Vector3, r : Quaternion, t : Transform)
{
	if(isInteracting)
		return;
	isInteracting = true;

	if(!isOpen)
		Open(Vector3(0, 0, 90), 0.5);
	else
		Open(Vector3(0, 0, -90), 0.5);
}

function Open(rotate : Vector3, time : float)
{
	isOpen = !isOpen;
	var initialRot = transform.localRotation;
    var targetRot = transform.localRotation * Quaternion.Euler(rotate);
    
    var t = 0.0;
    while (t < 1.0)
    {
        transform.localRotation = Quaternion.Slerp(initialRot, targetRot, t);
        t += Time.deltaTime / time;
        yield;
    }

	isInteracting = false;
}