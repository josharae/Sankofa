using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class ui_InventoryCue : MonoBehaviour {

	public GameObject panel;

	void Start () {
	
	}
	
	void Update () {

	}

	public void ActivateInventory()
	{
		panel.SetActive (true);
	}
}
