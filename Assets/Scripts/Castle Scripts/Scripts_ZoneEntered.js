#pragma strict

//maybe add in a fade in mechanism
//link this to the fading objects somehow

var zoneDescription = "";
var style: GUIStyle;
var fadeTime: float;
var fadeSpeed: float;
var hasEntered = false;
var root = ""; 
var roomLight: GameObject;
var textureToDisplay : Texture2D;

private var lorem = "Lorem ipsum dolor sit amet, consectetur adipisicing elit. Voluptate quo laudantium, recusandae sint, magni repudiandae architecto excepturi dolore minus, eius cum";
private var color: Color;
private var timeOnScreen = 2;

function Start () {
	color = Color.white;
	style.fontSize = 20;
	if (roomLight)
	{
		roomLight.active = false;
	}
}

function FadeOut() {
	color.a = 1;
	yield WaitForSeconds(fadeTime);
	Fade();
}

function OnTriggerEnter(other: Collider) {
	if((other.tag == "Player") && hasEntered == false) {
		hasEntered = true;
		if (roomLight)
		{
			roomLight.active = true;
		}
		StopCoroutine("FadeOut");
		StartCoroutine("FadeOut");
		// Debug.Log("In " + transform.name);
	}
}


function OnTriggerExit(other: Collider) {
	StopCoroutine("FadeOut");
	if (roomLight)
		{	roomLight.active = false;}

	color.a = 0;
	hasEntered = false;
}

function OnGUI() {
	GUI.color = color;
	// GUI.skin.button.wordWrap = true;
	// GUI.skin.button.fixedWidth = 100.0;
	// Debug.Log(style.fixedWidth);
	style.fixedWidth = 100;
	style.wordWrap = true;
	style.fontSize = 16;
	if(hasEntered) {
		if (textureToDisplay)
		{

			GUI.Label (Rect (0, Screen.height/25, textureToDisplay.width, textureToDisplay.height), textureToDisplay);
		}
		// GUI.Box(Rect(50,Screen.height/10,Screen.width, 50),"This is a title");
		// GUI.Label (Rect (50, Screen.height/10, Screen.width, 50), "Lorem ipsum dolor sit amet, consectetur adipisicing elit. Voluptate quo laudantium, recusandae sint, magni repudiandae architecto excepturi dolore minus, eius cum exercitationem dignissimos. Quisquam recusandae officia voluptas obcaecati earum natus.", style);
		GUI.Label (Rect (65, Screen.height/10, 25, 50), zoneDescription, style);

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
