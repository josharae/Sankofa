using UnityEngine;
using System.Collections;

public class OniniController : MonoBehaviour {
	private int moveTo;
	public float rotateSpeed = 50f;
	public float speed = 3f;

	void Awake() {
		Waypoints.MakeWaypoints ();
		moveTo = 0;
		Quaternion rotateTo = Quaternion.LookRotation((Waypoints.waypointslist [moveTo].transform.position - transform.position));
		transform.rotation = Quaternion.RotateTowards(transform.rotation, rotateTo, Time.deltaTime * rotateSpeed);
	}

	void Update () {
		if (Vector3.Angle (transform.forward, Waypoints.waypointslist [moveTo].transform.position - transform.position) < 1f) {
			MoveTowardsTarget ();
		} else {
			Quaternion rotateTo = Quaternion.LookRotation ((Waypoints.waypointslist [moveTo].transform.position - transform.position));
			transform.rotation = Quaternion.RotateTowards (transform.rotation, rotateTo, Time.deltaTime * rotateSpeed);
		}
	}

	private void MoveTowardsTarget() {
		Vector3 targetPosition = Waypoints.waypointslist[moveTo].transform.position;
		Vector3 currentPosition = this.transform.position;

		if (Vector3.Distance (currentPosition, targetPosition) > .1f) { 
			Vector3 directionOfTravel = targetPosition - currentPosition;
			directionOfTravel.Normalize ();
			
			this.transform.Translate (
				(directionOfTravel.x * speed * Time.deltaTime),
				(directionOfTravel.y * speed * Time.deltaTime),
				(directionOfTravel.z * speed * Time.deltaTime),
				Space.World);
		} else {
			if (moveTo < Waypoints.waypointslist.Length - 1) {
				moveTo++;
			} else {
				moveTo = 0;
			}
		}
	}
}
