using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System;

public class OniniController2 : MonoBehaviour {

	public Vector3 currentTarget;
	public Transform playerLocation;

	NavMeshAgent agent;

	List<Vector3> locations = new List<Vector3> ();

	private bool followingNoise;
	private bool checkingLocation;


	void Start () {
		agent = GetComponent<NavMeshAgent> ();
		locations = GenerateLocationsToLook ();
		followingNoise = false;
		checkingLocation = false;
	}
	

	void Update () {

		if (!followingNoise && !checkingLocation) {
			int numLoc = UnityEngine.Random.Range (0, locations.Count);
			currentTarget = locations[numLoc];
			checkingLocation = true;
		}

		if (followingNoise) {

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
			if (Vector3.Distance (locationsToCheck[i].transform.position, playerLocation.position) < 50) {
				_locations.Add (locationsToCheck[i].transform.position);
			}
		}
		return _locations;
	}
}
