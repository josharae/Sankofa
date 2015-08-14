#pragma strict

var player: GameObject;
var maps: GameObject[];
var currentMap: int;
var personTexture: Texture;

private var camDisplacement = 100;
private var position: Rect;

function Start () {
	currentMap = 0;
	position = Rect(148, Screen.height - 122, 15, 15);
}

function Update () {
	this.transform.position = new Vector3(player.transform.position.x, 
		maps[currentMap].transform.position.y + camDisplacement,player.transform.position.z);
	
}

function OnGUI() {
	
	GUI.DrawTexture(position, personTexture);
}