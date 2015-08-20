using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System;

public class OniniController2 : MonoBehaviour {

	public Vector3 currentTarget;
	public Transform playerLocation;

	public float oniniCheckRange;

	NavMeshAgent agent;

	List<Vector3> locations = new List<Vector3> ();

	private bool followingNoise;
	private bool checkingLocation;


	void Start () {
		agent = GetComponent<NavMeshAgent> ();
		followingNoise = false;
		checkingLocation = false;
	}
	

	void Update () {

		if (!followingNoise && !checkingLocation) {
			locations = GenerateLocationsToLook();
			int numLoc = UnityEngine.Random.Range (0, locations.Count);

			try {
				currentTarget = locations[numLoc];
			}
			catch (ArgumentOutOfRangeException e) {
				UnityEngine.Debug.Log ("More hiding spots need to be placed so the player is always in range of at least one");
			}

			checkingLocation = true;
		}

		if (followingNoise) {
			if (Vector3.Distance (transform.position, currentTarget) < 5) {
				followingNoise = false;
			}

		} else if (checkingLocation) {
			if (Vector3.Distance (transform.position, currentTarget) < 2) {
				checkingLocation = false;
			}
		}


		agent.SetDestination (currentTarget);
	}

	List<Vector3> GenerateLocationsToLook() {
		List<Vector3> _locations = new List<Vector3> ();
		GameObject[] locationsToCheck = GameObject.FindGameObjectsWithTag ("OniniCheckLocation");
		for (int i = 0; i < locationsToCheck.Length; i++) {
			if (Vector3.Distance (locationsToCheck[i].transform.position, playerLocation.position) < oniniCheckRange) {
				_locations.Add (locationsToCheck[i].transform.position);
			}
		}
		return _locations;
	}

	public void followNoise(Vector3 noiseLocation) {
		currentTarget = noiseLocation;
		followingNoise = true;
		checkingLocation = false;
	}
}
