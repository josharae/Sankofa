using UnityEngine;
using System.Collections;

public class EarthSpiritAction : MonoBehaviour {

	public GameObject player;
	private GameObject affectedObject;
	//public Material invisible;

	private Vector3 targetVector;
	// Use this for initialization
	void Start () {
		affectedObject = new GameObject();
		targetVector = transform.position;
	}
	
	// Update is called once per frame
	void Update () {
			Pull (affectedObject);
	}

	void OnTriggerEnter(Collider other) {
		if (other.gameObject.CompareTag ("EarthAffectedObject")) {
			affectedObject = other.gameObject;
			//GetComponent<Renderer>().material = invisible;
			Vector3 targetVector = new Vector3(player.transform.position.x, player.transform.position.y, player.transform.position.z);
		}
	}

	private void Pull(GameObject obj) {
			obj.transform.position = Vector3.Lerp (transform.position, targetVector, .015f);
	}
}