using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class MarketScript : MonoBehaviour {
	GameObject Player;
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
		Tasks.Add ("Bring supplies to be sold in the marketplace");
		Tasks.Add ("Participate in libations");
		Tasks.Add ("Speak to Anansi, The Keeper of All Stories");
		missionScript.setTasks (Tasks);
	}

	
	// Update is called once per frame
	void Update () {
	
	}
}
