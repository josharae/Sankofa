using UnityEngine;

using System.Collections;

public class EggScript : MonoBehaviour {
	GameObject player;
	public bool isCollected = false;
	Vector3 OriginalPosition;
	public Animator Explosion;
	public bool hasBeenThrown;
	private AudioSource audio;
	public GameObject[] Sides;
	void Start () {
		player = GameObject.Find ("Player");
		OriginalPosition = this.transform.position;
		hasBeenThrown = false;
		Explosion.SetBool("Explode", false);
		Explosion = GetComponent<Animator> ();
		Sides = GameObject.FindGameObjectsWithTag ("Ground");
		Debug.Log (Sides.Length);
	}
	
	void OnMouseDown(){
		if (Vector3.Distance (transform.position, player.transform.position) < 20 && !isCollected) {
			player.GetComponent<TutorialPlayer> ().getObject (this.gameObject);
			
		}
	}
	
	void OnCollisionEnter(Collision other){
		if (other.gameObject.CompareTag ("Ground") && this.GetComponent<EggScript> ().hasBeenThrown) {
			this.GetComponent<AudioSource> ().Play ();
			Explosion.SetBool ("Explode", true);
			Debug.Log (Sides.Length);
			other.gameObject.GetComponentInChildren<ColorChanger> ().startChanging ();
			foreach (GameObject side in Sides) {
				side.GetComponent<ColorChanger> ().isChanging = true;
			}
			Invoke("StartGame",4f);
		}
	}

	void StartGame(){
		if (this.GetComponent<SceneChanger_Build> () != null) {
			this.GetComponent<SceneChanger_Build> ().StartGame ();
		} else {
			this.GetComponent<ui_changeScene> ().StartGame ();
		}
	}
	
	public void TeleportBack(){
		this.transform.position = OriginalPosition;
	}
	
	public void SetThrownBool(bool thrown){
		hasBeenThrown = thrown;
	}
}


