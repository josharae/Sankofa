using UnityEngine;
using System.Collections.Generic;
using System.Xml.Serialization;

namespace DialogueTree
{
	public class DialogueNode
	{

		public int NodeID = -1;

		public string Text;

		public List<DialogueOption> Options;

		//parameterless constructor for serialization

		public DialogueNode() 
		{
			Options = new List<DialogueOption> ();
		}

		public DialogueNode(string text)
		{
			Text = text;
			Options = new List<DialogueOption> ();
		}
	}
}