using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class FadingScreen : MonoBehaviour
{
	public float fadeSpeed = 1.5f;          // Speed that the screen fades to and from black.
	
	
	private bool  isFading = false;      // Whether or not the scene is still fading in.

	Image currentBG;
	public Image originalBG;
	

	
	
	void Update ()
	{
		// If the scene is starting...
		if (isFading)
			// ... call the StartScene function.
			FadeToClear ();
	}
	
	
	void FadeToClear ()
	{
		// Lerp the colour of the texture between itself and transparent.
		currentBG.color = Color.Lerp (currentBG.color, Color.clear, fadeSpeed * Time.deltaTime);
		if (currentBG.color == Color.clear){
			currentBG.gameObject.SetActive (false);
			isFading = false;
		}
	}
	
	
	void FadeToBlack ()
	{
		// Lerp the colour of the texture between itself and black.
		currentBG.color = Color.Lerp(currentBG.color, Color.black, fadeSpeed * Time.deltaTime);
	}

	
	public void EndScene ()
	{
		isFading = true;
		// Make sure the texture is enabled.
		//guiTexture.enabled = true;
		currentBG = originalBG;
		currentBG.color = Color.black;
		currentBG.gameObject.SetActive(true);
		// Start fading towards black.

	}
}
