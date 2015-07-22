using UnityEngine;

using System.Collections;

public class SpiritScript : MonoBehaviour {
	GameObject player;
	public bool isCollected = false;
	Vector3 OriginalPosition;
	private bool hasBeenThrown;
	private AudioSource audio;
	public Animator splish;
	private bool isMoving;
	private GameObject affectedObject;
	
	void Start () {
		player = GameObject.Find ("Player");
		OriginalPosition = this.transform.position;
		hasBeenThrown = false;
		splish = GetComponent<Animator> ();
	}

	void Update () {
		if (isMoving)
			Pull (affectedObject);
	}
	
	void OnMouseDown(){
		if (Vector3.Distance (transform.position, player.transform.position) < 20 && !isCollected){
//			player.GetComponent<PlayerScript>().getObject(this.gameObject);
		}
	}
	
	void OnCollisionEnter(Collision other){
		this.GetComponent<AudioSource>().Play();
		splish.SetBool("splash", true);
		this.TeleportBack();
		if (other.gameObject.CompareTag ("EarthAffectedObject")) {
			affectedObject = other.gameObject;
			isMoving = true;
		}
	}
	
	private void Pull(GameObject obj) {
		if (isMoving){//Mathf.Abs(player.transform.position.x - obj.transform.position.x) > 0.5f && Mathf.Abs(player.transform.position.z - obj.transform.position.z) > 0.5f) {
			Vector3 targetVector = new Vector3(player.transform.position.x, obj.transform.position.y, player.transform.position.z);
			obj.transform.position = Vector3.Lerp (player.transform.position, obj.transform.position, 0.015f);
		}
		else {
			isMoving = false;
			this.gameObject.SetActive (false);
		}
	
	}
	
	
	void TeleportBack(){
		this.transform.position = OriginalPosition;
	}
	
	void SetThrownBool(bool thrown){
		hasBeenThrown = thrown;
	}
}
