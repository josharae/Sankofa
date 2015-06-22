using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;

public class MissionScript : MonoBehaviour {
	List<string> Tasks;
	public bool isCompleted = false, Updated = true;

	public void setTasks(List<string> newTasks){
		Tasks = newTasks;
	}

	public string CurrentTask(){
		return Tasks [0];
	}

	public void TaskCompleted(){
		if (Tasks.Count > 1) {
			Tasks.Remove (Tasks [0]);
			Updated = true;
		} else if (Tasks.Count == 1) {
			Tasks.Remove (Tasks [0]);
			isCompleted = true;
		}		
	}
}
