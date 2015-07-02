using UnityEngine;
using System.Collections;

public class ui_transition : MonoBehaviour {
	
	void Update () {
		if (Input.anyKeyDown) {
			Application.LoadLevel (1);
		}
	}
}
