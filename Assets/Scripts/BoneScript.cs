//using UnityEngine;
//
//using System.Collections;
//
//public class BoneScript : MonoBehaviour {
//	GameObject player;
//	public bool isCollected = false;
//	Vector3 OriginalPosition;
//	void Start () {
//		player = GameObject.Find ("Player");
//		OriginalPosition = this.transform.position;
//	}
//
//	void OnMouseDown(){
//		if (Vector3.Distance (transform.position, player.transform.position) < 20 && !isCollected){
//			player.GetComponent<PlayerScript>().getObject(this.gameObject);
//		}
//	}
//
//
//
//	public void TeleportBack(){
//		this.transform.position = OriginalPosition;
//	}
//}

using UnityEngine;

using System.Collections;

public class BoneScript : MonoBehaviour {
	GameObject player;
	public bool isCollected = false;
	Vector3 OriginalPosition;
	public Animator Explosion;
	private bool hasBeenThrown;
	private AudioSource audio;

	void Start () {
		player = GameObject.Find ("Player");
		OriginalPosition = this.transform.position;
		Explosion = GetComponent<Animator> ();
		hasBeenThrown = false;
		Explosion.SetBool("Explode", false);
	}
	
	void OnMouseDown(){
		if (Vector3.Distance (transform.position, player.transform.position) < 20 && !isCollected){
			player.GetComponent<PlayerScript>().getObject(this.gameObject);
		}
	}
	
	void OnCollisionEnter(Collision other){
		if (other.gameObject.CompareTag ("Ground") && hasBeenThrown) {
			this.GetComponent<AudioSource>().Play();
			Explosion.SetBool("Explode", true);


		}
	}
	
	
	public void TeleportBack(){
		this.transform.position = OriginalPosition;
	}
	
	public void SetThrownBool(bool thrown){
		hasBeenThrown = thrown;
	}
}

