using UnityEngine;
using System.Collections;

public class TestDialogue : MonoBehaviour {

	public AudioClip dialogueClip;
	
	void Update () {
	
		if(Input.GetKeyDown(KeyCode.Space))
		{
			DialogueManager.Instance.BeginDialogue(dialogueClip);
		}
	}
}
