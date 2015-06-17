var isUserTerritory:boolean;
static var selectObject:GameObject;
private var num;
private var wasClicked;
private var initialState = true;
private var playerSelectionLight:GameObject;
private var awayFromView = Vector3(0,-100, 0);
function Awake() {
	wasClicked = false;
	num = 4;
	playerSelectionLight = GameObject.FindGameObjectWithTag("PlayerSelection");
}

function Start () {
	
}

function Update () {
}

function OnMouseEnter () {
	if (gameMechanics.canClick && num != 0 && isUserTerritory){
//		renderer.material.color = Color.red; //highlight selected object
		playerSelectionLight.transform.position = transform.position;
		playerSelectionLight.transform.position.y += 30;
	}
}
function OnMouseExit() {
	if (gameMechanics.canClick && isUserTerritory){
//		renderer.material.color = Color.white; //return to normal --- DOES NOT GO BACK TO NORMAL NEED TO FIX
		wasClicked = false;
		playerSelectionLight.transform.position = awayFromView;
	}
}

function OnMouseDown() {
	if (gameMechanics.canClick && num != 0 && isUserTerritory) {
		wasClicked = true;
	}
}

function OnMouseUp() {
	if (wasClicked){ //when this object is selected
		selectObject = gameObject;
	}
	wasClicked = false;
}
function getNum(){
	return num;
}
function setNum(a:int){
	num = a;
	initialState = false;
	return true;
}
function getState(){
	return initialState;
}