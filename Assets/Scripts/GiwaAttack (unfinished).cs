using UnityEngine;
using System.Collections;

public class GiwaAttack : MonoBehaviour {

	private Rigidbody rb;
	private int waitCount;
	private int chargeCount;
	private bool isCharging;
	private int slowDownCount;
	private bool isSlowingDown;
	private Transform targetSpot;
	private Transform lastTransform;
	public GameObject obj;

	// Use this for initialization
	void Start () {
		rb = GetComponent<Rigidbody> ();
		waitCount = 0;
		chargeCount = 0;
		isCharging = false;
		slowDownCount = 0;
		isSlowingDown = false;
		targetSpot = null;
		lastTransform = null;

	}

	void FixedUpdate () {
		if (waitCount < 200) {
//			if (isSlowingDown == true)
//				SlowDown();
//			else
				waitCount++;
		} else {
//			if (isCharging == false)
//			{
//				Charge ();
//			}
//			else {
				if (chargeCount >= 150)
				{
					waitCount = 0;
					chargeCount = 0;
//					isCharging = false;
//					isSlowingDown = true;
//					lastTransform = this.transform;
					SlowDown();
				}
				else
			    {
//					chargeCount++;
					Charge();
				}
//			}
		}
	}

	private void Charge()
	{
		GameObject target = GameObject.FindGameObjectWithTag ("Player");
		targetSpot = target.transform;
		Vector3 path = new Vector3(targetSpot.position.x - this.transform.position.x, 0.0f, targetSpot.position.z - this.transform.position.z);
		rb.AddForce (path * 50.0f);
//		isCharging = true;
		chargeCount++;
	}

	private void SlowDown()
	{
		Vector3 velocity = Vector3.zero;
		transform.position = Vector3.SmoothDamp(transform.position, targetSpot.position, ref velocity, 0.5f);
//		Transform currentTransform = this.transform;
//		float distance = Vector3.Distance (currentTransform.position, lastTransform.position);
//		obj.SetActive (true);
//		if (rb.velocity == new Vector3 (0.0f, 0.0f, 0.0f)) {
//			Vector3 vector = new Vector3(currentTransform.position.x * -1.0f, 0.0f, currentTransform.position.z * -1.0f);
//			rb.AddForce (vector * 1000.0f);
//		} else {
//			isSlowingDown = false;
	}

}