using UnityEngine;
using System.Collections;
using System.Collections.Generic;
//using System.Text;
using System.IO; 

public class SubtitleScript : MonoBehaviour {
	[SerializeField] string textFile;
	List <string> dialogue = new List<string>();
	// Use this for initialization
	void Start () {
		Load ("blabla");
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	private bool Load(string fileName)
	{
			string line;
			// Create a new StreamReader, tell it which file to read and what encoding the file
			// was saved as
			StreamReader theReader = new StreamReader("test.txt");
			
			// Immediately clean up the reader after this block of code is done.
			// You generally use the "using" statement for potentially memory-intensive objects
			// instead of relying on garbage collection.
			// (Do not confuse this with the using directive for namespace at the 
			// beginning of a class!)
			//using (theReader)
		// While there's lines left in the text file, do this:
				do {
					//line = "";
					line = theReader.ReadLine ();
					if(line != null && line.Length != 0)
						dialogue.Add (line);
			
				} while (line != null);
			
				// Done reading, close the reader and return true to broadcast success    
				theReader.Close();
				Debug.Log(dialogue.Count);
				return true;
			
		
		}


}
