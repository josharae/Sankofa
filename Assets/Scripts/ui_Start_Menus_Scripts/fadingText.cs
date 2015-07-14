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
