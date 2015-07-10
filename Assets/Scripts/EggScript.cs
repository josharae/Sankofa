using UnityEngine;

using System.Collections;

public class EggScript : MonoBehaviour {
	GameObject player, background;
	public bool isCollected = false;
	Vector3 OriginalPosition;
	public Animator Explosion;
	public bool hasBeenThrown;
	private AudioSource audio;
	
	void Start () {
		player = GameObject.Find ("Player");
		background = GameObject.Find ("Background");
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
			background.GetComponent<ColorChanger>().isChanging = true;
			Invoke("loadNewScene",3.5f);
		}
	}

	void loadNewScene(){
		Application.LoadLevel(Scenes.MainScene);
	}
	
	public void TeleportBack(){
		this.transform.position = OriginalPosition;
	}
	
	public void SetThrownBool(bool thrown){
		hasBeenThrown = thrown;
	}
}


