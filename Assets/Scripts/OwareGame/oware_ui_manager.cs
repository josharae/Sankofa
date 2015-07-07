using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;

public class oware_ui_manager : MonoBehaviour {
	
	public List<Text> fields;
	private int pScore;
	private int dScore;
	
	public GameObject PositionHolder;
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
		Score (0);
	}
	
	// Update is called once per frame
	void Update () {
		//Debug.Log (listHolder [0].transform.childCount.ToString());
	}
	
	public void ClickTaken()
	{
		if (TurnText.text == deathTurn) {
			TurnText.text = playerTurn;
		} else {
			TurnText.text = deathTurn;
		}
	}
	
	public void UpdateFields()
	{
		Text field;
		for (int i = 0; i < 12; i++){//runs 12 times, first 6 update player side text fields, last 6 for death side text fields
			//			// Empty Obj > Transform > PlayerSide > PSide# > Text Field > Update = 		Empty Obj > Transform > 
			//			field = PositionHolder.transform.GetChild(0).GetChild(i).GetComponent<Text>;
			//			field.text = listHolder[i].transform.childCount.ToString();
			//			field = PositionHolder.transform.GetChild(1).GetChild(5-i).GetComponent<Text>;
			//			field.text = listHolder[i+6].transform.childCount.ToString();
			
			if(i < 6)
			{
				fields[i].text = listHolder[i].transform.childCount.ToString();
				
				//PositionHolder.transform.GetChild(0).GetChild(i).text = listHolder[i];
				//PositionHolder.transform.GetChild(0).GetChild(i).GetComponent<Text>().text = 
				//field = PositionHolder.transform.GetChild(0).GetChild(i);
				//field.text = listHolder[i];
			} else {
				fields[i].text = listHolder[i].transform.childCount.ToString();
				
				//PositionHolder.transform.GetChild(1).GetChild(6-i).text = listHolder[i+6];
			}
		}
	}
	
	public void Score(int num) //negative number to add to Death, positive to add to Player
	{
		if (num == 2 || num == 3 || num == 0) {
			ScoreBoard.text = "<color=green>" + (pScore + num).ToString() +  "</color>" + " - " + "<color=red>" + dScore.ToString() + "</color>";
		}
		else if (num == -2 || num == -3) {
			ScoreBoard.text = "<color=green>" + pScore.ToString() + "</color>" + " - " + "<color=red>" + (dScore - num).ToString() + "</color>";
		}
	}
}





