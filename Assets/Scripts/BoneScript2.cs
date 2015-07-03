using UnityEngine;

using System.Collections;

public class BoneScript2 : MonoBehaviour {
	GameObject player;
	public bool isCollected = false;
	Vector3 OriginalPosition;
	public Animator Explosion;
	private bool hasBeenThrown;
	void Start () {
		player = GameObject.Find ("Player");
		OriginalPosition = this.transform.position;
		Explosion = GetComponent<Animator> ();
		hasBeenThrown = false;
		Explosion.SetBool("Explode", false);
	}
	
	void OnMouseDown(){
		if (Vector3.Distance (transform.position, player.transform.position) < 20 && !isCollected){
			player.GetComponent<PlayerScript2>().getObject(this.gameObject);
		}
	}
	
	void OnCollisionEnter(Collision other){
		if (other.gameObject.CompareTag ("Ground") && hasBeenThrown) {
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
