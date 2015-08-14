#pragma strict

//IMPORTANT: the objects that are fading must have a material with the
//rendering mode set to 'fade' or this script will not work

//the residentZone variable should be set to the zone that tha object is in

var fadeSpeed: float;
var residentZone: GameObject;

private var objAlpha: float;
private var rend: Renderer;

function Start () {
	rend = GetComponent(Renderer);
	objAlpha = rend.material.color.a;
}

function Update () {
	if(!residentZone.GetComponent(Scripts_ZoneEntered).hasEntered && objAlpha > 0) {
		objAlpha -= fadeSpeed;
	}
	else {
		if(objAlpha < 1) {
			objAlpha += fadeSpeed;
		}
	}
	rend.material.color.a = objAlpha;
}
