#pragma strict

var player: GameObject;
var maps: GameObject[];
var currentMap: int;
var personTexture: Texture;
var miniMap: Camera;

private var camDisplacement = 100;
private var position: Rect;

function Start () {
    currentMap = 0;
}

function Update () {
    transform.position.x = player.transform.position.x;
    transform.position.z = player.transform.position.z;
    if (Input.GetButtonDown("MiniMapToggle")) {
        miniMap.enabled = !miniMap.enabled;
    }
}

function changeCurrentMap()
{
    if (maps.length > 1)
    {
        for (var i = 0; i < maps.length; i++) 
        {
            if (i == currentMap) {
                return;
            }
            else
            {
                maps[i].GetComponent.<Renderer>().enabled = false;
            }   
        }
    } 
}

function OnGUI() {
    if(miniMap.enabled == true)
    {
        var objPos = GetComponent.<Camera>().WorldToViewportPoint(player.transform.position);

        var meAngle = player.transform.eulerAngles.y - 180;
        var guiRotationMatrix: Matrix4x4 = GUI.matrix; // set up for GUI rotation
        var pivotMe : Vector2;
        pivotMe.x = Screen.width * (miniMap.rect.x + (objPos.x * miniMap.rect.width));
        pivotMe.y = Screen.height * (1 - (miniMap.rect.y + (objPos.y * miniMap.rect.height)));
        GUIUtility.RotateAroundPivot(meAngle, pivotMe);
        
        GUI.DrawTexture(new Rect(Screen.width * (miniMap.rect.x + (objPos.x * miniMap.rect.width)) - 7.5,
            Screen.height * (1 - (miniMap.rect.y + (objPos.y * miniMap.rect.height))) - 7.5,
            15, 15), personTexture);

        GUI.matrix = guiRotationMatrix; //end GUI rotation                    
    }
}

// Tutorial used for this script found at https://www.hive-rd.com/blog/unity3d-basic-minimap-tutorial/



// #pragma strict

// var player: GameObject;
// var maps: GameObject[];
// var currentMap: int;
// var personTexture: Texture;

// private var camDisplacement = 100;
// private var position: Rect;

// function Start () {
//     currentMap = 0;
//     position = Rect(148, Screen.height - 122, 15, 15);
// }

// function Update () {
//     this.transform.position = new Vector3(player.transform.position.x, 
//         maps[currentMap].transform.position.y + camDisplacement,player.transform.position.z);

// }

// function OnGUI() {

//     GUI.DrawTexture(position, personTexture);
// }