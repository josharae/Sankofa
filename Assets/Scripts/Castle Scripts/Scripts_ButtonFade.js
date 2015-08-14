#pragma strict

var objectToFade: GameObject;
var fadeSpeed: float;
var willfade: boolean;

private var objAlpha: float;
private var rend: Renderer;

function Start () {
	rend = objectToFade.GetComponent(Renderer);
	objAlpha = rend.material.color.a;
}

function Update () {
	if(willfade && objAlpha > 0) {
		objAlpha -= fadeSpeed;
	}
	else if(!willfade && objAlpha < 1) {
		objAlpha += fadeSpeed;
	}
	rend.material.color.a = objAlpha;
}