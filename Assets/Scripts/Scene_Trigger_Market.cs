using UnityEngine;
using System.Collections;

public class Scene_Trigger_Market : MonoBehaviour {
	
	void OnTriggerEnter(){
		Build_Scenes.LoadMarket ();
	}
}
