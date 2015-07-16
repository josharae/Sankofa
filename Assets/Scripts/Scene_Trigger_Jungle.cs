using UnityEngine;
using System.Collections;

public class Scene_Trigger_Jungle : MonoBehaviour {

	void OnTriggerEnter(){
		Debug.Log ("Got Collision");
		Scenes.Jungle ();
	}
}
