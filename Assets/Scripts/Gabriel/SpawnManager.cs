using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class SpawnManager : MonoBehaviour {
	Dictionary<int, List<Vector3>> collectedItems = new Dictionary<int, List<Vector3>>();
	Dictionary<int, int> itemsToCollect = new Dictionary<int, int>();
	int currentLevel = 0;

	public void addCollectedItem(Vector3 itemPosition){
		if (collectedItems.ContainsKey (currentLevel))
			collectedItems [currentLevel].Add (itemPosition);
		else{
			List<Vector3> newList = new List<Vector3>();
			newList.Add(itemPosition);
			collectedItems.Add (currentLevel,newList);
		}
		itemsToCollect [currentLevel] -= 1;
	}

	public void checkCollectedItems(int level){
		currentLevel = level;
		GameObject[] collectibles = GameObject.FindGameObjectsWithTag (Tags.Collectible);
		if (collectedItems.ContainsKey (currentLevel) && itemsToCollect.ContainsKey(currentLevel)){
			if(itemsToCollect[currentLevel] > 0) {
				for (int i =0; i<collectibles.Length; i++) {
					for (int x =0; x<collectedItems[currentLevel].Count; x++) {
						if (Vector3.Distance (collectibles [i].transform.position, collectedItems [currentLevel] [x]) < 5) {
							collectibles [i].SetActive (false);
						}
					}
				}
			}
		} else
			itemsToCollect.Add (currentLevel, collectibles.Length);
	}
}
