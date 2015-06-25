using UnityEngine;
using System.Collections;

public class MovingMarbles : MonoBehaviour {

	private int moves;
	private bool isMoving;
	private string slot;
	public GameObject a1;
	private Transform[] a1children = new Transform[4];
	public GameObject a2;
	private Transform[] a2children = new Transform[4];
	public GameObject a3;
	private Transform[] a3children = new Transform[4];
	public GameObject a4;
	private Transform[] a4children = new Transform[4];
	public GameObject a5;
	private Transform[] a5children = new Transform[4];
	public GameObject a6;
	private Transform[] a6children = new Transform[4];
	public GameObject b1;
	private Transform[] b1children = new Transform[4];
	public GameObject b2;
	private Transform[] b2children = new Transform[4];
	public GameObject b3;
	private Transform[] b3children = new Transform[4];
	public GameObject b4;
	private Transform[] b4children = new Transform[4];
	public GameObject b5;
	private Transform[] b5children = new Transform[4];
	public GameObject b6;
	private Transform[] b6children = new Transform[4];

	// Use this for initialization
	void Start () {
		moves = 0;
		isMoving = false;
		slot = null;
		a1children = createArray (a1, a1children);
		a2children = createArray (a2, a2children);
		a3children = createArray (a3, a3children);
		a4children = createArray (a4, a4children);
		a5children = createArray (a5, a5children);
		a6children = createArray (a6, a6children);
		b1children = createArray (b1, b1children);
		b2children = createArray (b2, b2children);
		b3children = createArray (b3, b3children);
		b4children = createArray (b4, b4children);
		b5children = createArray (b5, b5children);
		b6children = createArray (b6, b6children);
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
//			else if (slot == "2")
//				MoveA2();
//			else if (slot == "3")
//				MoveA3();
//			else if (slot == "4")
//				MoveA4();
//			else if (slot == "5")
//				MoveA5();
//			else if (slot == "6")
//				MoveA6();

		}

	}

	void MoveA1 () {
//		if (moves < 50) {
//			Vector3 target = new Vector3 (-42.0f, 25.0f, -10.0f);
//			for (int i = 0; i < a1children.Length; i++) {
//				a1children [i].position = Vector3.Lerp (a1children [i].position, target, 0.05f);
//			}
//			moves++;
//		} else 
		if (moves < 400) {
			for (int i = 0; i < a1children.Length; i++) {
				if (i == 0 && moves >= 0 && moves < 100){
					Vector3 target = new Vector3 (-30.0f, 25.0f, -11.0f);
					a1children [i].position = Vector3.Lerp (a1children [i].position, target, 0.05f);
				}
				else if (i == 1 && moves >= 100 && moves < 200){
					Vector3 target = new Vector3 (-10.0f, 25.0f, -11.0f);
					a1children [i].position = Vector3.Lerp (a1children [i].position, target, 0.05f);
				}
				else if (i == 2 && moves >= 200 && moves < 300){
					Vector3 target = new Vector3 (10.0f, 25.0f, -11.0f);
					a1children [i].position = Vector3.Lerp (a1children [i].position, target, 0.05f);
				}
				else if (i == 3 && moves >= 300 && moves < 400) {
					Vector3 target = new Vector3 (30.0f, 25.0f, -11.0f);
					a1children [i].position = Vector3.Lerp (a1children [i].position, target, 0.05f);
				}
			}
			moves++;
		}
		else{
			moves = 0;
			isMoving = false;
		}
	}

	private Transform[] createArray(GameObject obj, Transform[] children) {
		Transform t = obj.transform;
		for (int i = 0; i < t.childCount; i++) {
			children[i] = t.GetChild(i);
		}
		return children;
	}
}
