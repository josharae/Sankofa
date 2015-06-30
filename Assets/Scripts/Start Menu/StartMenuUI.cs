using UnityEngine;
using System.Collections;

public class StartMenuUI : MonoBehaviour {

	void ChangeToScene(int sceneToChangeTo) {
		Application.LoadLevel (sceneToChangeTo);
	}
}
