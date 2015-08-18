using UnityEngine;
using System.Collections;

public class FollowPlayer : MonoBehaviour {

	private float elapsedTime;
	public float delay;
	public Unit unit;

	void Awake() {
		elapsedTime = 0;
	}

	void Update() {
		elapsedTime += Time.deltaTime;
		if (elapsedTime > delay) {
			unit.goToPlayer ();
			elapsedTime = 0;
		}
	}
}
