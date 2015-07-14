using UnityEngine;
using System.Collections.Generic;
using System.Xml.Serialization;

namespace DialogueTree
{
	public class DialogueOption
	{
		public string Text;
		public int DestinationNodeID;

		// parameterless constructor for serialization
		public DialogueOption() {

		}

		public DialogueOption(string text, int dest) 
		{
			this.Text = text;
			this.DestinationNodeID = dest;
		}
	}
}
