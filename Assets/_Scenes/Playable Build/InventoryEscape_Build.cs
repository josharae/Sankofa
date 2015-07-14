using UnityEngine;
using System.Collections;

public class InventoryEscape_Build : MonoBehaviour {

	void Update () {
		if (Input.GetKeyDown (KeyCode.Escape)) {
			Application.LoadLevel(Build_Scenes.MainScene);
		}
	}
}
