﻿using UnityEngine;
using System.Collections.Generic;

public class Oware_Script_Game : MonoBehaviour {

	private int playerScore;
	private int opponentScore;
	private int moves;
	private bool isMoving;
	private bool isCollecting;
	private bool isPlayerTurn;
	private string slot;
	private Vector3 playerScoreHouse;
	private Vector3 abovePlayerScoreHouse;
	private Vector3 opponentScoreHouse;
	private Vector3 aboveOpponentScoreHouse;
	public GameObject a1;
	private List<Transform> a1children = new List<Transform> ();
	public GameObject a2;
	private List<Transform> a2children = new List<Transform>();
	public GameObject a3;
	private List<Transform> a3children = new List<Transform>();
	public GameObject a4;
	private List<Transform> a4children = new List<Transform>();
	public GameObject a5;
	private List<Transform> a5children = new List<Transform>();
	public GameObject a6;
	private List<Transform> a6children = new List<Transform>();
	public GameObject b1;
	private List<Transform> b1children = new List<Transform>();
	public GameObject b2;
	private List<Transform> b2children = new List<Transform>();
	public GameObject b3;
	private List<Transform> b3children = new List<Transform>();
	public GameObject b4;
	private List<Transform> b4children = new List<Transform>();
	public GameObject b5;
	private List<Transform> b5children = new List<Transform>();
	public GameObject b6;
	private List<Transform> b6children = new List<Transform>();
	private List<List<Transform>> groups = new List<List<Transform>> ();
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
		isPlayerTurn = false;
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
		if (isPlayerTurn) {
			if (isCollecting){
				MoveCollectedOpponentMarbles(scoredMarbles);
			}
			else if (!isMoving) {
				if (Input.GetKey (KeyCode.A)) {
					isMoving = true;
					slot = "1";
				} else if (Input.GetKey (KeyCode.S)) {
					isMoving = true;
					slot = "2";
				} else if (Input.GetKey (KeyCode.D)) {
					isMoving = true;
					slot = "3";
				} else if (Input.GetKey (KeyCode.F)) {
					isMoving = true;
					slot = "4";
				} else if (Input.GetKey (KeyCode.G)) {
					isMoving = true;
					slot = "5";
				} else if (Input.GetKey (KeyCode.H)) {
					isMoving = true;
					slot = "6";
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
			if (isCollecting){
				MoveCollectedPlayerMarbles(scoredMarbles);
			}
			else if (!isMoving) {
				if (Input.GetKey (KeyCode.Y)) {
					isMoving = true;
					slot = "7";
				}
				else if (Input.GetKey (KeyCode.T)) {
					isMoving = true;
					slot = "8";
				}
				else if (Input.GetKey (KeyCode.R)) {
					isMoving = true;
					slot = "9";
				}
				else if (Input.GetKey (KeyCode.E)) {
					isMoving = true;
					slot = "10";
				}
				else if (Input.GetKey (KeyCode.W)) {
					isMoving = true;
					slot = "11";
				}
				else if (Input.GetKey (KeyCode.Q)) {
					isMoving = true;
					slot = "12";
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

	void MoveA1 () {
		int size = a1children.Count;
		if (moves < size * 100) {
			for (int i = 0; i < size; i++) {
				if (moves >= i * 100 && moves < i * 100 + 75){
					if (i < 11){
						a1children[i].position = Vector3.Lerp(a1children[i].position, topLocations[i+1], 0.05f);
					}
					else if (i >= 11 && i < 23) {
						a1children[i].position = Vector3.Lerp(a1children[i].position, topLocations[i-11], 0.05f);
					}
					else {
						a1children[i].position = Vector3.Lerp(a1children[i].position, topLocations[i-23], 0.05f);
					}
				}
				else if (moves >= i * 100 + 75 && moves < i * 100 + 100){
					if (i < 11){
						a1children[i].position = Vector3.Lerp(a1children[i].position, pitLocations[i+1], 0.05f);
					}
					else if (i >= 11 && i < 23) {
						a1children[i].position = Vector3.Lerp(a1children[i].position, pitLocations[i-11], 0.05f);
					}
					else {
						a1children[i].position = Vector3.Lerp(a1children[i].position, pitLocations[i-23], 0.05f);
					}
				}
			}
			moves++;
		}
		else{
			int indexa1 = 0;
			for (int i = 0; i < size; i++) {
				Transform tran = a1children[i];
				if (i < 11){
					groups[i+1].Add(tran);
					indexa1 = i+1;
				}
				else if (i >= 11 && i < 23)  {
					groups[i-11].Add(tran);
					indexa1 = i-11;
				}
				else {
					groups[i-23].Add(tran);
					indexa1 = i-23;
			    }
			}
			moves = 0;
			CollectOpponentMarbles(indexa1);
			a1children.Clear();
			isMoving = false;
			
		}
	}

	void MoveA2 () {
		int size = a2children.Count;
		if (moves < size * 100) {
			for (int i = 0; i < size; i++) {
				if (moves >= i * 100 && moves < i * 100 + 75){
					if (i < 10){
						a2children[i].position = Vector3.Lerp(a2children[i].position, topLocations[i+2], 0.05f);
					}
					else if (i >= 10 && i < 22) {
						a2children[i].position = Vector3.Lerp(a2children[i].position, topLocations[i-10], 0.05f);
					}
					else {
						a2children[i].position = Vector3.Lerp(a2children[i].position, topLocations[i-22], 0.05f);
					}
				}
				else if (moves >= i * 100 + 75 && moves < i * 100 + 100){
					if (i < 10){
						a2children[i].position = Vector3.Lerp(a2children[i].position, pitLocations[i+2], 0.05f);
					}
					else if (i >= 10 && i < 22) {
						a2children[i].position = Vector3.Lerp(a2children[i].position, pitLocations[i-10], 0.05f);
					}
					else {
						a2children[i].position = Vector3.Lerp(a2children[i].position, pitLocations[i-22], 0.05f);
					}
				}
			}
			moves++;
		}
		else{
			int indexa2 = 0;
			for (int i = 0; i < size; i++) {
				Transform tran = a2children[i];
				if (i < 10){
					groups[i+2].Add(tran);
					indexa2 = i+2;
				}
				else if (i >= 10 && i < 22)  {
					groups[i-10].Add(tran);
					indexa2 = i-10;
				}
				else {
					groups[i-22].Add(tran);
					indexa2 = i-22;
				}
			}
			moves = 0;
			CollectOpponentMarbles(indexa2);
			a2children.Clear();
			isMoving = false;
		}
	}

	void MoveA3 () {
		int size = a3children.Count;
		if (moves < size * 100) {
			for (int i = 0; i < size; i++) {
				if (moves >= i * 100 && moves < i * 100 + 75){
					if (i < 9){
						a3children[i].position = Vector3.Lerp(a3children[i].position, topLocations[i+3], 0.05f);
					}
					else if (i >= 9 && i < 21) {
						a3children[i].position = Vector3.Lerp(a3children[i].position, topLocations[i-9], 0.05f);
					}
					else {
						a3children[i].position = Vector3.Lerp(a3children[i].position, topLocations[i-21], 0.05f);
					}
				}
				else if (moves >= i * 100 + 75 && moves < i * 100 + 100){
					if (i < 9){
						a3children[i].position = Vector3.Lerp(a3children[i].position, pitLocations[i+3], 0.05f);
					}
					else if (i >= 9 && i < 21) {
						a3children[i].position = Vector3.Lerp(a3children[i].position, pitLocations[i-9], 0.05f);
					}
					else {
						a3children[i].position = Vector3.Lerp(a3children[i].position, pitLocations[i-21], 0.05f);
					}
				}
			}
			moves++;
		}
		else{
			int indexa3 = 0;
			for (int i = 0; i < size; i++) {
				Transform tran = a3children[i];
				if (i < 9){
					groups[i+3].Add(tran);
					indexa3 = i+3;
				}
				else if (i >= 9 && i < 21)  {
					groups[i-9].Add(tran);
					indexa3 = i-9;
				}
				else {
					groups[i-21].Add(tran);
					indexa3 = i-21;
				}
			}
			moves = 0;
			CollectOpponentMarbles(indexa3);
			a3children.Clear();
			isMoving = false;
		}
	}

	void MoveA4 () {
		int size = a4children.Count;
		if (moves < size * 100) {
			for (int i = 0; i < size; i++) {
				if (moves >= i * 100 && moves < i * 100 + 75) {
					if (i < 8) {
						a4children [i].position = Vector3.Lerp (a4children [i].position, topLocations [i + 4], 0.05f);
					} else if (i >= 8 && i < 20) {
						a4children [i].position = Vector3.Lerp (a4children [i].position, topLocations [i - 8], 0.05f);
					} else {
						a4children [i].position = Vector3.Lerp (a4children [i].position, topLocations [i - 20], 0.05f);
					}
				}
				else if (moves >= i * 100 + 75 && moves < i * 100 + 100) {
					if (i < 8) {
						a4children [i].position = Vector3.Lerp (a4children [i].position, pitLocations [i + 4], 0.05f);
					} else if (i >= 8 && i < 20) {
						a4children [i].position = Vector3.Lerp (a4children [i].position, pitLocations [i - 8], 0.05f);
					} else {
						a4children [i].position = Vector3.Lerp (a4children [i].position, pitLocations [i - 20], 0.05f);
					}
				}
			}
			moves++;
		} else {
			int indexa4 = 0;
			for (int i = 0; i < size; i++) {
				Transform tran = a4children [i];
				if (i < 8) {
					groups [i + 4].Add (tran);
					indexa4 = i+4;
				} else if (i >= 4 && i < 20) {
					groups [i - 8].Add (tran);
					indexa4 = i-8;
				} else {
					groups [i - 20].Add (tran);
					indexa4 = i-20;
				}
			}
			moves = 0;
			CollectOpponentMarbles(indexa4);
			a4children.Clear();
			isMoving = false;
		}
	}

	void MoveA5 () {
		int size = a5children.Count;
		if (moves < size * 100) {
			for (int i = 0; i < size; i++) {
				if (moves >= i * 100 && moves < i * 100 + 75) {
					if (i < 7) {
						a5children [i].position = Vector3.Lerp (a5children [i].position, topLocations [i + 5], 0.05f);
					} else if (i >= 7 && i < 19) {
						a5children [i].position = Vector3.Lerp (a5children [i].position, topLocations [i - 7], 0.05f);
					} else {
						a5children [i].position = Vector3.Lerp (a5children [i].position, topLocations [i - 19], 0.05f);
					}
				}
				else if (moves >= i * 100 + 75 && moves < i * 100 + 100) {
					if (i < 7) {
						a5children [i].position = Vector3.Lerp (a5children [i].position, pitLocations [i + 5], 0.05f);
					} else if (i >= 7 && i < 19) {
						a5children [i].position = Vector3.Lerp (a5children [i].position, pitLocations [i - 7], 0.05f);
					} else {
						a5children [i].position = Vector3.Lerp (a5children [i].position, pitLocations [i - 19], 0.05f);
					}
				}
			}
			moves++;
		} else {
			int indexa5 = 0;
			for (int i = 0; i < size; i++) {
				Transform tran = a5children [i];
				if (i < 7) {
					groups [i + 5].Add (tran);
					indexa5 = i+5;
				} else if (i >= 7 && i < 19) {
					groups [i - 7].Add (tran);
					indexa5 = i-7;
				} else {
					groups [i - 19].Add (tran);
					indexa5 = i-19;
				}
			}
			moves = 0;
			CollectOpponentMarbles(indexa5);
			a5children.Clear();
			isMoving = false;
		}
	}

	void MoveA6 () {
		int size = a6children.Count;
		if (moves < size * 100) {
			for (int i = 0; i < size; i++) {
				if (moves >= i * 100 && moves < i * 100 + 75) {
					if (i < 6) {
						a6children [i].position = Vector3.Lerp (a6children [i].position, topLocations [i + 6], 0.05f);
					} else if (i >= 6 && i < 18) {
						a6children [i].position = Vector3.Lerp (a6children [i].position, topLocations [i - 6], 0.05f);
					} else {
						a6children [i].position = Vector3.Lerp (a6children [i].position, topLocations [i - 18], 0.05f);
					}
				}
				else if (moves >= i * 100 + 75 && moves < i * 100 + 100) {
					if (i < 6) {
						a6children [i].position = Vector3.Lerp (a6children [i].position, pitLocations [i + 6], 0.05f);
					} else if (i >= 6 && i < 18) {
						a6children [i].position = Vector3.Lerp (a6children [i].position, pitLocations [i - 5], 0.05f);
					} else {
						a6children [i].position = Vector3.Lerp (a6children [i].position, pitLocations [i - 18], 0.05f);
					}
				}
			}
			moves++;
		} else {
			int indexa6 = 0;
			for (int i = 0; i < size; i++) {
				Transform tran = a6children [i];
				if (i < 6) {
					groups [i + 6].Add (tran);
					indexa6 = i+6;
				} else if (i >= 6 && i < 18) {
					groups [i - 6].Add (tran);
					indexa6 = i-6;
				} else {
					groups [i - 18].Add (tran);
					indexa6 = i-18;
				}
			}
			moves = 0;
			CollectOpponentMarbles(indexa6);
			a6children.Clear();
			isMoving = false;
		}
	}

	void MoveB1 () {
		int size = b1children.Count;
		if (moves < size * 100) {
			for (int i = 0; i < size; i++) {
				if (moves >= i * 100 && moves < i * 100 + 75){
					if (i < 5){
						b1children[i].position = Vector3.Lerp(b1children[i].position, topLocations[i+7], 0.05f);
					}
					else if (i >= 5 && i < 17) {
						b1children[i].position = Vector3.Lerp(b1children[i].position, topLocations[i-5], 0.05f);
					}
					else {
						b1children[i].position = Vector3.Lerp(b1children[i].position, topLocations[i-17], 0.05f);
					}
				}
				else if (moves >= i * 100 + 75 && moves < i * 100 + 100){
					if (i < 5){
						b1children[i].position = Vector3.Lerp(b1children[i].position, pitLocations[i+7], 0.05f);
					}
					else if (i >= 5 && i < 17) {
						b1children[i].position = Vector3.Lerp(b1children[i].position, pitLocations[i-5], 0.05f);
					}
					else {
						b1children[i].position = Vector3.Lerp(b1children[i].position, pitLocations[i-17], 0.05f);
					}
				}
			}
			moves++;
		}
		else{
			int indexb1 = 0;
			for (int i = 0; i < size; i++) {
				Transform tran = b1children[i];
				if (i < 5){
					groups[i+7].Add(tran);
					indexb1 = i+7;
				}
				else if (i >= 7 && i < 17)  {
					groups[i-5].Add(tran);
					indexb1 = i-5;
				}
				else {
					groups[i-17].Add(tran);
					indexb1 = i-17;
				}
			}
			moves = 0;
			CollectPlayerMarbles(indexb1);
			b1children.Clear();
			isMoving = false;
		}
	}
	
	void MoveB2 () {
		int size = b2children.Count;
		if (moves < size * 100) {
			for (int i = 0; i < size; i++) {
				if (moves >= i * 100 && moves < i * 100 + 75){
					if (i < 4){
						b2children[i].position = Vector3.Lerp(b2children[i].position, topLocations[i+8], 0.05f);
					}
					else if (i >= 4 && i < 16) {
						b2children[i].position = Vector3.Lerp(b2children[i].position, topLocations[i-4], 0.05f);
					}
					else {
						b2children[i].position = Vector3.Lerp(b2children[i].position, topLocations[i-16], 0.05f);
					}
				}
				else if (moves >= i * 100 + 75 && moves < i * 100 + 100){
					if (i < 4){
						b2children[i].position = Vector3.Lerp(b2children[i].position, pitLocations[i+8], 0.05f);
					}
					else if (i >= 4 && i < 16) {
						b2children[i].position = Vector3.Lerp(b2children[i].position, pitLocations[i-4], 0.05f);
					}
					else {
						b2children[i].position = Vector3.Lerp(b2children[i].position, pitLocations[i-16], 0.05f);
					}
				}
			}
			moves++;
		}
		else{
			int indexb2 = 0;
			for (int i = 0; i < size; i++) {
				Transform tran = b2children[i];
				if (i < 4){
					groups[i+8].Add(tran);
					indexb2 = i+8;
				}
				else if (i >= 4 && i < 16)  {
					groups[i-4].Add(tran);
					indexb2 = i-4;
				}
				else {
					groups[i-16].Add(tran);
					indexb2 = i-16;
				}
			}
			moves = 0;
			CollectPlayerMarbles(indexb2);
			b2children.Clear();
			isMoving = false;
		}
	}
	
	void MoveB3 () {
		int size = b3children.Count;
		if (moves < size * 100) {
			for (int i = 0; i < size; i++) {
				if (moves >= i * 100 && moves < i * 100 + 75){
					if (i < 3){
						b3children[i].position = Vector3.Lerp(b3children[i].position, topLocations[i+9], 0.05f);
					}
					else if (i >= 3 && i < 15) {
						b3children[i].position = Vector3.Lerp(b3children[i].position, topLocations[i-3], 0.05f);
					}
					else {
						b3children[i].position = Vector3.Lerp(b3children[i].position, topLocations[i-15], 0.05f);
					}
				}
				else if (moves >= i * 100 + 75 && moves < i * 100 + 100){
					if (i < 3){
						b3children[i].position = Vector3.Lerp(b3children[i].position, pitLocations[i+9], 0.05f);
					}
					else if (i >= 3 && i < 15) {
						b3children[i].position = Vector3.Lerp(b3children[i].position, pitLocations[i-3], 0.05f);
					}
					else {
						b3children[i].position = Vector3.Lerp(b3children[i].position, pitLocations[i-15], 0.05f);
					}
				}
			}
			moves++;
		}
		else{
			int indexb3 = 0;
			for (int i = 0; i < size; i++) {
				Transform tran = b3children[i];
				if (i < 3){
					groups[i+9].Add(tran);
					indexb3 = i+9;
				}
				else if (i >= 3 && i < 15)  {
					groups[i-3].Add(tran);
					indexb3 = i-3;
				}
				else {
					groups[i-15].Add(tran);
					indexb3 = i-15;
				}
			}
			moves = 0;
			CollectPlayerMarbles(indexb3);
			b3children.Clear();
			isMoving = false;
		}
	}
	
	void MoveB4 () {
		int size = b4children.Count;
		if (moves < size * 100) {
			for (int i = 0; i < size; i++) {
				if (moves >= i * 100 && moves < i * 100 + 75) {
					if (i < 2) {
						b4children [i].position = Vector3.Lerp (b4children [i].position, topLocations [i + 10], 0.05f);
					} else if (i >= 2 && i < 14) {
						b4children [i].position = Vector3.Lerp (b4children [i].position, topLocations [i - 2], 0.05f);
					} else {
						b4children [i].position = Vector3.Lerp (b4children [i].position, topLocations [i - 14], 0.05f);
					}
				}
				else if (moves >= i * 100 + 75 && moves < i * 100 + 100) {
					if (i < 2) {
						b4children [i].position = Vector3.Lerp (b4children [i].position, pitLocations [i + 10], 0.05f);
					} else if (i >= 2 && i < 14) {
						b4children [i].position = Vector3.Lerp (b4children [i].position, pitLocations [i - 2], 0.05f);
					} else {
						b4children [i].position = Vector3.Lerp (b4children [i].position, pitLocations [i - 14], 0.05f);
					}
				}
			}
			moves++;
		} else {
			int indexb4 = 0;
			for (int i = 0; i < size; i++) {
				Transform tran = b4children [i];
				if (i < 2) {
					groups [i + 10].Add (tran);
					indexb4 = i+10;
				} else if (i >= 2 && i < 14) {
					groups [i - 2].Add (tran);
					indexb4 = i-2;
				} else {
					groups [i - 14].Add (tran);
					indexb4 = i-14;
				}
			}
			moves = 0;
			CollectPlayerMarbles(indexb4);
			b4children.Clear();
			isMoving = false;
		}
	}
	
	void MoveB5 () {
		int size = b5children.Count;
		if (moves < size * 100) {
			for (int i = 0; i < size; i++) {
				if (moves >= i * 100 && moves < i * 100 + 75) {
					if (i < 1) {
						b5children [i].position = Vector3.Lerp (b5children [i].position, topLocations [i + 11], 0.05f);
					} else if (i >= 1 && i < 13) {
						b5children [i].position = Vector3.Lerp (b5children [i].position, topLocations [i - 1], 0.05f);
					} else {
						b5children [i].position = Vector3.Lerp (b5children [i].position, topLocations [i - 13], 0.05f);
					}
				}
				else if (moves >= i * 100 + 75 && moves < i * 100 + 100) {
					if (i < 1) {
						b5children [i].position = Vector3.Lerp (b5children [i].position, pitLocations [i + 11], 0.05f);
					} else if (i >= 1 && i < 13) {
						b5children [i].position = Vector3.Lerp (b5children [i].position, pitLocations [i - 1], 0.05f);
					} else {
						b5children [i].position = Vector3.Lerp (b5children [i].position, pitLocations [i - 13], 0.05f);
					}
				}
			}
			moves++;
		} else {
			int indexb5 = 0;
			for (int i = 0; i < size; i++) {
				Transform tran = b5children [i];
				if (i < 1) {
					groups [i + 11].Add (tran);
					indexb5 = i+11;
				} else if (i >= 1 && i < 13) {
					groups [i - 1].Add (tran);
					indexb5 = i-1;
				} else {
					groups [i - 13].Add (tran);
					indexb5 = i-13;
				}
			}
			moves = 0;
			CollectPlayerMarbles(indexb5);
			b5children.Clear();
			isMoving = false;
		}
	}
	
	void MoveB6 () {
		int size = b6children.Count;
		if (moves < size * 100) {
			for (int i = 0; i < size; i++) {
				if (moves >= i * 100 && moves < i * 100 + 75) {
					if (i < 12) {
						b6children [i].position = Vector3.Lerp (b6children [i].position, topLocations [i], 0.05f);
					} else if (i >= 12 && i < 24) {
						b6children [i].position = Vector3.Lerp (b6children [i].position, topLocations [i - 12], 0.05f);
					} else {
						b6children [i].position = Vector3.Lerp (b6children [i].position, topLocations [i - 24], 0.05f);
					}
				}
				else if (moves >= i * 100 + 75 && moves < i * 100 + 100) {
					if (i < 12) {
						b6children [i].position = Vector3.Lerp (b6children [i].position, pitLocations [i], 0.05f);
					} else if (i >= 12 && i < 24) {
						b6children [i].position = Vector3.Lerp (b6children [i].position, pitLocations [i - 12], 0.05f);
					} else {
						b6children [i].position = Vector3.Lerp (b6children [i].position, pitLocations [i - 24], 0.05f);
					}
				}
			}
			moves++;
		} else {
			int indexb6 = 0;
			for (int i = 0; i < size; i++) {
				Transform tran = b6children [i];
				if (i < 12) {
					groups [i].Add (tran);
					indexb6 = i;
				} else if (i >= 12 && i < 24) {
					groups [i - 12].Add (tran);
					indexb6 = i-12;
				} else {
					groups [i - 24].Add (tran);
					indexb6 = i-24;
				}
			}
			moves = 0;
			CollectPlayerMarbles(indexb6);
			b6children.Clear();
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
}