using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class EntranceScript : MonoBehaviour {
	[SerializeField] GameObject giwaLife;
	public GameObject duelMenu, limit;
	GameObject[] boulders;
	public bool isFighting = false;
	// Use this for initialization
	void Start () {
		boulders = GameObject.FindGameObjectsWithTag (Tags.Boulder);
	}
	
	// Update is called once per frame
	void Update () {

	}

	public void activateLifeUI(bool activate = true){
		giwaLife.SetActive (activate);
		giwaLife.transform.GetChild (0).gameObject.SetActive (activate);
		giwaLife.transform.GetChild (0).GetChild (0).gameObject.SetActive (activate);
	}

	public void resetTimeScale(){
		Time.timeScale = 1;
	}

	public void battleEnded(){
		GameObject.FindWithTag (Tags.Entrance).GetComponent<Collider> ().enabled = false;
		GameObject.FindWithTag (Tags.Entrance).GetComponent<MeshRenderer> ().enabled = false;
		limit.GetComponent<Collider> ().enabled = true;
		limit.GetComponent<MeshRenderer> ().enabled = true;
		isFighting = false;
	}

	public void startDuel(){
		GameObject.FindWithTag (Tags.Giwa).GetComponent<Phase2_script_GiwaAttack> ().startDuel ();
		GameObject.FindWithTag (Tags.Entrance).GetComponent<Collider> ().enabled = true;
		GameObject.FindWithTag (Tags.Entrance).GetComponent<MeshRenderer> ().enabled = true;
		limit.GetComponent<Collider> ().enabled = false;
		limit.GetComponent<MeshRenderer> ().enabled = false;
		duelMenu.SetActive (false);
		isFighting = true;
		activateLifeUI ();
		resetTimeScale ();
		foreach (GameObject boulder in boulders)
			boulder.SetActive (true);

	}

	public void cancelDuel(){
		GameObject.FindWithTag (Tags.Entrance).GetComponent<Collider> ().enabled = false;
		GameObject.FindWithTag (Tags.Entrance).GetComponent<MeshRenderer> ().enabled = false;
		limit.GetComponent<Collider> ().enabled = true;
		limit.GetComponent<MeshRenderer> ().enabled = true;

		isFighting = false;
		duelMenu.SetActive (false);
		resetTimeScale ();
		activateLifeUI (false);
	}

	void OnTriggerEnter(Collider other){
		if (other.gameObject.tag == Tags.Player) {
			if (!isFighting) {
				duelMenu.SetActive (true);	
				Time.timeScale = 0;
			}
		}
	}
}
