using UnityEngine;
using System.Collections;

public class MusicSpiritAction : MonoBehaviour {
	
	public Material invisible;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void OnCollisionEnter(Collision other) {
		ThrowObject to = GetComponent<ThrowObject> ();
		if (to.CheckIfHasBeenThrown ()) {
			GameObject[] objs = GameObject.FindGameObjectsWithTag ("MusicAffectedObject");
			for (int i = 0; i < objs.Length; i++) {
				OniniScript os = objs [i].GetComponent<OniniScript> ();
				os.SetIsAffected (true);
				os.AssignMusicSource (this.gameObject);
			}
//			GetComponent<Renderer> ().material = invisible;
			this.gameObject.SetActive (false);
		}
	}
}
