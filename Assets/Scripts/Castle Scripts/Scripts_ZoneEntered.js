﻿#pragma strict

//maybe add in a fade in mechanism
//link this to the fading objects somehow

var zoneDescription = "";
var style: GUIStyle;
var fadeTime: float;
var fadeSpeed: float;
var hasEntered = false;
var root = ""; 
var sunLight : Light;

private var color: Color;
private var timeOnScreen = 2;

function Start () {
	color = Color.white;
	style.fontSize = 20;
}

function FadeOut() {
	color.a = 1;
	yield WaitForSeconds(fadeTime);
	Fade();
}

function OnTriggerEnter(other: Collider) {
	if((other.tag == "Player") && hasEntered == false) {
		hasEntered = true;
		if (sunLight)
		{

			sunLight.enabled = false;
		}
		StopCoroutine("FadeOut");
		StartCoroutine("FadeOut");
		// Debug.Log("In " + transform.name);
	}
}


function OnTriggerExit(other: Collider) {
	StopCoroutine("FadeOut");
	if (sunLight)
		{	sunLight.enabled = true;}

	color.a = 0;
	hasEntered = false;
}

function OnGUI() {
	GUI.color = color;
	if(hasEntered) {
		GUI.Label (Rect (50, Screen.height/10, Screen.width, 50), zoneDescription, style);
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
