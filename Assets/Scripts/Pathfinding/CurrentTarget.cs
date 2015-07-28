using UnityEngine;
using System.Collections;

public class CurrentTarget : MonoBehaviour {

	private int waypointNumber;

	void Awake () {
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
}
