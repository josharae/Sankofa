using UnityEngine;
using System.Collections;

public class Beginning_Hut_OpenDoor : MonoBehaviour {

	public GameObject door;
	public Beginning_Hut_CloseDoor closeTrigger;
	private int count;
	private bool opening;
	private bool isOpen;

	// Use this for initialization
	void Start () {
		count = 0;
		opening = false;
		isOpen = false;
	}
	
	// Update is called once per frame
	void Update () {
		if (count < 90 && opening) {
			count++;
			OpenDoor ();
		} else if (count == 90) {
			opening = false;
			isOpen = true;
			count = 0;
		}
	}

	private void OpenDoor(){
		Transform tran = door.transform;
		tran.Rotate(Vector3.up, 1.0f);
		tran.position = new Vector3 (tran.position.x + 0.011f, tran.position.y, tran.position.z + 0.02f);
	}

	public void BeginOpening(){
		Beginning_Hut_CloseDoor bhc = closeTrigger.GetComponent<Beginning_Hut_CloseDoor> ();
		if (bhc.GetIsClosed()) {
			opening = true;
			bhc.SetIsClosed(false);
		}
	}

	public bool GetIsOpen(){
		return isOpen;
	}

	public void SetIsOpen(bool state){
		isOpen = state;
	}
}
