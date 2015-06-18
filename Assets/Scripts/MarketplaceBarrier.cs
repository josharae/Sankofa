using UnityEngine;
using System.Collections;

public class MarketplaceBarrier : MonoBehaviour {

	public bool hasObject;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void OnTriggerEnter (Collider other){
		if (other.gameObject.CompareTag("MarketBarrier"))
		{
			if (this.hasObject){
				SetAllWithTagInactive("MarketBarrier");
			}
		}
	}
	private void SetAllWithTagInactive(string tag)
	{
		GameObject[] barriers = GameObject.FindGameObjectsWithTag(tag);
		for (int i = 0; i < barriers.Length; i++) {
			barriers[i].gameObject.SetActive (false);
		}
	}
}
