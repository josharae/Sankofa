#pragma strict

//maybe add in a fade in mechanism
//link this to the fading objects somehow

var zoneDescription = "";
var style: GUIStyle;
var fadeTime: float;
var fadeSpeed: float;
var hasEntered = false;

private var color: Color;
private var timeOnScreen = 2;

function Start () {
	color = Color.white;
}

function FadeOut() {
	color.a = 1;
	yield WaitForSeconds(fadeTime);
	Fade();
}

function OnTriggerEnter(other: Collider) {
	if(other.tag == "Player") {
		hasEntered = true;
		
		StopCoroutine("FadeOut");
		StartCoroutine("FadeOut");
		Debug.Log("In");
	}
}

function OnTriggerExit(other: Collider) {
	StopCoroutine("FadeOut");
	color.a = 0;
	hasEntered = false;
}

function OnGUI() {
	GUI.color = color;
	if(hasEntered) {
		GUI.Label (Rect (0, Screen.height/10, Screen.width, 50), zoneDescription, style);
	}
}

function Fade() {
	while(color.a > 0) {
		color.a -= Time.deltaTime*fadeSpeed;
		yield;
	}
}

function Update () {

}
