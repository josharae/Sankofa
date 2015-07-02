using UnityEngine;
using System.Collections;

public class ui_detectInactivity : MonoBehaviour {

	Vector3 pos;
	public int count;


	// Use this for initialization
	void Start () {
		pos = Input.mousePosition;
		if (pos == null) {
			pos = new Vector3();
		}
	
		InvokeRepeating ("checkActivity", 5f, 1f);
	}

	void Update()
	{
		if (Input.anyKeyDown) {
			count = 0;
		}
	}

	void checkActivity()
	{
		if (Input.mousePosition == pos) {
			count++;
			if (count >= 90) {
				Application.LoadLevel (1);
			}
		} else {
			pos = Input.mousePosition;
			count = 0;
		}
	}

}
