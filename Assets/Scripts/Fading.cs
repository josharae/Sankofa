using UnityEngine;
using System.Collections;
using System;

public class Fading : MonoBehaviour
{
	public float fadeSpeed = 0.8f;   // the fading speed
	private CanvasGroup can;		 // the texture's alpha value between 0 and 1
	private int fadeDir = -1;		 // the direaction to fade: in = -1 or out 1

	void Start()
	{
		can = GetComponent<CanvasGroup> ();
		// fade out/ in the alpha value using a dirction, a speed and Time.deltatime to convert the operation to seconds
		can.alpha += fadeDir * fadeSpeed * Time.deltaTime;
		// force (clamp) the  number between 0 and 1 because GUI.color uses alpha values between 0 and 1
		can.alpha = Mathf.Clamp01 (can.alpha);
	}
}