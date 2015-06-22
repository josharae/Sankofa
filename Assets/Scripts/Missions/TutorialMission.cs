using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class TutorialMission : MonoBehaviour {
	GameObject Player, Egg;
	List<string> Tasks;
	MissionScript missionScript;
	// Use this for initialization
	void Start () {
		Tasks = new List<string> ();
		Player = GameObject.Find (Tags.Player);
		missionScript = this.GetComponent<MissionScript> ();
		InitializeTasks ();
	}

	void InitializeTasks(){
		Tasks.Add ("Pick up the Cosmic Egg");
		Tasks.Add ("Break the Cosmic Egg");
		missionScript.setTasks (Tasks);
	}
	// Update is called once per frame
	void Update () {
//		if (Player.GetComponent<PlayerScript> ().hasObject && Player.GetComponent<PlayerScript> ().getObject ().tag == Tags.MisteriousEgg) {
//			Egg = Player.GetComponent<PlayerScript> ().getObject ();
//			missionScript.TaskCompleted ();
//		} else if (Egg && Egg.GetComponent<EggScript> ().isBroken) {
//			missionScript.TaskCompleted ();
//		}
	}
}
