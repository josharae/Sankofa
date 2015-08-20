using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using System.IO; 

public class SubtitleScript : MonoBehaviour {
	GameObject GameManager, player;
	[SerializeField] string textFileName;

	void Start () {
		GameManager = GameObject.Find (ItemNames.GameManager);
		player = GameObject.FindGameObjectWithTag (Tags.Player);
	}

	void OnMouseDown(){
		if(Vector3.Distance(this.transform.position,player.transform.position) < 10){
			GameManager.GetComponent<DialogManager>().LoadandStartDialog(textFileName,this.name);		
		}	
	}
}
