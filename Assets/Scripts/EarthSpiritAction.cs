using UnityEngine;
using System.Collections;

public class EarthSpiritAction : MonoBehaviour {

	public GameObject player;
	private bool isMoving;
	private GameObject affectedObject;
	public Material invisible;

	// Use this for initialization
	void Start () {
		isMoving = false;
		affectedObject = null;
	}
	
	// Update is called once per frame
	void Update () {
		if (isMoving)
			Pull (affectedObject);
	}

	void OnTriggerEnter(Collider other) {
		if (other.gameObject.CompareTag ("EarthAffectedObject")) {
			affectedObject = other.gameObject;
			isMoving = true;
			GetComponent<Renderer>().material = invisible;
		}
	}

	private void Pull(GameObject obj) {
		if (Mathf.Abs(player.transform.position.x - obj.transform.position.x) > 0.5f && Mathf.Abs(player.transform.position.z - obj.transform.position.z) > 0.5f) {
			Vector3 startVector = new Vector3(obj.transform.position.x, obj.transform.position.y, obj.transform.position.z);
			Vector3 targetVector = new Vector3(player.transform.position.x, obj.transform.position.y, player.transform.position.z);
			obj.transform.position = Vector3.Lerp (startVector, targetVector, 0.015f);
		}
		else {
			isMoving = false;
			this.gameObject.SetActive (false);
		}
	}
}
