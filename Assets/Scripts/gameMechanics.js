static var canClick;
var houses = new Array();
private var currentHouse:GameObject;
private var currentHouseNum:int;
private var seedNum:int;
private var enemyPick:int;
private var playerTurn:boolean;
private var playerTerritoryCount = 0;
private var enemyTerritoryCount = 0;
private var gameEnded = false;
private var counter = 0;
private var playerSelectionLight:GameObject;
private var enemySelectionLight:GameObject;
private var awayFromView = Vector3(0,-100, 0);
var fadeSpeed = .5;
var playerTerritoryText : GUIText;
var enemyTerritoryText : GUIText;
var screenFader: GUITexture;

function Awake() {
	canClick = true;
	playerTurn = true;
	playerSelectionLight = GameObject.FindGameObjectWithTag("PlayerSelection");
	enemySelectionLight = GameObject.FindGameObjectWithTag("EnemySelection");
}
function Start () {  // SOUND - GAME START
	updateTerritories();
	updateTurn();
	playerSelectionLight.transform.position = awayFromView;
	enemySelectionLight.transform.position = awayFromView;
	screenFader.GetComponent.<GUITexture>().color = Color.clear;
	Screen.lockCursor = false;
}

function Update () {
	if (onClick.selectObject){ //call when player has selected an object // SOUND - PLAYER SELECT, COLOR - PLAYER SELECT
//		if (enemyPick) houses[enemyPick].renderer.material.color = Color.white; //return enemy piece to white
		currentHouse = onClick.selectObject;
		canClick = false;
		for (var child : Transform in gameObject.transform) {
			houses.Push(child.gameObject);
		}
		for (var i = 0; i < houses.length; i++){
			if (houses[i]==currentHouse){
				currentHouseNum = i; //find corresponding house number
			}
		}
		
		StartCoroutine("sowSeeds", currentHouseNum);
	//	sowSeeds(currentHouseNum); //player moves seeds
		//Debug.Log(currentHouse.GetComponent(onClick).getNum());
	}
	onClick.selectObject = null;
}

function sowSeeds(houseNum:int){ //player or enemy moves
	yield WaitForSeconds (.8);
	
	seedNum = houses[houseNum].GetComponent(onClick).getNum();
	var seedCount = 0;
	for (k = 0; k < houses.length; k++){
		seedCount += houses[k].GetComponent(onClick).getNum();
	}
	Debug.Log("House Number: "+ houseNum +" Seed Number: "+ seedNum+" Remaining Seeds: "+seedCount);
	houses[houseNum].GetComponent(onClick).setNum(0);
	for (var i=1; i<seedNum; i++){
		houseNum++;
		if (houseNum > 11) houseNum -= 12;
		var params = new Array();
		params.Push(houses[currentHouseNum].transform.GetChild(0));
		params.Push(houses[houseNum]);
//		StartCoroutine("PlaceBall", params);
		yield WaitForSeconds (.4);
		PlaceBall(params);
		Debug.Log(params);
		houses[houseNum].GetComponent(onClick).setNum(houses[houseNum].GetComponent(onClick).getNum()+1);
		if (houses[houseNum].GetComponent(onClick).getNum() == 4 && !houses[houseNum].GetComponent(onClick).getState()){ //award territory when reaching 4
			houses[houseNum].GetComponent(onClick).setNum(0);
			RemoveBalls(houses[houseNum]);
			if (playerTurn) playerTerritoryCount ++; // SOUND - PLAYER TERRITORY WIN
			else enemyTerritoryCount ++; // SOUND - ENEMY TERRITORY WIN
			updateTerritories();
			if (playerTerritoryCount + enemyTerritoryCount == 11){
				gameEnd();
				break;
			}
		}
	}
	houseNum++;
	if (houseNum > 11) houseNum -= 12;
	if (houses[houseNum].GetComponent(onClick).getNum()==0 && !gameEnded){
		params = new Array();
		Debug.Log("!@#!+@#!+@#!@#!#!@#!@#!@#!@ "+ houses[currentHouseNum]);
		if(houses[currentHouseNum].transform.childCount > 0){
			params = new Array();
			params.Push(houses[currentHouseNum].transform.GetChild(0));
			params.Push(houses[houseNum]);
//			StartCoroutine("PlaceBall", params);
			yield WaitForSeconds (.4);
			PlaceBall(params);
		}
		houses[houseNum].GetComponent(onClick).setNum(1);
		if (playerTurn) enemyTurn(); //switch turns // SOUND - START PLAYER TURN
		else endOfEnemyTurn(); // SOUND - START ENEMY TURN
		yield WaitForSeconds(1.4);
		playerSelectionLight.transform.position = awayFromView;
		updateTurn();
		
	}
	else if (!gameEnded){
		houses[houseNum].GetComponent(onClick).setNum(houses[houseNum].GetComponent(onClick).getNum()+1);
		if(houses[currentHouseNum].transform.childCount > 0){
			params = new Array();
			params.Push(houses[currentHouseNum].transform.GetChild(0));
			params.Push(houses[houseNum]);
//			StartCoroutine("PlaceBall", params);
			yield WaitForSeconds (.4);
			PlaceBall(params);
		}
		/*
		 * tells board status after each seed move
		 */
		var debugArray = new Array();
		for (var j = 0; j < houses.length; j++){
			debugArray.Push(houses[j].GetComponent(onClick).getNum());
		}
		Debug.Log(debugArray);
		Debug.Log("--------------------------------------------");
		currentHouseNum = houseNum;
		StartCoroutine("sowSeeds", currentHouseNum);
//		sowSeeds(houseNum);
	}
}
function enemySowSeeds(enemyPick:int){ // SOUND - ENEMY SELECT, COLOR - ENEMY SELECT

	yield WaitForSeconds (2);
	StartCoroutine("sowSeeds", enemyPick);
}

function PlaceBall (params) { // SOUND - BALL PLACEMENT
	var sphere = params[0];
	var newparent = params[1];
//	counter++;
//	yield WaitForSeconds (2*counter);
	sphere.transform.parent = newparent.transform;
	sphere.transform.position = sphere.transform.parent.position;
	sphere.transform.position.y = 20;
	sphere.transform.position.x += Random.Range(0,3);
	sphere.transform.position.z += Random.Range(0,3);
	sphere.rigidbody.velocity = Vector3(0,0,0);
}
function RemoveBalls(ballTransform: GameObject) {
	for( i = 0; i < ballTransform.transform.childCount; i++) Destroy(ballTransform.transform.GetChild(i).gameObject);
}

function enemyTurn(){
	playerTurn = false;
	validEnemyPick(); //pick territory
	//houses[enemyPick].renderer.material.color = Color.red; //highlight what enemy chose
	Debug.Log("ENEMY PICK: "+ houses[enemyPick]);
	currentHouseNum = enemyPick;
	StartCoroutine("enemySowSeeds", enemyPick);
//	sowSeeds(enemyPick); //enemy moves seeds
	
}

function validEnemyPick(){ //pick a nonzero territory if available
	var validEnemyPicks = new Array();
	for (var i = 6; i < 12; i++){
		if (houses[i].GetComponent(onClick).getNum() > 0) validEnemyPicks.Push(i);
	}
	var temp = Random.Range(0,validEnemyPicks.length);
	if (validEnemyPicks.length > 0)enemyPick = validEnemyPicks[temp];
	if (validEnemyPicks.length == 0) gameEnd(); //if enemy has no moves available, he takes remaining and game ends
}

function endOfEnemyTurn(){
	playerTurn = true;
	var validPlayerMoves = new Array(); //check if player has available moves
	for (var i = 6; i < 12; i++){
		if (houses[i].GetComponent(onClick).getNum() > 0) validPlayerMoves.Push(i);
	}
	if (validPlayerMoves.length == 0) gameEnd(); //if player has no moves, he takes remaining
	
	
	/*
	 * board status after player and enemy turn
	 */
	var debugArray = new Array();
	for (var j = 0; j < houses.length; j++){
		debugArray.Push(houses[j].GetComponent(onClick).getNum());
	}
	Debug.Log(debugArray);
	Debug.Log("Player Territories: "+playerTerritoryCount+"  Enemy Territories: "+enemyTerritoryCount);
	
	canClick = true; //becomes player's turn
}


function gameEnd(){ //game ends, true if player takes remaining territories, false if enemy takes
	gameEnded = true;
	canClick = false;
	var remainingTerritories = 12 - playerTerritoryCount - enemyTerritoryCount;
	if (playerTurn) playerTerritoryCount += remainingTerritories;
	else enemyTerritoryCount += remainingTerritories;
	updateTerritories();
	for (var i = 0; i < 12; i++){
		houses[i].GetComponent(onClick).setNum(0);
	}
	if (playerTerritoryCount>enemyTerritoryCount) playerWins();
	else if (playerTerritoryCount<enemyTerritoryCount) enemyWins();
	else tie();
}

function playerWins(){ // SOUND - GAME WIN, DIALOGUE - GAME WIN
	// todo dialogue
	StartCoroutine("screenFade");
}
 
function enemyWins(){ // SOUND - GAME LOSE, DIALOGUE - GAME LOSE
	// todo dialogue
	StartCoroutine("screenFade");
}

function tie(){ // SOUND - GAME TIE, DIALOGUE - GAME TIE
	// todo dialogue
	
	StartCoroutine("screenFade");
}

function screenFade(){
	var startFadeTime = Time.time;
	while (Time.time - startFadeTime < 5){
		screenFader.color = Color.Lerp(screenFader.color, Color.black, fadeSpeed * Time.deltaTime);
		yield;
	}
	
	// if (restartGame) restartGame();
	// else leaveToMainScene();
}

function updateTerritories(){
	playerTerritoryText.text = "Player\nTerritories: " + playerTerritoryCount;
	enemyTerritoryText.text = "Brother Dead\nTerritories: " + enemyTerritoryCount;
}
function updateTurn(){
	if (playerTurn) {
		playerTerritoryText.color = Color.white;
		enemyTerritoryText.color = Color.gray;
		enemySelectionLight.transform.position = awayFromView;
	}
	else {
		enemyTerritoryText.color = Color.white;
		playerTerritoryText.color = Color.gray;
		enemySelectionLight.transform.position = houses[enemyPick].transform.position;
		enemySelectionLight.transform.position.y += 30;
	}
}