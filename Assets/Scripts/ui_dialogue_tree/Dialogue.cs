using UnityEngine;
using System.Collections.Generic;
using System.Xml.Serialization;

namespace DialogueTree
{
	public class Dialogue
	{
		public List<DialogueNode> Nodes;

		public void AddNode (DialogueNode node)
		{
			// if the node is null, then it's an ExitNode and we can skip adding it.
			if (node == null) 
			{
				return;
			}

			// add the node to the dialogue list of nodes
			Nodes.Add (node);
			// give the node an ID
			node.NodeID = Nodes.IndexOf (node);
		}

		public void AddOption(string text, DialogueNode node, DialogueNode dest)
		{
			// add the destination node to the dialogue if it's not allready there
			if (!Nodes.Contains (dest)) {
				AddNode (dest);
			}

			// add the parent node to the dialogue if its not already there
			if (!Nodes.Contains (node)) {
				AddNode (node);
			}

			DialogueOption opt;

			// create an option object. If the destination is an ExitNode, set the index to -1
			if (dest == null) {
				opt = new DialogueOption (text, -1);

			} else {
				opt = new DialogueOption (text, dest.NodeID);

				node.Options.Add (opt);
			}
		}

			public Dialogue()
			{
				Nodes = new List<DialogueNode>();
			}
		}
	}
