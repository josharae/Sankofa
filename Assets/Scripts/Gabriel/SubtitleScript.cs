using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using System.IO; 

public class SubtitleScript : MonoBehaviour {
	[SerializeField] string textFile;
	GameObject textObject;
	Text textField;
	List <string> dialogue = new List<string>();
	int currentIndex = 0, phraseIndex = 0;
	bool isFinished = false, dialogStarted = false;
	float textSpeed = 0.1f;
	// Use this for initialization
	void Start () {
		textObject = GameObject.FindGameObjectWithTag (Tags.subtitles);
		textField = textObject.GetComponent<Text> ();
		Load (textFile);
	}

	private void Load(string fileName){
			string line;
			StreamReader theReader = new StreamReader("Subtitles\\"+fileName);

			do {
				line = theReader.ReadLine ();
				if(line != null && line.Length != 0)
					dialogue.Add (line);		
			} while (line != null);
		 
			theReader.Close();	
		}

		public void nextPhrase(){
			if (dialogStarted) {
				CancelInvoke ("showSubtitle");
				if (phraseIndex < dialogue [currentIndex].Length) {
					textField.text = dialogue [currentIndex];
					phraseIndex = dialogue [currentIndex].Length;
				} else if (currentIndex < dialogue.Count - 1) {
					resetVariables ();
					currentIndex += 1;
					InvokeRepeating ("showSubtitle", 0f, textSpeed);
				} else {
					finishDialog ();
				}				
			}
		}
		
		
		void finishDialog(){
			resetVariables();
			isFinished = true;
			currentIndex = 0;
			dialogStarted = false;
		}

		void resetVariables(){
			phraseIndex = 0;
			textField.text = "";
		}

		public bool isDialogFinished(){
			return isFinished;
		}

		public void closeDialog(){
			textField.text = "";
			isFinished = true;
		}

		void showSubtitle(){
			isFinished = false;
			if (phraseIndex < dialogue [currentIndex].Length) {
				textField.text += dialogue [currentIndex] [phraseIndex];
				phraseIndex += 1;
			} else {
				CancelInvoke ("showSubtitle");
				phraseIndex = 0;
			}
		}

		void OnMouseDown(){
			if (!dialogStarted) {
				dialogStarted = true;
				InvokeRepeating ("showSubtitle", 0f, textSpeed);
			}
		}
}
