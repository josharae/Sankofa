using UnityEngine;
using System.Collections;

public class save_triggerer : MonoBehaviour {

	void OnTriggerEnter (Collider other) {
		if(other.gameObject.CompareTag("Player")){
			//saveGame(); // could be a static method
			Debug.Log ("Saved Game");
		}
	}
	
	
}
