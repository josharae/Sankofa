using UnityEngine;
using System.Collections;

public class SpiritAffObj : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}

	void OnCollisionEnter(Collision other){
		if (other.gameObject.CompareTag ("Spirit")) {
			//action
		}
	}

	// Update is called once per frame
	void Update () {
	
	}
}
