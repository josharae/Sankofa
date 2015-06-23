using UnityEngine;
using System.Collections;

public class WaterSpiritGiwa : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void OnTriggerEnter(Collider other) {
		if (other.gameObject.CompareTag("Giwa")) {
			Animation anim = other.GetComponent<Animation>();
			anim.Play ("Take 001", PlayMode.StopSameLayer);
		}
	}
}
