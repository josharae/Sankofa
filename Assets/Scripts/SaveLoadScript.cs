using UnityEngine;
using System.Collections;
using System;
using System.Runtime.Serialization.Formatters.Binary;
using System.IO;

public class SaveLoadScript : MonoBehaviour {
	public void Save(){
		BinaryFormatter binaryF = new BinaryFormatter();
		FileStream file = File.Create (Application.persistentDataPath + "/playerInfo.dat");		                                           

		PlayerData newP = new PlayerData ();
		newP.hp = 5;
		newP.exp = 50;

		binaryF.Serialize (file, newP);
		file.Close ();
		Debug.Log ("Saved to" + Application.persistentDataPath + "/playerInfo.dat");
	}

	public void Load(){
		if (File.Exists (Application.persistentDataPath + "/playerInfo.dat")) {
			BinaryFormatter binaryF = new BinaryFormatter ();
			FileStream file = File.Open(Application.persistentDataPath + "/playerInfo.dat", FileMode.Open);
			PlayerData newP = (PlayerData)binaryF.Deserialize (file);
			file.Close ();
		}
	}

}

[Serializable]
class PlayerData{
	public float hp;
	public float exp;

}
		                           
