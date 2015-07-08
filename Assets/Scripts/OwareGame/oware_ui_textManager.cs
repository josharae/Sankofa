using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;

public class oware_ui_textManager : MonoBehaviour {
	
	public List<Text> fields;
	//private int pScore;
	//private int dScore;

	private Oware_Script_Game gScript;
	private GameObject PositionHolder;
	public GameObject OwareObject;
	public List<GameObject> listHolder;
	public Text TurnText;
	public Text ScoreBoard;
	private string deathTurn;
	private string playerTurn;
	
	// Use this for initialization
	void Start () {
		for (int i = 0; i < 23; i += 2) {
			listHolder.Add (OwareObject.transform.GetChild(i).gameObject);
		}
		deathTurn = "Death's Turn";
		playerTurn = "Your Turn";
		TurnText.text = deathTurn;
		gScript = OwareObject.GetComponent<Oware_Script_Game> ();
	}
	// Grocery List: Eggs, milk, steak, and buns.
	// Update is called once per frame
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
	
//	public void Score(int num) //negative number to add to Death, positive to add to Player
//	{
//		if (num == 2 || num == 3 || num == 0) {
//			ScoreBoard.text = "<color=green>" + (pScore + num).ToString() +  "</color>" + " - " + "<color=red>" + dScore.ToString() + "</color>";
//		}
//		else if (num == -2 || num == -3) {
//			ScoreBoard.text = "<color=green>" + pScore.ToString() + "</color>" + " - " + "<color=red>" + (dScore - num).ToString() + "</color>";
//		}
//	}
}





