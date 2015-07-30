using UnityEngine;
using System.Collections;

public class Waypoints : MonoBehaviour {
	private static char lastLetter;
	private static string waypointName;
	private static int waypointNum;
	private static GameObject temp;

	public static GameObject[] waypointslist = GameObject.FindGameObjectsWithTag ("waypoint");

	public static void MakeWaypoints() {
		for (int i = 0; i < waypointslist.Length; i++) {

			waypointName = waypointslist[i].name;

			lastLetter = waypointName[waypointName.Length - 1];

			waypointNum = (int)char.GetNumericValue (lastLetter);

			if (i != waypointNum) {
				temp = waypointslist[waypointNum];
				waypointslist[waypointNum] = waypointslist[i];
				waypointslist[i] = temp;
				i = -1;
			}
		}
	}
}
