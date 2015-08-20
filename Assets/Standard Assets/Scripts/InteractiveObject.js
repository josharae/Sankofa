#pragma strict

private var isGlowing : boolean = false;
private var startColor : Color;
public var glowMat : Material;
public var currentMat : Material;

function Start () {
	startColor = GetComponent.<Renderer>().material.color;
}

function Glow() {
	if (isGlowing)
		return;
	isGlowing = true;
	GetComponent.<Renderer>().material = glowMat;
	// Debug.Log("Interacting!");
	GetComponent.<Renderer>().material.color = Color.red;
}

function UnGlow() {
	if (!isGlowing)
		return;
	GetComponent.<Renderer>().material.color = startColor;
	isGlowing = false;
	// Debug.Log(currentMat)
	GetComponent.<Renderer>().material = currentMat;
}

function Interact(v : Vector3, r : Quaternion, t : Transform) {
	Debug.Log("Interactable object!");

	// if (audiosource)
	// {
	// 	if(audiosource.isPlaying)
	// 		return;
	// 	MainCamera.Interrupted();
	// 	MainCamera.audioGameObject = gameObject;
	// 	audiosource.time = 0;
	// 	audiosource.Play();
	// } 
}

function Update () {

}