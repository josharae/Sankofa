using UnityEngine;
using System.Collections;

public class onini_trigger : MonoBehaviour {	
	void OnTriggerEnter(Collider other){
		if (other.tag == Tags.Player) {
			Build_Scenes.showLoading();
			Build_Scenes.LoadOnini();
		}
		
	}
}
