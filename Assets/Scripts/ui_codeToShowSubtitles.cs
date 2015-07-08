using UnityEngine;
using System.Collections;
using System.Collections.Generic; //Needed for Lists
using System.Text.RegularExpressions; //Needed for some string parsing

public class ui_codeToShowSubtitles : MonoBehaviour {
	
	private AudioClip dialogueAudio;
	private const float _RATE = 44100.0f;

	private string[] fileLines;

	//Subtitle variables
	private List<string> subtitleLines = new List<string>();

	private List<string> subtitleTimingStrings = new List<string>();
	public List<float> subtitleTimings = new List<float>();

	public List<string> subtitleText = new List<string>();

	private int nextSubtitle = 0;

	private string displaySubtitle;

	//Trigger variables
	private List<string> triggerLines = new List<string>();
	
	private List<string> triggerTimingStrings = new List<string>();
	public List<float> triggerTimings = new List<float>();
	
	private List<string> triggers = new List<string>();
	public List<string> triggerObjectNames = new List<string>();
	public List<string> triggerMethodNames = new List<string>();
	
	private int nextTrigger = 0;

	//GUI
	private GUIStyle subtitleStyle = new GUIStyle();

	//Static singleton
	public static ui_codeToShowSubtitles Instance { get; private set; }
	
	void Awake()
	{
		if(Instance != null && Instance != this)
		{
			Destroy(gameObject);
		}

		Instance = this;

		gameObject.AddComponent<AudioSource>();
	}
	
	public void BeginDialogue (AudioClip passedClip) {
		
		dialogueAudio = passedClip;

		//Reset all lists
		subtitleLines = new List<string>();
		subtitleTimingStrings = new List<string>();
		subtitleTimings = new List<float>();
		subtitleText = new List<string>();

		triggerLines = new List<string>();
		triggerTimingStrings = new List<string>();
		triggerTimings = new List<float>();
		triggers = new List<string>();
		triggerObjectNames = new List<string>();
		triggerMethodNames = new List<string>();

		nextSubtitle = 0;
		nextTrigger = 0;

		//Get everything from the text file
		TextAsset temp = Resources.Load("Dialogues/" + dialogueAudio.name) as TextAsset;
		fileLines = temp.text.Split('\n');

		//Split subtitle and trigger related lines into different lists
		foreach(string line in fileLines)
		{
			if(line.Contains("<trigger/>"))
			{
				triggerLines.Add(line);
			}
			else
			{
				subtitleLines.Add(line);
			}
		}

		//Split out our subtitle elements
		for(int cnt = 0; cnt < subtitleLines.Count; cnt++)
		{
			string[] splitTemp = subtitleLines[cnt].Split('|');
			subtitleTimingStrings.Add(splitTemp[0]);
			subtitleTimings.Add(float.Parse(CleanTimeString(subtitleTimingStrings[cnt])));
			subtitleText.Add(splitTemp[1]);
		}

		//Split out our trigger elements
		for(int cnt = 0; cnt < triggerLines.Count; cnt++)
		{
			string[] splitTemp1 = triggerLines[cnt].Split('|');
			triggerTimingStrings.Add(splitTemp1[0]);
			triggerTimings.Add(float.Parse(CleanTimeString(triggerTimingStrings[cnt])));

			triggers.Add(splitTemp1[1]);
			string[] splitTemp2 = triggers[cnt].Split('-');
			splitTemp2[0] = splitTemp2[0].Replace("<trigger/>", "");
			triggerObjectNames.Add(splitTemp2[0]);
			triggerMethodNames.Add(splitTemp2[1]);
		}

		//Set initial subtitle text
		if(subtitleText[0] != null)
		{
			displaySubtitle = subtitleText[0];
		}

		//Set and play the audio clip
		GetComponent<AudioSource>().clip = dialogueAudio;
		GetComponent<AudioSource>().Play();
	}

	//Remove all characters that are not part of the timing float
	private string CleanTimeString(string timeString)
	{
		Regex digitsOnly = new Regex(@"[^\d+(\.\d+)*$]");
		return digitsOnly.Replace(timeString, "");
	}
	
	void OnGUI () {

		//Make sure we are using a proper dialogueAudio file
		if(dialogueAudio != null && GetComponent<AudioSource>().clip.name == dialogueAudio.name)
		{
			//Check for <break/> or negative nextSubtitle
			if((nextSubtitle > 0) && (!subtitleText[nextSubtitle - 1].Contains("<break/>")))
			{
				//Create GUI
				GUI.depth = -1001;
				subtitleStyle.fixedWidth = Screen.width/1.5f;
				subtitleStyle.wordWrap = true;
				subtitleStyle.alignment = TextAnchor.MiddleCenter;
				subtitleStyle.normal.textColor = Color.white;
				subtitleStyle.fontSize = Mathf.FloorToInt(Screen.height * 0.0225f);
				
				Vector2 size = subtitleStyle.CalcSize (new GUIContent ());
				GUI.contentColor = Color.black;
				GUI.Label(new Rect(Screen.width/2 - size.x/2 + 1, Screen.height/1.25f - size.y + 1, size.x, size.y), displaySubtitle, subtitleStyle);
				GUI.contentColor = Color.white;
				GUI.Label(new Rect(Screen.width/2 - size.x/2, Screen.height/1.25f - size.y, size.x, size.y), displaySubtitle, subtitleStyle);
			}

			//Increment nextSubtitle when we hit the associated time point
			if(nextSubtitle < subtitleText.Count)
			{
				if(GetComponent<AudioSource>().timeSamples/_RATE > subtitleTimings[nextSubtitle])
				{
					displaySubtitle = subtitleText[nextSubtitle];
					nextSubtitle++;
				}
			}

			//Fire triggers when we hit the associated time point
			if(nextTrigger < triggers.Count)
			{
				if(GetComponent<AudioSource>().timeSamples/_RATE > triggerTimings[nextTrigger])
				{
					Debug.Log("Triggered " + triggerObjectNames[nextTrigger] + " with SendMessage(" + triggerMethodNames[nextTrigger] + ")");
					GameObject.Find(triggerObjectNames[nextTrigger]).SendMessage(triggerMethodNames[nextTrigger]);
					nextTrigger++;
				}
			}
		}
	}
}

