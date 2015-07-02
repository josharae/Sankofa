using UnityEngine;
using System.Collections;

public class ui_changeScene : MonoBehaviour {

	public void ChangeToScene(int sceneToChangeTo) {
		Application.LoadLevel (sceneToChangeTo);
	}
}
