using UnityEngine;
using System.Collections;

public class SpiritAffObj : MonoBehaviour {
	public AudioClip clip;
	// Use this for initialization
	void Start () {
	
	}

	void OnCollisionEnter(Collision other){
		AudioSource.PlayClipAtPoint(clip, transform.position);
	}

	// Update is called once per frame
	void Update () {
	
	}
}