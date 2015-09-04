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

function OnGUI() {
    if(miniMap.enabled == true)
    {
        var objPos = GetComponent.<Camera>().WorldToViewportPoint(player.transform.position);
        
        var meAngle = player.transform.eulerAngles.y ;
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