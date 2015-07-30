using UnityEngine;
using System.Collections;

public class Inventory_escape : MonoBehaviour {

	// Update is called once per frame
	void Update () {
		if (Input.GetKeyDown (KeyCode.Escape)) {
			string sceneToLoad = GameObject.FindWithTag(Tags.StaticObject).GetComponent<GlobalVariablesScript>().previousScene;
			Application.LoadLevel(sceneToLoad);
		}
	}
}
