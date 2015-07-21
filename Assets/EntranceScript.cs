using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class EntranceScript : MonoBehaviour {
	[SerializeField] GameObject giwaLife;
	public GameObject duelMenu;
	GameObject[] boulders;
	public bool isFighting = false;
	// Use this for initialization
	void Start () {
		boulders = GameObject.FindGameObjectsWithTag (Tags.Boulder);
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	public void activateLifeUI(){
		giwaLife.SetActive (true);
		giwaLife.transform.GetChild (0).gameObject.SetActive (true);
		giwaLife.transform.GetChild (0).GetChild (0).gameObject.SetActive (true);
	}

	public void startDuel(){
		GameObject.FindWithTag (Tags.Entrance).GetComponent<Collider> ().enabled = true;
		activateLifeUI ();
		foreach (GameObject boulder in boulders)
			boulder.SetActive (true);

	}

	void OnTriggerEnter(Collider other){
		if (other.gameObject.tag == Tags.Player){
		if (!isFighting) {
			isFighting = true;
			duelMenu.SetActive (true);			
		} else {
			if(!GameObject.FindWithTag (Tags.Giwa).GetComponent<Phase2_script_GiwaAttack>().duelStarted && !duelMenu.activeInHierarchy){
				GameObject.FindWithTag (Tags.Entrance).GetComponent<Collider> ().enabled = false;
				isFighting = false;
				giwaLife.SetActive (false);
				giwaLife.transform.GetChild (0).gameObject.SetActive (false);
				giwaLife.transform.GetChild (0).GetChild (0).gameObject.SetActive (false);
			}
		}
		}
	}
}
