using UnityEngine;
using System.Collections;

public class PersistentObject : MonoBehaviour {
	void Awake() {
		DontDestroyOnLoad(this.gameObject);
	}
}
