using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class EntranceScript : MonoBehaviour {
	[SerializeField] GameObject giwaLife;
	GameObject[] boulders;
	public bool isFighting = false;
	// Use this for initialization
	void Start () {
		boulders = GameObject.FindGameObjectsWithTag (Tags.Boulder);
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void OnTriggerEnter(Collider other){
		if (other.gameObject.tag == Tags.Player && !isFighting) {
			isFighting = true;
			GameObject.FindWithTag (Tags.Entrance).GetComponent<Collider> ().enabled = true;
			giwaLife.SetActive(true);
			giwaLife.transform.GetChild(0).gameObject.SetActive(true);
			giwaLife.transform.GetChild(0).GetChild(0).gameObject.SetActive(true);
			foreach(GameObject boulder in boulders)
				boulder.SetActive(true);
		}
	}
}
