using UnityEngine;
using System.Collections;
using UnityStandardAssets.Characters.FirstPerson;
public class GameManagerScript : MonoBehaviour {

	bool isPaused = false;
	GameObject[] InGameButtons;
	public GameObject PausePanel;
	// Use this for initialization
	void Start () {
		InGameButtons = GameObject.FindGameObjectsWithTag ("InGameButtons");
	}
	
	// Update is called once per frame
	void Update () {
		if(Input.GetKeyDown(KeyCode.P)){
			PauseGame();
		}
	}

	public void PauseGame(){
		isPaused = !isPaused;
		foreach (GameObject button in InGameButtons)
			button.SetActive (!isPaused);
		PausePanel.SetActive (isPaused);
		Time.timeScale = isPaused ? 0 : 1;
		GameObject.Find("Player").GetComponent<FirstPersonController>().enabled = !isPaused;
	}

}
