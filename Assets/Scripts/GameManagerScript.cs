using UnityEngine;
using System.Collections;

public class GameManagerScript : MonoBehaviour {
	bool isPaused = false;
	GameObject EventSystem;
	// Use this for initialization
	void Start () {
		EventSystem = GameObject.Find ("EventSystem");
	}
	
	// Update is called once per frame
	void Update () {
		if(Input.GetKeyDown(KeyCode.P)){
			PauseGame();
		}
	}

	private void PauseGame(){
		isPaused = !isPaused;
		EventSystem.SetActive (!isPaused);
		Time.timeScale = isPaused ? 0 : 1;
	}

}
