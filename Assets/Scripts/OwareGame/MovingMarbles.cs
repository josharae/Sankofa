using UnityEngine;
using System.Collections.Generic;

public class MovingMarbles : MonoBehaviour {

	private int moves;
	private bool isMoving;
	private string slot;
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
	private List<Vector3> topLocations = new List<Vector3>();
	private List<Vector3> pitLocations = new List<Vector3>();

	// Use this for initialization
	void Start () {
		moves = 0;
		isMoving = false;
		slot = null;
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
		topLocations = SetTopLocations ();
		pitLocations = SetPitLocations ();
	}
	
	// Update is called once per frame
	void Update () {
		if (!isMoving) {
			if (Input.GetKey (KeyCode.A)) {
				isMoving = true;
				slot = "1";
			}
			else if (Input.GetKey (KeyCode.S)) {
				isMoving = true;
				slot = "2";
			}
			else if (Input.GetKey (KeyCode.D)) {
				isMoving = true;
				slot = "3";
			}
			else if (Input.GetKey (KeyCode.F)) {
				isMoving = true;
				slot = "4";
			}
			else if (Input.GetKey (KeyCode.G)) {
				isMoving = true;
				slot = "5";
			}
			else if (Input.GetKey (KeyCode.H)) {
				isMoving = true;
				slot = "6";
			}
		} else {
			if (slot == "1")
				MoveA1();
			else if (slot == "2")
				MoveA2();
			else if (slot == "3")
				MoveA3();
			else if (slot == "4")
				MoveA4();
			else if (slot == "5")
				MoveA5();
			else if (slot == "6")
				MoveA6();

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
			for (int i = 0; i < size; i++) {
				Transform tran = a1children[i];
				if (i < 11){
					groups[i+1].Add(tran);
				}
				else if (i >= 11 && i < 23)  {
					groups[i-11].Add(tran);
				}
				else {
					groups[i-23].Add(tran);
			    }
			}
			a1children.Clear();
			moves = 0;
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
			for (int i = 0; i < size; i++) {
				Transform tran = a2children[i];
				if (i < 10){
					groups[i+2].Add(tran);
				}
				else if (i >= 10 && i < 22)  {
					groups[i-10].Add(tran);
				}
				else {
					groups[i-22].Add(tran);
				}
			}
			a2children.Clear();
			moves = 0;
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
			for (int i = 0; i < size; i++) {
				Transform tran = a3children[i];
				if (i < 9){
					groups[i+3].Add(tran);
				}
				else if (i >= 9 && i < 21)  {
					groups[i-9].Add(tran);
				}
				else {
					groups[i-21].Add(tran);
				}
			}
			a3children.Clear();
			moves = 0;
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
			for (int i = 0; i < size; i++) {
				Transform tran = a4children [i];
				if (i < 8) {
					groups [i + 4].Add (tran);
				} else if (i >= 4 && i < 20) {
					groups [i - 8].Add (tran);
				} else {
					groups [i - 20].Add (tran);
				}
			}
			a4children.Clear();
			moves = 0;
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
			for (int i = 0; i < size; i++) {
				Transform tran = a5children [i];
				if (i < 7) {
					groups [i + 5].Add (tran);
				} else if (i >= 7 && i < 19) {
					groups [i - 7].Add (tran);
				} else {
					groups [i - 19].Add (tran);
				}
			}
			a5children.Clear();
			moves = 0;
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
						a6children [i].position = Vector3.Lerp (a6children [i].position, pitLocations [i - 6], 0.05f);
					} else {
						a6children [i].position = Vector3.Lerp (a6children [i].position, pitLocations [i - 18], 0.05f);
					}
				}
			}
			moves++;
		} else {
			for (int i = 0; i < size; i++) {
				Transform tran = a6children [i];
				if (i < 6) {
					groups [i + 6].Add (tran);
				} else if (i >= 6 && i < 18) {
					groups [i - 6].Add (tran);
				} else {
					groups [i - 18].Add (tran);
				}
			}
			a6children.Clear();
			moves = 0;
			isMoving = false;
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