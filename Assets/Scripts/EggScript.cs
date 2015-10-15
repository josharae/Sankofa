using UnityEngine;

using System.Collections;

public class EggScript : MonoBehaviour {
	GameObject player, tutorialCamera;
	public bool isCollected = false;
	public GameObject worldPieces, worldManager;
	Vector3 OriginalPosition;
	public Animator Explosion;
	public bool hasBeenThrown;
	private AudioSource audio;

	void Start () {
		player = GameObject.Find ("Player");
		tutorialCamera = GameObject.Find ("Main Camera");
		worldManager = GameObject.Find ("worldManager");
		worldManager.SetActive (false);
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
	
	void OnTriggerEnter(Collider other){
		if (other.gameObject.CompareTag ("Ground") && hasBeenThrown) {
			this.GetComponent<AudioSource> ().Play ();
			Explosion.SetBool ("Explode", true);
			Debug.Log ("here");
			tutorialCamera.GetComponent<ColorChanger> ().startChanging ();
			Invoke("startGame",4f);
		}
	}

	void showPieces(){
		Destroy (this.gameObject);
		worldManager.SetActive (true);
		worldPieces.gameObject.SetActive (true);
		tutorialCamera.GetComponent<ColorChanger> ().setColorToDefault ();
	}

	void startGame(){
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


