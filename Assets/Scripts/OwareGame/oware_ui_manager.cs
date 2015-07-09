using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;

public class oware_ui_manager : MonoBehaviour {
	
	public List<Text> fields;

	private Oware_Script_Game gScript;
	private GameObject PositionHolder;
	public GameObject OwareObject;
	public List<GameObject> listHolder;
	public Text TurnText;
	public Text ScoreBoard;
	private string deathTurn;
	private string playerTurn;

	void Start () {
		for (int i = 0; i < 23; i += 2) {
			listHolder.Add (OwareObject.transform.GetChild(i).gameObject);
		}
		deathTurn = "Death's Turn";
		playerTurn = "Your Turn";
		TurnText.text = deathTurn;
		gScript = OwareObject.GetComponent<Oware_Script_Game> ();
	}

	void Update () {
		//Debug.Log (listHolder [0].transform.childCount.ToString());
		UpdateTurn();
		UpdateFields ();
	}
	
	public void UpdateTurn()
	{
		//Debug.Log (gScript.gameOver.ToString ());
		switch(gScript.gameOver)
		{
		case -1:
			TurnText.text = "You lose...";
			//could also setActive(true) a separate element
			break;
		case 0:
			if (gScript.isPlayerTurn) {
				TurnText.text = playerTurn;
			} else {
				TurnText.text = deathTurn;
			}
			break;
		case 1:
			TurnText.text = "You win!";
			//could also setActive(true) a separate element
			break;
		}
		ScoreBoard.text = "<color=green>" + gScript.playerScore.ToString() +  "</color>" + " - " + "<color=red>" + gScript.opponentScore.ToString() + "</color>";
	}
	
	public void UpdateFields()
	{
		fields [0].text = gScript.a1children.Count.ToString();
		fields [1].text = gScript.a2children.Count.ToString();
		fields [2].text = gScript.a3children.Count.ToString();
		fields [3].text = gScript.a4children.Count.ToString();
		fields [4].text = gScript.a5children.Count.ToString();
		fields [5].text = gScript.a6children.Count.ToString();
		fields [6].text = gScript.b1children.Count.ToString();
		fields [7].text = gScript.b2children.Count.ToString();
		fields [8].text = gScript.b3children.Count.ToString();
		fields [9].text = gScript.b4children.Count.ToString();
		fields [10].text = gScript.b5children.Count.ToString();
		fields [11].text = gScript.b6children.Count.ToString();
	}
}





