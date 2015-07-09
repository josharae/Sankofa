using UnityEngine;

using System.Collections;

public class EggScript : ObjectScript {

	public Animator Explosion;
	private AudioSource audio;
	private bool hasBeenThrown;
	void Start(){
		Explosion.SetBool("Explode", false);
		Explosion = GetComponent<Animator> ();
	}
	
	void OnCollisionEnter(Collision other){
		if (other.gameObject.CompareTag ("Ground") && this.GetComponent<ObjectScript>().hasBeenThrown) {
			Explosion.SetBool("Explode", true);
		}
	}
}
