using UnityEngine;
using System.Collections;

public class CurrentTarget : MonoBehaviour {

	public Transform playerTransform;
	private int waypointNumber;

	void Awake () {
		playerTransform = GameObject.FindWithTag ("Player").transform;

		Waypoints.MakeWaypoints ();

		waypointNumber = 0;

		transform.position = Waypoints.waypointslist [waypointNumber].transform.position;
	}

	public void nextWaypoint() {
		if (waypointNumber < Waypoints.waypointslist.Length - 1) {
			waypointNumber++;
		} else {
			waypointNumber = 0;
		}
		transform.position = Waypoints.waypointslist [waypointNumber].transform.position;
	}

	public void goToPlayer() {
		transform.position = playerTransform.position;
	}
}
