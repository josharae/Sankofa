using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;

public class MissionManager : MonoBehaviour {
	public Text CurrentTask;
	GameObject CurrentMission;
	public List<GameObject> Missions;
	// Use this for initialization
	void Start () {
		CurrentMission = Missions [0];
	}

	public void TaskCompleted(){
		Debug.Log ("here");
		if (CurrentMission)
			CurrentMission.GetComponent<MissionScript> ().TaskCompleted ();
	}
	// Update is called once per frame
	void Update () {
		if (CurrentMission) {
			if (CurrentMission.GetComponent<MissionScript> ().Updated) {
				CurrentTask.text = CurrentMission.GetComponent<MissionScript> ().CurrentTask ();
				CurrentMission.GetComponent<MissionScript> ().Updated = false;
			}
			else if (CurrentMission.GetComponent<MissionScript> ().isCompleted) {
				if (Missions.Count > 1) {
					Missions.Remove (Missions [0]);
					CurrentMission = Missions [0];
					CurrentTask.text = CurrentMission.GetComponent<MissionScript> ().CurrentTask ();
				} else{
					CurrentMission = null;
					CurrentTask.text = "Done";
				}
			}
		}
	}
}
