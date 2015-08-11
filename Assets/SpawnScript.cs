using UnityEngine;
using System.Collections;

public class SpawnScript : MonoBehaviour {
	[SerializeField] int xLimit = 0, zLimit = 0, maxMarbles = 0, maxMasks = 0;
	int marbles = 0, masks = 0;
	// Use this for initialization
	void Start () {
		Debug.Log (Terrain.activeTerrain.SampleHeight (new Vector3(60,0,480)));
		spawnMarbles ();
	}
	
	// Update is called once per frame
	void spawnMarbles (){
//		int collectedMarbles = GameObject.Find (ItemNames.GameManager).GetComponent<GameManagerScript> ();
	}
}
