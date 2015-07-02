using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class fadingText : MonoBehaviour {

	[Range (0, 100)]public float repeatRate;
	private float alpha;
	private bool ascending;
	public Text element;

	// Use this for initialization
	void Start () {
		alpha = element.color.a;
		InvokeRepeating ("fade", 0.0f, repeatRate);
		InvokeRepeating ("print", 0.0f, repeatRate);
	}

	void print()
		{
			//Debug.Log (element.text);
			Debug.Log ("public var is " + alpha.ToString());
			//Debug.Log ("actual alpha is " + element.canvasRenderer.GetAlpha ().ToString ());
		}

	void fade(){
		if(element.color.a >= .8f)
		{
			ascending = false;
		}
		else if(element.color.a <= .2f)
		{
			ascending = true;
		}
		if (ascending) {
			alpha += .01f;
		} else {
			alpha -= .01f;
		}
		Color col = element.color;
		col.a = alpha;
		element.color = col;
	}
}
