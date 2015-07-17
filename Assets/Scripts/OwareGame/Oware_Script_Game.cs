using UnityEngine;
using System.Collections.Generic;

public class Oware_Script_Game : MonoBehaviour {

	public int playerScore;
	public int opponentScore;
	private int moves;
	public bool isMoving;
	public bool isCollecting;
	public bool isPlayerTurn;
	public int gameOver;
	private string slot;
	private Vector3 playerScoreHouse;
	private Vector3 abovePlayerScoreHouse;
	private Vector3 opponentScoreHouse;
	private Vector3 aboveOpponentScoreHouse;
	public GameObject a1;
	public List<Transform> a1children = new List<Transform> ();
	public GameObject a2;
	public List<Transform> a2children = new List<Transform>();
	public GameObject a3;
	public List<Transform> a3children = new List<Transform>();
	public GameObject a4;
	public List<Transform> a4children = new List<Transform>();
	public GameObject a5;
	public List<Transform> a5children = new List<Transform>();
	public GameObject a6;
	public List<Transform> a6children = new List<Transform>();
	public GameObject b1;
	public List<Transform> b1children = new List<Transform>();
	public GameObject b2;
	public List<Transform> b2children = new List<Transform>();
	public GameObject b3;
	public List<Transform> b3children = new List<Transform>();
	public GameObject b4;
	public List<Transform> b4children = new List<Transform>();
	public GameObject b5;
	public List<Transform> b5children = new List<Transform>();
	public GameObject b6;
	public List<Transform> b6children = new List<Transform>();
	public List<List<Transform>> groups = new List<List<Transform>> ();
	private List<Transform> scoredMarbles;
	private List<Vector3> topLocations = new List<Vector3>();
	private List<Vector3> pitLocations = new List<Vector3>();

	// Use this for initialization
	void Start () {
		playerScore = 0;
		opponentScore = 0;
		moves = 0;
		isMoving = false;
		isCollecting = false;
		isPlayerTurn = true;
		slot = null;
		playerScoreHouse = new Vector3 (-103.0f, 2.0f, 0.0f);
		abovePlayerScoreHouse = new Vector3 (-103.0f, 30.0f, 0.0f);
		opponentScoreHouse = new Vector3 (105.0f, 2.0f, 0.0f);
		aboveOpponentScoreHouse = new Vector3 (105.0f, 30.0f, 0.0f);
		a1children = createArray (a1, a1children);
		groups.Add (a1children);
		a2children = createArray (a2, a2children);
		groups.Add (a2children);
		a3children = createArray (a3, a3children);
		groups.Add (a3children);
		a4children = createArray (a4, a4children);
		groups.Add (a4children);
		a5children = createArray (a5, a5children);
		groups.Add (a5children);
		a6children = createArray (a6, a6children);
		groups.Add (a6children);
		b1children = createArray (b1, b1children);
		groups.Add (b1children);
		b2children = createArray (b2, b2children);
		groups.Add (b2children);
		b3children = createArray (b3, b3children);
		groups.Add (b3children);
		b4children = createArray (b4, b4children);
		groups.Add (b4children);
		b5children = createArray (b5, b5children);
		groups.Add (b5children);
		b6children = createArray (b6, b6children);
		groups.Add (b6children);
		scoredMarbles = new List<Transform> ();
		topLocations = SetTopLocations ();
		pitLocations = SetPitLocations ();
	}
	
	// Update is called once per frame
	void Update () {
		if (PlayerWins ()) {
			gameOver = 1;
		} else if (OpponentWins ()) {
			gameOver = -1;
		} else {
			if (isPlayerTurn) {
				if (isCollecting) {
					MoveCollectedOpponentMarbles (scoredMarbles);
				} else if (!isMoving) {
					if (Input.GetKey (KeyCode.A)) {
						if (a1children.Count > 0) {
							isMoving = true;
							slot = "1";
						}
					} else if (Input.GetKey (KeyCode.S)) {
						if (a2children.Count > 0) {
							isMoving = true;
							slot = "2";
						}
					} else if (Input.GetKey (KeyCode.D)) {
						if (a3children.Count > 0) {
							isMoving = true;
							slot = "3";
						}
					} else if (Input.GetKey (KeyCode.F)) {
						if (a4children.Count > 0) {
							isMoving = true;
							slot = "4";
						}
						;
					} else if (Input.GetKey (KeyCode.G)) {
						if (a5children.Count > 0) {
							isMoving = true;
							slot = "5";
						}
					} else if (Input.GetKey (KeyCode.H)) {
						if (a6children.Count > 0) {
							isMoving = true;
							slot = "6";
						}
					}
					for (int i = 0; i < 12; i++) {
						List<Transform> list = groups [i];
						for (int j = 0; j < list.Count; j++) {
							Transform tran = list [j];
//							MoveDown(tran, pitLocations[i]);
						}
					}
				} else {
					if (slot == "1")
						MoveA1 ();
					else if (slot == "2")
						MoveA2 ();
					else if (slot == "3")
						MoveA3 ();
					else if (slot == "4")
						MoveA4 ();
					else if (slot == "5")
						MoveA5 ();
					else if (slot == "6")
						MoveA6 ();
				}
			} else {
				if (isCollecting) {
					MoveCollectedPlayerMarbles (scoredMarbles);
				} else if (!isMoving) {
					/*
					Oware_Script_DeathAI death = GetComponent<Oware_Script_DeathAI> ();
					List<Transform> nextMove = death.Move ();
					if (nextMove == b1children){
						slot = "7";
						isMoving = true;
					}
					else if (nextMove == b2children){
						slot = "8";
						isMoving = true;
					}
					else if (nextMove == b3children){
						slot = "9";
						isMoving = true;
					}
					else if (nextMove == b4children){
						slot = "10";
						isMoving = true;
					}
					else if (nextMove == b5children){
						slot = "11";
						isMoving = true;
					}
					else if (nextMove == b6children){
						slot = "12";
						isMoving = true;
					}
*/
					if (Input.GetKey (KeyCode.Y)) {
						if (b1children.Count > 0){
							isMoving = true;
							slot = "7";
						}
					}
					else if (Input.GetKey (KeyCode.T)) {
						if (b2children.Count > 0){
							isMoving = true;
							slot = "8";
						}
					}
					else if (Input.GetKey (KeyCode.R)) {
						if (b3children.Count > 0){
							isMoving = true;
							slot = "9";
						}
					}
					else if (Input.GetKey (KeyCode.E)) {
						if (b4children.Count > 0){
							isMoving = true;
							slot = "10";
						}
					}
					else if (Input.GetKey (KeyCode.W)) {
						if (b5children.Count > 0){
							isMoving = true;
							slot = "11";
						}
					}
					else if (Input.GetKey (KeyCode.Q)) {
						if (b6children.Count > 0){
							isMoving = true;
							slot = "12";
						}
					}
					for (int i = 0; i < 12; i++){
						List<Transform> list = groups[i];
						for (int j = 0; j < list.Count; j++){
							Transform tran = list[j];
//							MoveDown(tran, pitLocations[i]);
						}
					}
				}
				else {
					if (slot == "7")
						MoveB1 ();
					else if (slot == "8")
						MoveB2 ();
					else if (slot == "9")
						MoveB3 ();
					else if (slot == "10")
						MoveB4 ();
					else if (slot == "11")
						MoveB5 ();
					else if (slot == "12")
						MoveB6 ();
				}
			}
		}
	}

	private bool PlayerWins(){
		if (playerScore >= 25) {
			return true;
		} else {
			bool win = false;
			int empty = 0;
			for (int i = 6; i < 12; i++){
				if (groups[i].Count == 0){
					empty++;
				}
			}
			if (empty == 6 && !isPlayerTurn)
				win = true;
			return win;
		}
	}

	private bool OpponentWins(){
		if (opponentScore >= 25) {
			return true;
		} else {
			bool win = false;
			int empty = 0;
			for (int i = 0; i < 6; i++){
				if (groups[i].Count == 0){
					empty++;
				}
			}
			if (empty == 6 && isPlayerTurn)
				win = true;
			return win;
		}
	}

	void MoveDown(Transform marble, Vector3 location){
		marble.position = Vector3.Lerp (marble.position, location, 0.001f);
	}

	public void MoveA1 () {
		int size = a1children.Count;
		for (int a = 0; a < size; a++) {
			Transform tran = a1children[a];
			//tran.gameObject.GetComponent<Oware_Script_MarbleBehavior>().SetMovingBool(true);
		}
		if (moves < size * 100) {
			for (int i = 0; i < size; i++) {
				if (moves >= i * 100 && moves < i * 100 + 75){
					int j = i;
					while (j >= 11)
						j -= 12;
					a1children[i].position = Vector3.Lerp(a1children[i].position, topLocations[j+1], 0.05f);
				}
				else if (moves >= i * 100 + 75 && moves < i * 100 + 100){
					int j = i;
					while (j >= 11)
						j -= 12;
					a1children[i].position = Vector3.Lerp(a1children[i].position, pitLocations[j+1], 0.05f);
				}
//				else{
//					MoveDown(a1children[i], a1);
//				}
			}
			moves++;
		}
		else{
			int indexa1 = 0;
			List<Transform> temp = new List<Transform>();
			for (int i = 0; i < size; i++) {
				Transform tran = a1children[i];
				//tran.gameObject.GetComponent<Oware_Script_MarbleBehavior>().SetMovingBool(false);
				int j = i;
				while (j >= 11)
					j -= 12;
				groups[j+1].Add(tran);
				if (groups[j+1] == a1children){
					temp.Add(a1children[i]);
				}
				indexa1 = j+1;
			}
			moves = 0;
			CollectOpponentMarbles(indexa1);
			a1children.Clear();
			int k = temp.Count;
			while (k > 0){
				a1children.Add(temp[k-1]);
				temp.RemoveAt(k-1);
				k--;
			}
			isMoving = false;
			
		}
	}

	public void MoveA2 () {
		int size = a2children.Count;
		for (int a = 0; a < size; a++) {
			Transform tran = a2children[a];
			//tran.gameObject.GetComponent<Oware_Script_MarbleBehavior>().SetMovingBool(true);
		}
		if (moves < size * 100) {
			for (int i = 0; i < size; i++) {
				if (moves >= i * 100 && moves < i * 100 + 75){
					int j = i;
					while (j >= 10)
						j -= 12;
					a2children[i].position = Vector3.Lerp(a2children[i].position, topLocations[j+2], 0.05f);
				}
				else if (moves >= i * 100 + 75 && moves < i * 100 + 100){
					int j = i;
					while (j >= 10)
						j -= 12;
					a2children[i].position = Vector3.Lerp(a2children[i].position, pitLocations[j+2], 0.05f);
				}
//				else{
//					MoveDown(a2children[i], a2);
//				}
			}
			moves++;
		}
		else{
			int indexa2 = 0;
			List<Transform> temp = new List<Transform>();
			for (int i = 0; i < size; i++) {
				Transform tran = a2children[i];
				//tran.gameObject.GetComponent<Oware_Script_MarbleBehavior>().SetMovingBool(false);
				int j = i;
				while (j >= 10)
					j -= 12;
				groups[j+2].Add(tran);
				if (groups[j+2] == a2children){
					temp.Add(a2children[i]);
				}
				indexa2 = j+2;
			}
			moves = 0;
			CollectOpponentMarbles(indexa2);
			a2children.Clear();
			int k = temp.Count;
			while (k > 0){
				a2children.Add(temp[k-1]);
				temp.RemoveAt(k-1);
				k--;
			}
			isMoving = false;
		}
	}

	public void MoveA3 () {
		int size = a3children.Count;
		for (int a = 0; a < size; a++) {
			Transform tran = a3children[a];
			//tran.gameObject.GetComponent<Oware_Script_MarbleBehavior>().SetMovingBool(true);
		}
		if (moves < size * 100) {
			for (int i = 0; i < size; i++) {
				if (moves >= i * 100 && moves < i * 100 + 75){
					int j = i;
					while (j >= 9)
						j -= 12;
					a3children[i].position = Vector3.Lerp(a3children[i].position, topLocations[j+3], 0.05f);
				}
				else if (moves >= i * 100 + 75 && moves < i * 100 + 100){
					int j = i;
					while (j >= 9)
						j -= 12;
					a3children[i].position = Vector3.Lerp(a3children[i].position, pitLocations[j+3], 0.05f);
				}
//				else{
//					MoveDown(a3children[i], a3);
//				}
			}
			moves++;
		}
		else{
			int indexa3 = 0;
			List<Transform> temp = new List<Transform>();
			for (int i = 0; i < size; i++) {
				Transform tran = a3children[i];
				//tran.gameObject.GetComponent<Oware_Script_MarbleBehavior>().SetMovingBool(false);
				int j = i;
				while (j >= 9)
					j -= 12;
				groups[j+3].Add(tran);
				if (groups[j+3] == a3children){
					temp.Add(a3children[i]);
				}
				indexa3 = j+3;
			}
			moves = 0;
			CollectOpponentMarbles(indexa3);
			a3children.Clear();
			int k = temp.Count;
			while (k > 0){
				a3children.Add(temp[k-1]);
				temp.RemoveAt(k-1);
				k--;
			}
			isMoving = false;
		}
	}

	public void MoveA4 () {
		int size = a4children.Count;
		for (int a = 0; a < size; a++) {
			Transform tran = a4children[a];
			//tran.gameObject.GetComponent<Oware_Script_MarbleBehavior>().SetMovingBool(true);
		}
		if (moves < size * 100) {
			for (int i = 0; i < size; i++) {
				if (moves >= i * 100 && moves < i * 100 + 75) {
					int j = i;
					while (j >= 8)
						j -= 12;
					a4children [i].position = Vector3.Lerp (a4children [i].position, topLocations [j + 4], 0.05f);
				}
				else if (moves >= i * 100 + 75 && moves < i * 100 + 100) {
					int j = i;
					while (j >= 8)
						j -= 12;
					a4children [i].position = Vector3.Lerp (a4children [i].position, pitLocations [j + 4], 0.05f);
				}
//				else{
//					MoveDown(a4children[i], a4);
//				}
			}
			moves++;
		} else {
			int indexa4 = 0;
			List<Transform> temp = new List<Transform>();
			for (int i = 0; i < size; i++) {
				Transform tran = a4children [i];
				//tran.gameObject.GetComponent<Oware_Script_MarbleBehavior>().SetMovingBool(false);
				int j = i;
				while (j >= 8)
					j -= 12;
				groups [j+4].Add (tran);
				if (groups[j+4] == a4children){
					temp.Add(a4children[i]);
				}
				indexa4 = j+4;
			}
			moves = 0;
			CollectOpponentMarbles(indexa4);
			a4children.Clear();
			int k = temp.Count;
			while (k > 0){
				a4children.Add(temp[k-1]);
				temp.RemoveAt(k-1);
				k--;
			}
			isMoving = false;
		}
	}

	public void MoveA5 () {
		int size = a5children.Count;
		for (int a = 0; a < size; a++) {
			Transform tran = a5children[a];
			//tran.gameObject.GetComponent<Oware_Script_MarbleBehavior>().SetMovingBool(true);
		}
		if (moves < size * 100) {
			for (int i = 0; i < size; i++) {
				if (moves >= i * 100 && moves < i * 100 + 75) {
					int j = i;
					while (j >= 7)
						j -= 12;
					a5children [i].position = Vector3.Lerp (a5children [i].position, topLocations [j + 5], 0.05f);
				}
				else if (moves >= i * 100 + 75 && moves < i * 100 + 100) {
					int j = i;
					while (j >= 7)
						j -= 12;
					a5children [i].position = Vector3.Lerp (a5children [i].position, pitLocations [j + 5], 0.05f);
				}
//				else{
//					MoveDown(a5children[i], a5);
//				}
			}
			moves++;
		} else {
			int indexa5 = 0;
			List<Transform> temp = new List<Transform>();
			for (int i = 0; i < size; i++) {
				Transform tran = a5children [i];
				//tran.gameObject.GetComponent<Oware_Script_MarbleBehavior>().SetMovingBool(false);
				int j = i;
				while (j >= 7)
					j -= 12;
				groups [j+5].Add (tran);
				if (groups[j+5] == a5children){
					temp.Add(a5children[i]);
				}
				indexa5 = j+5;
			}
			moves = 0;
			CollectOpponentMarbles(indexa5);
			a5children.Clear();
			int k = temp.Count;
			while (k > 0){
				a5children.Add(temp[k-1]);
				temp.RemoveAt(k-1);
				k--;
			}
			isMoving = false;
		}
	}

	public void MoveA6 () {
		int size = a6children.Count;
		for (int a = 0; a < size; a++) {
			Transform tran = a6children[a];
			//tran.gameObject.GetComponent<Oware_Script_MarbleBehavior>().SetMovingBool(true);
		}
		if (moves < size * 100) {
			for (int i = 0; i < size; i++) {
				if (moves >= i * 100 && moves < i * 100 + 75) {
					int j = i;
					while (j >= 6)
						j -= 12;
					a6children [i].position = Vector3.Lerp (a6children [i].position, topLocations [j + 6], 0.05f);
				}
				else if (moves >= i * 100 + 75 && moves < i * 100 + 100) {
					int j = i;
					while (j >= 6)
						j -= 12;
					a6children [i].position = Vector3.Lerp (a6children [i].position, pitLocations [j + 6], 0.05f);
				}
//				else{
//					MoveDown(a6children[i], a6);
//				}
			}
			moves++;
		} else {
			int indexa6 = 0;
			List<Transform> temp = new List<Transform>();
			for (int i = 0; i < size; i++) {
				Transform tran = a6children [i];
				//tran.gameObject.GetComponent<Oware_Script_MarbleBehavior>().SetMovingBool(false);
				int j = i;
				while (j >= 6)
					j -= 12;
				groups [j+6].Add (tran);
				if (groups[j+6] == a6children){
					temp.Add(a6children[i]);
				}
				indexa6 = j+6;
			}
			moves = 0;
			CollectOpponentMarbles(indexa6);
			a6children.Clear();
			int k = temp.Count;
			while (k > 0){
				a6children.Add(temp[k-1]);
				temp.RemoveAt(k-1);
				k--;
			}
			isMoving = false;
		}
	}

	public void MoveB1 () {
		int size = b1children.Count;
		for (int a = 0; a < size; a++) {
			Transform tran = b1children[a];
			//tran.gameObject.GetComponent<Oware_Script_MarbleBehavior>().SetMovingBool(true);
		}
		if (moves < size * 100) {
			for (int i = 0; i < size; i++) {
				if (moves >= i * 100 && moves < i * 100 + 75){
					int j = i;
					while (j >= 5)
						j -= 12;
					b1children[i].position = Vector3.Lerp(b1children[i].position, topLocations[j+7], 0.05f);
				}
				else if (moves >= i * 100 + 75 && moves < i * 100 + 100){
					int j = i;
					while (j >= 5)
						j -= 12;
					b1children[i].position = Vector3.Lerp(b1children[i].position, pitLocations[j+7], 0.05f);
				}
//				else{
//					MoveDown(b1children[i], b1);
//				}
			}
			moves++;
		}
		else{
			int indexb1 = 0;
			List<Transform> temp = new List<Transform>();
			for (int i = 0; i < size; i++) {
				Transform tran = b1children[i];
				//tran.gameObject.GetComponent<Oware_Script_MarbleBehavior>().SetMovingBool(false);
				int j = i;
				while (j >= 5)
					j -= 12;
				groups[j+7].Add(tran);
				if (groups[j+7] == b1children){
					temp.Add(b1children[i]);
				}
				indexb1 = j+7;
			}
			moves = 0;
			CollectPlayerMarbles(indexb1);
			b1children.Clear();
			int k = temp.Count;
			while (k > 0){
				b1children.Add(temp[k-1]);
				temp.RemoveAt(k-1);
				k--;
			}
			isMoving = false;
		}
	}
	
	public void MoveB2 () {
		int size = b2children.Count;
		for (int a = 0; a < size; a++) {
			Transform tran = b2children[a];
			//tran.gameObject.GetComponent<Oware_Script_MarbleBehavior>().SetMovingBool(true);
		}
		if (moves < size * 100) {
			for (int i = 0; i < size; i++) {
				if (moves >= i * 100 && moves < i * 100 + 75){
					int j = i;
					while (j >= 4)
						j -= 12;
					b2children[i].position = Vector3.Lerp(b2children[i].position, topLocations[j+8], 0.05f);
				}
				else if (moves >= i * 100 + 75 && moves < i * 100 + 100){
					int j = i;
					while (j >= 4)
						j -= 12;
					b2children[i].position = Vector3.Lerp(b2children[i].position, pitLocations[j+8], 0.05f);
				}
//				else{
//					MoveDown(b2children[i], b2);
//				}
			}
			moves++;
		}
		else{
			int indexb2 = 0;
			List<Transform> temp = new List<Transform>();
			for (int i = 0; i < size; i++) {
				Transform tran = b2children[i];
				//tran.gameObject.GetComponent<Oware_Script_MarbleBehavior>().SetMovingBool(false);
				int j = i;
				while (j >= 4)
					j -= 12;
				groups[j+8].Add(tran);
				if (groups[j+8] == b2children){
					temp.Add(b2children[i]);
				}
				indexb2 = j+8;
			}
			moves = 0;
			CollectPlayerMarbles(indexb2);
			b2children.Clear();
			int k = temp.Count;
			while (k > 0){
				b2children.Add(temp[k-1]);
				temp.RemoveAt(k-1);
				k--;
			}
			isMoving = false;
		}
	}
	
	public void MoveB3 () {
		int size = b3children.Count;
		for (int a = 0; a < size; a++) {
			Transform tran = b3children[a];
			//tran.gameObject.GetComponent<Oware_Script_MarbleBehavior>().SetMovingBool(true);
		}
		if (moves < size * 100) {
			for (int i = 0; i < size; i++) {
				if (moves >= i * 100 && moves < i * 100 + 75){
					int j = i;
					while (j >= 3)
						j -= 12;
					b3children[i].position = Vector3.Lerp(b3children[i].position, topLocations[j+9], 0.05f);
				}
				else if (moves >= i * 100 + 75 && moves < i * 100 + 100){
					int j = i;
					while (j >= 3)
						j -= 12;
					b3children[i].position = Vector3.Lerp(b3children[i].position, pitLocations[j+9], 0.05f);
				}
//				else{
//					MoveDown(b3children[i], b3);
//				}
			}
			moves++;
		}
		else{
			int indexb3 = 0;
			List<Transform> temp = new List<Transform>();
			for (int i = 0; i < size; i++) {
				Transform tran = b3children[i];
				//tran.gameObject.GetComponent<Oware_Script_MarbleBehavior>().SetMovingBool(false);
				int j = i;
				while (j >= 3)
					j -= 12;
				groups[j+9].Add(tran);
				if (groups[j+9] == b3children){
					temp.Add(b3children[i]);
				}
				indexb3 = j+9;
			}
			moves = 0;
			CollectPlayerMarbles(indexb3);
			b3children.Clear();
			int k = temp.Count;
			while (k > 0){
				b3children.Add(temp[k-1]);
				temp.RemoveAt(k-1);
				k--;
			}
			isMoving = false;
		}
	}
	
	public void MoveB4 () {
		int size = b4children.Count;
		for (int a = 0; a < size; a++) {
			Transform tran = b4children[a];
			//tran.gameObject.GetComponent<Oware_Script_MarbleBehavior>().SetMovingBool(true);
		}
		if (moves < size * 100) {
			for (int i = 0; i < size; i++) {
				if (moves >= i * 100 && moves < i * 100 + 75) {
					int j = i;
					while (j >= 2)
						j -= 12;
					b4children [i].position = Vector3.Lerp (b4children [i].position, topLocations [j + 10], 0.05f);
				}
				else if (moves >= i * 100 + 75 && moves < i * 100 + 100) {
					int j = i;
					while (j >= 2)
						j -= 12;
					b4children [i].position = Vector3.Lerp (b4children [i].position, pitLocations [j + 10], 0.05f);
				}
//				else{
//					MoveDown(b4children[i], b4);
//				}
			}
			moves++;
		} else {
			int indexb4 = 0;
			List<Transform> temp = new List<Transform>();
			for (int i = 0; i < size; i++) {
				Transform tran = b4children [i];
				//tran.gameObject.GetComponent<Oware_Script_MarbleBehavior>().SetMovingBool(false);
				int j = i;
				while (j >= 2)
					j -= 12;
				groups [j+10].Add (tran);
				if (groups[j+10] == b4children){
					temp.Add(b4children[i]);
				}
				indexb4 = j+10;
			}
			moves = 0;
			CollectPlayerMarbles(indexb4);
			b4children.Clear();
			int k = temp.Count;
			while (k > 0){
				b4children.Add(temp[k-1]);
				temp.RemoveAt(k-1);
				k--;
			}
			isMoving = false;
		}
	}
	
	public void MoveB5 () {
		int size = b5children.Count;
		for (int a = 0; a < size; a++) {
			Transform tran = b5children[a];
			//tran.gameObject.GetComponent<Oware_Script_MarbleBehavior>().SetMovingBool(true);
		}
		if (moves < size * 100) {
			for (int i = 0; i < size; i++) {
				if (moves >= i * 100 && moves < i * 100 + 75) {
					int j = i;
					while (j >= 1)
						j -= 12;
					b5children [i].position = Vector3.Lerp (b5children [i].position, topLocations [j+11], 0.05f);
				}
				else if (moves >= i * 100 + 75 && moves < i * 100 + 100) {
					int j = i;
					while (j >= 1)
						j -= 12;
					b5children [i].position = Vector3.Lerp (b5children [i].position, pitLocations [j+11], 0.05f);
				}
//				else{
//					MoveDown(b5children[i], b5);
//				}
			}
			moves++;
		} else {
			int indexb5 = 0;
			List<Transform> temp = new List<Transform>();
			for (int i = 0; i < size; i++) {
				Transform tran = b5children [i];
				//tran.gameObject.GetComponent<Oware_Script_MarbleBehavior>().SetMovingBool(false);
				int j = i;
				while (j >= 1)
					j -= 12;
				groups [j+11].Add (tran);
				if (groups[j+11] == b5children){
					temp.Add(b5children[i]);
				}
				indexb5 = j+11;
			}
			moves = 0;
			CollectPlayerMarbles(indexb5);
			b5children.Clear();
			int k = temp.Count;
			while (k > 0){
				b5children.Add(temp[k-1]);
				temp.RemoveAt(k-1);
				k--;
			}
			isMoving = false;
		}
	}
	
	public void MoveB6 () {
		int size = b6children.Count;
		for (int a = 0; a < size; a++) {
			Transform tran = b6children[a];
			//tran.gameObject.GetComponent<Oware_Script_MarbleBehavior>().SetMovingBool(true);
		}
		if (moves < size * 100) {
			for (int i = 0; i < size; i++) {
				if (moves >= i * 100 && moves < i * 100 + 75) {
					int j = i;
					while (j >= 12)
						j -= 12;
					b6children [i].position = Vector3.Lerp (b6children [i].position, topLocations [j], 0.05f);
				}
				else if (moves >= i * 100 + 75 && moves < i * 100 + 100) {
					int j = i;
					while (j >= 12)
						j -= 12;
					b6children [i].position = Vector3.Lerp (b6children [i].position, pitLocations [j], 0.05f);
				}
//				else{
//					MoveDown(b6children[i], b6);
//				}
			}
			moves++;
		} else {
			int indexb6 = 0;
			List<Transform> temp = new List<Transform>();
			for (int i = 0; i < size; i++) {
				Transform tran = b6children [i];
				//tran.gameObject.GetComponent<Oware_Script_MarbleBehavior>().SetMovingBool(false);
				int j = i;
				while (j >= 12)
					j -= 12;
				groups [j].Add (tran);
				if (groups[j] == b6children){
					temp.Add(b6children[i]);
				}
				indexb6 = j;
			}
			moves = 0;
			CollectPlayerMarbles(indexb6);
			b6children.Clear();
			int k = temp.Count;
			while (k > 0){
				b6children.Add(temp[k-1]);
				temp.RemoveAt(k-1);
				k--;
			}
			isMoving = false;
		}
	}

	private void CollectOpponentMarbles(int indexCOM){
		if (indexCOM != null) {
			bool isCollectable = true;
			List<Transform> collectedMarbles = new List<Transform>();
			while (indexCOM > 5 && indexCOM <= 11 && isCollectable) {
				List<Transform> list = groups [indexCOM];
				int size = list.Count;
				if (size == 2 || size == 3){
					playerScore += size;
					collectedMarbles.AddRange(list);
					list.Clear();
					isCollecting = true;
				}
				else{
					isCollectable = false;
				}
				indexCOM--;
			}
			if (isCollecting){
				scoredMarbles = collectedMarbles;
			}
			else {
				isPlayerTurn = false;
			}
		}
	}

	private void MoveCollectedOpponentMarbles(List<Transform> list){
		int size = list.Count;
		if (moves < size * 100) {
			for (int i = 0; i < size; i++) {
				if (moves >= i * 100 && moves < i * 100 + 75) {
					Vector3 apsh = abovePlayerScoreHouse;
					list [i].position = Vector3.Lerp (list [i].position, abovePlayerScoreHouse, 0.05f);
					Vector3 lp = list[i].position;
					int fla = 0;
				}
				else if (moves >= i * 100 + 75 && moves < i * 100 + 100) {
					list [i].position = Vector3.Lerp (list [i].position, playerScoreHouse, 0.05f);
				}
			}
			moves++;
		} else {
			isPlayerTurn = false;
			isCollecting = false;
			moves = 0;
		}
	}

	private void CollectPlayerMarbles(int indexCPM){
		if (indexCPM != null) {
			bool isCollectable = true;
			List<Transform> collectedMarbles = new List<Transform>();
			while (indexCPM >= 0 && indexCPM <= 5 && isCollectable) {
				List<Transform> list = groups [indexCPM];
				int size = list.Count;
				if (size == 2 || size == 3) {
					opponentScore += size;
					collectedMarbles.AddRange(list);
					list.Clear ();
					isCollecting = true;
				} else{
					isCollectable = false;
				}
				indexCPM--;
			}
			if (isCollecting){
				scoredMarbles = collectedMarbles;
			}
			else {
				isPlayerTurn = true;
			}
		}
	}

	private void MoveCollectedPlayerMarbles(List<Transform> list){
		int size = list.Count;
		if (moves < size * 100) {
			for (int i = 0; i < size; i++) {
				if (moves >= i * 100 && moves < i * 100 + 75) {
					Vector3 aosh = abovePlayerScoreHouse;
					Vector3 lp = list[i].position;
					list [i].position = Vector3.Lerp (list [i].position, aboveOpponentScoreHouse, 0.05f);
					lp = list[i].position;
					int fla = 0;
				}
				else if (moves >= i * 100 + 75 && moves < i * 100 + 100) {
					list[i].position = Vector3.Lerp (list[i].position, opponentScoreHouse, 0.05f);
				}
			}
			moves++;
		} else {
			isPlayerTurn = true;
			isCollecting = false;
			moves = 0;
		}
	}

	private List<Transform> createArray(GameObject obj, List<Transform> children) {
		Transform t = obj.transform;
		Transform[] trans = new Transform[4];
		for (int i = 0; i < t.childCount; i++) {
			trans[i] = t.GetChild(i);
		}
		children.AddRange (trans);
		return children;
	}

	private List<Vector3> SetTopLocations() {
		float x = -75.0f;
		float y = 30.0f;
		float z = -20.0f;
		List<Vector3> locs = new List<Vector3> ();
		for (int i = 0; i < 12; i++) {
			locs.Add (new Vector3(x, y, z));
			if (i >= 0 && i < 5){
				x += 30.0f;
			}
			else if (i == 5){
				z += 40.0f;
			}
			else if (i > 5 && i < 11){
				x -= 30.0f;
			}
			else {
				z -= 40.0f;
			}
		}
		return locs;
	}
	private List<Vector3> SetPitLocations() {
		float x = -75.0f;
		float y = 2.0f;
		float z = -20.0f;
		List<Vector3> locs = new List<Vector3> ();
		for (int i = 0; i < 12; i++) {
			locs.Add (new Vector3(x, y, z));
			if (i >= 0 && i < 5){
				x += 30.0f;
			}
			else if (i == 5){
				z += 40.0f;
			}
			else if (i > 5 && i < 11){
				x -= 30.0f;
			}
			else {
				z -= 40.0f;
			}
		}
		return locs;
	}

	public bool PLayersTurn(){
		return isPlayerTurn;
	}
}