#pragma strict

var reach: float;

private var cam: Camera;
private var buttons: GameObject[];

function Start () {
	cam = GetComponent(Camera);
	buttons = GameObject.FindGameObjectsWithTag("Button");
}

function Update () {
	
	//Debug.DrawRay(Transform.position, Transform.position.forward * 300, Color.magenta);
	var ray = cam.main.ScreenPointToRay(new Vector3(Screen.width/2, Screen.height/2, 0));
	var hit: RaycastHit;
	
	if(Physics.Raycast(ray, hit, reach)) {
		if(hit.collider.tag == "Button" && Input.GetMouseButtonDown(0)) {
			hit.collider.GetComponent(Scripts_ButtonFade).willfade = !hit.collider.GetComponent(Scripts_ButtonFade).willfade;
		}
	}
}