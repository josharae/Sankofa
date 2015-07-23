using UnityEngine;
using System.Collections;

public class Scene_Trigger_Castle : MonoBehaviour {


	void OnTriggerEnter(Collider other){
		if (other.tag == Tags.Player) {
			Build_Scenes.showLoading();
			Build_Scenes.LoadCastle();
		}

	}
}
