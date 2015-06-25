using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class ItemPanelScript : MonoBehaviour {
	public GameObject Panel;
	public Image ItemSprite;
	// Use this for initialization
	void Start () {


	}
	
	// Update is called once per frame
	public void ShowItemPanel (GameObject Item) {
		Panel.gameObject.SetActive (true);
		Sprite newSprite = Resources.Load <Sprite> (Item.name);
		Debug.Log (Item.name);
		ItemSprite.overrideSprite = (Sprite) newSprite;
		Panel.GetComponentInChildren<Text> ().text = Item.name;
		Invoke ("DisablePanel", 2f);
	}

	private void DisablePanel(){
		Panel.gameObject.SetActive (false);
	}
}
