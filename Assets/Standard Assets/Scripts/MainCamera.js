#pragma strict

private var previousObject : InteractiveObject;

static var audioGameObject : GameObject;
static var triggerBox : Transform;

function Awake() {
}

function Start() {
}

function Update() {


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

    		if (Input.GetButtonDown("Fire1"))
    		{
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

// static function Interrupted() {
//     if(audioGameObject)
//     {
//         if(audioGameObject.GetComponent.<Trigger>())
//         {
//             var trigger : Trigger = audioGameObject.GetComponent.<Trigger>();
//             if(trigger.narration.isPlaying)
//             {
//                 trigger.narration.Stop();
//                 trigger.StopCoroutine("WaitForNarrationEnds");
                
//                 if(trigger.nextTrigger)
//                 {
//                     trigger.nextTrigger.SetActive(true);
//                     trigger.gameObject.SetActive(false);
//                 }

//                 var tmpio : InteractiveObject = Instantiate(triggerBox, trigger.transform.position, Quaternion.Euler(0,0,0)).GetComponent.<InteractiveObject>();

//                 tmpio.audiosource.clip = trigger.narration.clip;
//             }
//         }
//         else if(audioGameObject.GetComponent.<InteractiveObject>())
//         {
//             var io : InteractiveObject = audioGameObject.GetComponent.<InteractiveObject>();
//             if(io.audiosource.isPlaying)
//             {
//                 io.audiosource.Stop();
//             }
//         }
//     }
// }
