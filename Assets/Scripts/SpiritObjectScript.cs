using UnityEngine;

using System.Collections;

public class SpiritObjectScript : MonoBehaviour {
	GameObject player;
	public Animator Glow;
	private bool isGlowing;
	public SpiritScript spirit;

	void Start () {
		player = GameObject.Find ("Player");
		Glow = GetComponent<Animator> ();
		isGlowing = true;
		Glow.SetBool("Glow", true);
	}
	void FixedUpdate(){
		//Glow.SetBool("Glow", isGlowing);
	}
	
	void OnMouseDown(){
		if (Vector3.Distance (transform.position, player.transform.position) < 20 && isGlowing){
			player.GetComponent<PlayerScript>().getObject(spirit.gameObject);
		}
	}
}
