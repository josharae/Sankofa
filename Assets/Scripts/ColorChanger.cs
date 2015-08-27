using UnityEngine;
using System.Collections;

public class ColorChanger : MonoBehaviour {
	Color lerpedColor = Color.black;
	float changingRate = 0.01f;
	bool isChanging = false;
	public bool isSkyBox = false;


	void Start(){
		if (isSkyBox)
			setColorToDefault ();
	}
	// Update is called once per frame
	void Update () {
		if (isChanging) {
			InvokeRepeating ("changeColor", 0.2f, 0.3f);
			isChanging = false;
		}
	}

	public void startChanging(){
		isChanging = true;
	}

	void changeColor(){
		Color newColor = Color.black;
		newColor.r = Random.Range (0.2f, 1);
		newColor.g = Random.Range (0.1f, 1);
		newColor.b = Random.Range (0.3f, 1);
		if(isSkyBox)
			GameObject.Find("Main Camera").GetComponent<Skybox> ().material.color = newColor;
		else
			this.GetComponent<MeshRenderer> ().material.color = newColor;
		
	}

	public void setColorToDefault(){
		GameObject.Find("Main Camera").GetComponent<Skybox> ().material.color = Color.black;
		CancelInvoke ();
		isChanging = false;
	}
}
