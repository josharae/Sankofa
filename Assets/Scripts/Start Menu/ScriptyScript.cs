using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class ScriptyScript : MonoBehaviour {

	public string name;
	public InputField test;

	public string display()
	{
		return test.textComponent.text;
	}
}
