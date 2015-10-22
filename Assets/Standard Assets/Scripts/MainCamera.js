#pragma strict

private var previousObject : InteractiveObject;

static var audioGameObject : GameObject;
static var triggerBox : Transform;

function Awake() {
}

function Start() {
     //Set Cursor to not be visible
    Cursor.visible = false;
    }

function Update() {
    if (Input.GetKeyDown("escape"))
    {
        Application.Quit();
    }
    // Cursor.lockState = CursorLockMode.Locked;
    var ray = Camera.main.ScreenPointToRay(Input.mousePosition);
    var hit: RaycastHit;
    var fwd : Vector3 = GetComponent.<Camera>().transform.TransformDirection(Vector3.forward);
    if (Physics.Raycast(ray, hit, 5f)) {
        var io : InteractiveObject = hit.transform.GetComponent.<InteractiveObject>();
        if (io) {
            io.SendMessage("Glow");
            if (previousObject && previousObject != io)
            {
                previousObject.SendMessage("UnGlow");
            }
            previousObject = io;
            if (Input.GetButtonDown("Fire1")) {
                io.Interact(transform.position + fwd + Vector3(0,1,0), Quaternion.Euler(270,0,0), transform);
            }
        }
    }
    else
    {
       if (previousObject)
       {
          previousObject.SendMessage("UnGlow");
      }
}
}


