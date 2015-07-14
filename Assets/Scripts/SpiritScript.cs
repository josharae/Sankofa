using UnityEngine;

using System.Collections;

public class SpiritScript : MonoBehaviour {
	GameObject player;
	public bool isCollected = false;
	Vector3 OriginalPosition;
	private bool hasBeenThrown;
	private AudioSource audio;
	public Animator splish;
	
	void Start () {
		player = GameObject.Find ("Player");
		OriginalPosition = this.transform.position;
		hasBeenThrown = false;
		splish = GetComponent<Animator> ();
	}
	
	void OnMouseDown(){
		if (Vector3.Distance (transform.position, player.transform.position) < 20 && !isCollected){
			player.GetComponent<PlayerScript>().getObject(this.gameObject);
		}
	}
	
	void OnCollisionEnter(Collision other){
		this.GetComponent<AudioSource>().Play();
		splish.SetBool("splash", true);
		this.TeleportBack();
		}
	
	public void TeleportBack(){
		this.transform.position = OriginalPosition;
	}
	
	public void SetThrownBool(bool thrown){
		hasBeenThrown = thrown;
	}
}
