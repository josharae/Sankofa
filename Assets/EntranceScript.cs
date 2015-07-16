using UnityEngine;
using System.Collections;

public class EntranceScript : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void OnTriggerEnter(Collider other){
		if (other.gameObject.tag == Tags.Player) {
			Debug.Log("player herE");
			GameObject.FindWithTag (Tags.Entrance).GetComponent<Collider> ().enabled = true;
		}
	}
}
