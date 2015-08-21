﻿using UnityEngine;

using System.Collections;

public class EggScript : MonoBehaviour {
	GameObject player;
	public bool isCollected = false;
	Vector3 OriginalPosition;
	public Animator Explosion;
	public bool hasBeenThrown;
	private AudioSource audio;

	void Start () {
		player = GameObject.Find ("Player");
		OriginalPosition = this.transform.position;
		hasBeenThrown = false;
		Explosion.SetBool("Explode", false);
		Explosion = GetComponent<Animator> ();
	}
	
	void OnMouseDown(){
		if (Vector3.Distance (transform.position, player.transform.position) < 20 && !isCollected && !hasBeenThrown) {
			player.GetComponent<TutorialPlayer> ().getObject (this.gameObject);
			
		}
	}
	
	void OnCollisionEnter(Collision other){
		if (other.gameObject.CompareTag ("Ground") && hasBeenThrown) {
			this.GetComponent<AudioSource> ().Play ();
			Explosion.SetBool ("Explode", true);
			Debug.Log ("here");
			GameObject.Find("Main Camera").GetComponent<ColorChanger> ().startChanging ();
			Invoke("StartGame",4f);
		}
	}

	void StartGame(){
		if (this.GetComponent<SceneChanger_Build> () != null) {
			Build_Scenes.showLoading();
			Build_Scenes.LoadHut();
		} else {
			Scenes.LoadHut();
		}
	}
	
	public void TeleportBack(){
		this.transform.position = OriginalPosition;
	}
	
	public void SetThrownBool(bool thrown){
		hasBeenThrown = thrown;
	}
}


