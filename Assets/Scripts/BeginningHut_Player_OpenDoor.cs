using UnityEngine;
using System.Collections;

public class BeginningHut_Player_OpenDoor : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void OnTriggerEnter(Collider other){
		if (other.gameObject.CompareTag ("DoorOpen")) {
			Beginning_Hut_OpenDoor bho = other.gameObject.GetComponent<Beginning_Hut_OpenDoor>();
			bho.BeginOpening();
		}
		else if (other.gameObject.CompareTag ("DoorClose")) {
			Beginning_Hut_CloseDoor bhc = other.gameObject.GetComponent<Beginning_Hut_CloseDoor>();
			bhc.BeginClosing();
		}
	}
}
