//using UnityEngine;
//
//using System.Collections;
//
//public class EggScript : ObjectScript {
//
//	public Animator Explosion;
//	private AudioSource audio;
//	private bool hasBeenThrown;
//	void Start(){
//		Explosion.SetBool("Explode", false);
//		Explosion = GetComponent<Animator> ();
//	}
//	
//	void OnCollisionEnter(Collision other){
//		if (other.gameObject.CompareTag ("Ground") && this.GetComponent<ObjectScript>().hasBeenThrown) {
//			Explosion.SetBool("Explode", true);
//		}
//	}
//}

//using UnityEngine;
//
using UnityEngine;

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
		if (Vector3.Distance (transform.position, player.transform.position) < 20 && !isCollected) {
			player.GetComponent<TutorialPlayer> ().getObject (this.gameObject);
			
		}
	}
	
	void OnCollisionEnter(Collision other){
		if (other.gameObject.CompareTag ("Ground") && this.GetComponent<EggScript> ().hasBeenThrown) {
			this.GetComponent<AudioSource>().Play();
			Explosion.SetBool ("Explode", true);
		}
	}
	
	public void TeleportBack(){
		this.transform.position = OriginalPosition;
	}
	
	public void SetThrownBool(bool thrown){
		hasBeenThrown = thrown;
	}
}


