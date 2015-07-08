using UnityEngine;
using System.Collections;

public class ui_TriggerStarterforDialogueStarter : MonoBehaviour {

	public bool grow = false;
	public float timer = 0.0f;

	private Vector3 origScale;
	private Vector3 targScale;
		
	void Update () {

		if(grow)
		{
			timer += Time.deltaTime;
			transform.localScale = Vector3.Lerp(origScale, targScale, timer);
		}

		if(timer >= 1)
		{
			grow = false;
		}
	}

	public void Grow () {

		grow = true;
		origScale = transform.localScale;
		targScale = origScale + new Vector3(1, 1, 1);
	}
}
