using UnityEngine;
using System.Collections;

public class Beginning_Hut_CloseDoor : MonoBehaviour {

	public GameObject door;
	public Beginning_Hut_OpenDoor openTrigger;
	private bool closing;
	private bool isClosed;
	private int count;

	// Use this for initialization
	void Start () {
		count = 0;
		closing = false;
		isClosed = true;
	}
	
	// Update is called once per frame
	void Update () {
		if (count < 90 && closing) {
			count++;
			CloseDoor ();
		} else if (count == 90) {
			closing = false;
			GameObject[] triggers = GameObject.FindGameObjectsWithTag ("DoorClose");
			for (int i = 0; i < triggers.Length; i++) {
				Beginning_Hut_CloseDoor bhc = triggers[i].GetComponent<Beginning_Hut_CloseDoor>();
				bhc.SetIsClosed(true);
			}
			isClosed = true;
			count = 0;
		}
	}

	private void CloseDoor(){
		Transform tran = door.transform;
		tran.Rotate(Vector3.up, -1.0f);
		tran.position = new Vector3 (tran.position.x - 0.011f, tran.position.y, tran.position.z - 0.02f);
	}

	public void BeginClosing(){
		Beginning_Hut_OpenDoor bho = openTrigger.GetComponent<Beginning_Hut_OpenDoor> ();
		if (bho.GetIsOpen()) {
			closing = true;
			bho.SetIsOpen(false);
		}
	}

	public bool GetIsClosed(){
		bool boolena = isClosed;
		return isClosed;
	}

	public void SetIsClosed(bool state){
		isClosed = state;
	}
}
