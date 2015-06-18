using UnityEngine;
using System.Collections;

public class CreateSpiritFromTree : MonoBehaviour {

	public GameObject spirit;

	// Use this for initialization
	void Start () {
		spirit.gameObject.SetActive (false);
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void OnTriggerEnter(Collider other) 
	{
		if (other.gameObject.CompareTag ("Rock"))
		{
			spirit.gameObject.SetActive (true);
		}
	}
}
