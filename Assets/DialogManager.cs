using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using System.IO; 

public class DialogManager : MonoBehaviour {
	[SerializeField] Button dialogButton;
	[SerializeField] float textSpeed = 0.1f;
	
	GameObject textObject, player;
	Text textField;
	List <string> dialogue = new List<string>();
	List <string> currentPhrase = new List<string>();
	int currentIndex = 0, phraseIndex = 0;
	string defaultText;
	bool isFinished = false, dialogStarted = false;
	
	void Start () {
		textObject = GameObject.FindGameObjectWithTag (Tags.subtitles);
		player = GameObject.FindGameObjectWithTag (Tags.Player);
		textField = textObject.GetComponent<Text> ();
	}
	
	public void LoadandStartDialog(string fileName, string objName){
		if (!dialogStarted) {
			string line;
			defaultText = objName + ":\n";
			StreamReader theReader = new StreamReader ("Subtitles\\" + fileName);
		
			do {
				line = theReader.ReadLine ();
				if (line != null && line.Length != 0)
					dialogue.Add (line);		
			} while (line != null);
		
			theReader.Close ();	
			startDialog ();
		}
	}
	
	public void nextPhrase(){
		if (dialogStarted) {
			CancelInvoke ("showSubtitle");
			if (phraseIndex < currentPhrase.Count) {
				textField.text = defaultText + dialogue [currentIndex];
				phraseIndex = currentPhrase.Count;
				if(currentIndex == dialogue.Count - 1)
					buttonText(true);
			} else if (currentIndex < dialogue.Count - 1) {
				resetVariables ();
				currentIndex += 1;
				startDialog();
			} else {
				finishDialog ();
			}				
		}
	}
	
	
	public void finishDialog(){
		resetVariables();
		isFinished = true;
		defaultText = "";
		currentIndex = 0;
		dialogue = new List<string>();
		currentPhrase = new List<string>();
		dialogStarted = false;
		dialogButton.gameObject.SetActive (false);
	}
	
	void resetVariables(){
		phraseIndex = 0;
		textField.text = "";
	}
	
	public bool isDialogFinished(){
		return isFinished;
	}
	
	void startDialog(){ //works both to start a new dialog or go to next phrase
		dialogStarted = true;
		currentPhrase = new List<string> (dialogue [currentIndex].Split (' '));
		textField.text = defaultText;
		dialogButton.gameObject.SetActive (true);
		buttonText ();
		InvokeRepeating ("showSubtitle", 0f, textSpeed);
	}

	void buttonText(bool finish = false){
		string buttonText = "";
		if (finish)
			buttonText = "Close";
		else 
			buttonText = "Next";

		dialogButton.GetComponentInChildren<Text> ().text = buttonText;
	}
	
	public void closeDialog(){
		textField.text = "";
		isFinished = true;
	}
	
	void showSubtitle(){
		isFinished = false;
		if (phraseIndex < currentPhrase.Count) {
			textField.text += currentPhrase[phraseIndex] + " ";
			phraseIndex += 1;
		} else {
			if(currentIndex == dialogue.Count - 1)
				buttonText(true);
			CancelInvoke ("showSubtitle");
		}
	}
}
