using UnityEngine;
using System.Collections;
using System;

public class Fading : MonoBehaviour
{
	Color objColor;
	float changingRate = 0.02f;
	float newAlpha = 1f;

	void Start () 
	{
		objColor = this.GetComponent<MeshRenderer> ().material.color;
	}

	void Update(){
		if (newAlpha > 0) {
			newAlpha = Mathf.Lerp (1, 0, changingRate += Time.deltaTime);
			Color newColor = objColor;
			newColor.a = newAlpha;
			this.GetComponent<MeshRenderer> ().material.color = newColor;
		} else
			this.gameObject.SetActive(false);
	}
}