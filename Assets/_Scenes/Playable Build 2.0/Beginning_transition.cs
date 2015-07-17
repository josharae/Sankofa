using UnityEngine;
using System.Collections;

public class Beginning_transition : MonoBehaviour {

	void Update () {
		if (Input.anyKeyDown) {
			Application.LoadLevel (Build_Scenes.StartMenu);
		}
	}
}
