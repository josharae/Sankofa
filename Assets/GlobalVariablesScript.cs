using UnityEngine;
using System.Collections;

public class GlobalVariablesScript : MonoBehaviour {
	bool defeatedGiwa = false,eggIsBroken = false;
	// Use this for initialization
	void Awake() {
		DontDestroyOnLoad(transform.gameObject);
	}

	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		//GameObject.Find (fsdjkfl.GlobalObject).GetComponent<GlobalVariablesScript> ().giwaDefeated ();
	}

	public void giwaDefeated(){
		if(!defeatedGiwa){
			defeatedGiwa = true;
			Scenes.LoadGame();
		}
	}

	public void brokenEgg(){
		if(!eggIsBroken){
			eggIsBroken = true;
			Scenes.LoadGame();
		}
	}
}
