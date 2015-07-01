using UnityEngine;
using System.Collections;

public class MoreFading : MonoBehaviour
{

	// Use this for initialization
	IEnumerator ChangeLEvel ()
	{
		float fadeTime = GameObject.Find ("").GetComponent<Fading> ().BeginFade (1);
		yield return new WaitForSeconds (fadeT1me);
		Application.LoadLevel (Application.loadedLevel + 1);
	
		//Need  to put the name of the class here and then go to file build settings and then set the order
	}
