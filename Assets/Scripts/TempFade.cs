using UnityEngine;
using System.Collections;

public class TempFade : MonoBehaviour {

	public GameObject mesh;
	void Start () 
	{
		mesh.SetActive (false);
	}


}
