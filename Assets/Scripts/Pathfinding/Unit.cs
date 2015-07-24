using UnityEngine;
using System.Collections;

public class Unit : MonoBehaviour {
	
	
	public Transform target;
	float speed = 5;
	Vector3[] path;
	int targetIndex;
	
	void Start() {
		PathRequestManager.RequestPath(transform.position,target.position, OnPathFound);
	}
	
	public void OnPathFound(Vector3[] newPath, bool pathSuccessful) {
		if (pathSuccessful) {
			path = newPath;
			StopCoroutine("FollowPath");
			StartCoroutine("FollowPath");
		}
	}
	
	IEnumerator FollowPath() {
		Vector3 currentWaypoint = path[0];
		
		while (true) {
			if (transform.position == currentWaypoint) {
				targetIndex ++;
				if (targetIndex >= path.Length) {
					//Point where Onini has reached final waypoint

					yield break;
				}
				currentWaypoint = path[targetIndex];

			}
			if (Vector3.Angle (transform.forward, currentWaypoint - transform.position) > 1f) {
				Quaternion rotateTo = Quaternion.LookRotation ((currentWaypoint - transform.position));
				transform.rotation = Quaternion.RotateTowards (transform.rotation, rotateTo, Time.deltaTime * 50f);
				yield return null;
			} else {
				transform.position = Vector3.MoveTowards(transform.position,currentWaypoint,speed * Time.deltaTime);
				yield return null;
			}
			
		}
	}
	
	public void OnDrawGizmos() {
		if (path != null) {
			for (int i = targetIndex; i < path.Length; i ++) {
				Gizmos.color = Color.black;
				Gizmos.DrawCube(path[i], Vector3.one);
				
				if (i == targetIndex) {
					Gizmos.DrawLine(transform.position, path[i]);
				}
				else {
					Gizmos.DrawLine(path[i-1],path[i]);
				}
			}
		}
	}
}
