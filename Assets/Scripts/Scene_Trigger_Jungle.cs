﻿using UnityEngine;
using System.Collections;

public class Scene_Trigger_Jungle : MonoBehaviour {

	void OnTriggerEnter(){
		Build_Scenes.LoadJungle ();
	}
}
