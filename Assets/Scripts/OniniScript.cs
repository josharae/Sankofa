using UnityEngine;
using System.Collections;

public class OniniScript : MonoBehaviour {

	private bool isAffected;
	private int waitCount;
	private GameObject musicSpirit;

	// Use this for initialization
	void Start () {
		isAffected = false;
		waitCount = 0;;
		musicSpirit = null;
	}
	
	// Update is called once per frame
	void Update () {
		if (isAffected == true) {
			Move (musicSpirit);
			ListenForOtherSounds();
		}
		else
			LookForPlayer ();
	}

	public void SetIsAffected(bool condition){
		isAffected = condition;
		waitCount = 100;
	}

	public void AssignMusicSource(GameObject obj) {
		musicSpirit = obj;
	}

	void Move(GameObject target) {
		if (waitCount > 0) {
			waitCount--;
		}
		else {
			Vector3 startVector = new Vector3 (this.transform.position.x, this.transform.position.y, this.transform.position.z);
			Vector3 targetVector = new Vector3 (target.transform.position.x, this.transform.position.y, target.transform.position.z);
			transform.position = Vector3.Lerp (startVector, targetVector, 0.005f);
		}
	}

	void LookForPlayer() {
		// to be coded by gameplay programmer in charge of Onini actions
	}

	void ListenForOtherSounds() {
		// to be coded by gameplay programmer in charge of Onini actions
	}
}
