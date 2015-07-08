using UnityEngine;
using System.Collections;

public class ui_dialogueStarter : MonoBehaviour {

	public AudioClip dialogueClip;
	
	void Update () {
	
		if(Input.GetKeyDown(KeyCode.Space))
		{
			ui_codeToShowSubtitles.Instance.BeginDialogue(dialogueClip);
		}
	}
}
