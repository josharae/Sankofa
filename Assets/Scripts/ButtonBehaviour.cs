using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class ButtonBehaviour : MonoBehaviour {
	public Text thisText;
	bool isShowing = true;
	// Use this for initialization
	void Start () {
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	public void Clicked(){
		isShowing = !isShowing;
		thisText.gameObject.SetActive (isShowing);

	}

}
