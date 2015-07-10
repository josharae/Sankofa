using UnityEngine;
using System.Collections;

public class ColorChanger : MonoBehaviour {
	Color lerpedColor = Color.black;
	float changingRate = 0.01f;
	public bool isChanging = false;

	
	// Update is called once per frame
	void Update () {
		if (isChanging) {
			InvokeRepeating ("changeColor", 0.2f, 0.3f);
			isChanging = false;
		}
	}

	void changeColor(){
		Color newColor = Color.black;
		newColor.r = Random.Range (0.2f, 1);
		newColor.g = Random.Range (0.1f, 1);
		newColor.b = Random.Range (0.3f, 1);
		this.GetComponent<MeshRenderer> ().material.color = newColor;
		
	}
}
