using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class ui_textReceive : MonoBehaviour {

	public string name;
	public InputField test;

	public void display()
	{
		name = test.textComponent.text;
		Debug.Log (name);
	}
}
