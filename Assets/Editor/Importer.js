#pragma strict


class ModelProcessor extends AssetPostprocessor
{
  static var numberOfDoors = 0;
  static var squareDoors = 0;
  static var arcDoors = 0;
  function OnPostprocessGameObjectWithUserProperties(go : GameObject, propNames : String[], values : System.Object[])
  {
    for (var i : int = 0; i < propNames.Length; i++)
    {
      var propName : String = propNames[i];
      var value : Object = values[i];
      if(values[i] == "square_door")
      {
        go.AddComponent(Door);
        go.GetComponent(Door).glowMat = Resources.Load("square_door_red") as Material;
        go.GetComponent(Door).currentMat = Resources.Load("square_door") as Material;
            // Debug.Log("Square door added");
            squareDoors++;
            numberOfDoors++;
          }

          else if(values[i] == "arc_door")
          {
            go.AddComponent(Door);
            // Debug.Log("Arc door added");
            go.GetComponent(Door).glowMat = Resources.Load("arc_door_red") as Material;
            go.GetComponent(Door).currentMat = Resources.Load("arc_door") as Material;
            numberOfDoors++;
            arcDoors++;
          }

          else if(values[i] == "wall")
          {
            makeInvisible(go);
            // Debug.Log("Wall added");
          }

          else if(values[i] == "navmesh")
          {
            makeInvisible(go);
            go.GetComponent.<MeshCollider>().enabled = false;
            Debug.Log("Navmesh added");
          }

          else if(values[i] == "zone")
          {
            makeInvisible(go);
            go.AddComponent(Scripts_ZoneEntered);
            go.GetComponent(Scripts_ZoneEntered).fadeTime = 3.0;
            go.GetComponent.<MeshCollider>().convex = true;
            go.GetComponent.<MeshCollider>().isTrigger = true;
            go.tag = "Zone";
            // Debug.Log("Added zone");
            if (go.transform.root != go.transform)
            {
              go.GetComponent(Scripts_ZoneEntered).zoneDescription = go.transform.root.name;
              // Debug.Log(go.name + " is a child with root " + go.transform.root.name);
            }
            else
            {
              Debug.Log("Zone here at " + go.transform.name);
              go.GetComponent(Scripts_ZoneEntered).zoneDescription = go.transform.name;
            }
          }
          else if(values[i] == "minimap")
          {
            Debug.Log("Minimap added");
            go.GetComponent.<Renderer>().shadowCastingMode = go.GetComponent.<Renderer>().shadowCastingMode.Off;
            go.GetComponent.<Renderer>().receiveShadows = false;
            go.layer = LayerMask.NameToLayer("Minimap");
            Debug.Log(go.layer);
            go.GetComponent.<MeshCollider>().enabled = false;
          }
          else if(values[i] == "zoneGroup")
          {
            Debug.Log("Root here at " + go.transform.name);
            checkChildren(go);
          }

        }   
      }

      static function OnPostprocessAllAssets (importedAssets : String[], deletedAssets : String[], movedAssets : String[], movedFromAssetPaths : String[]) {
    // Debug.Log("Number of square doors: " + squareDoors);
    // Debug.Log("Number of arc doors: " + arcDoors);
    // Debug.Log("Number of doors: " + numberOfDoors);

  }

  function makeInvisible(go: GameObject)
  {
    go.GetComponent.<Renderer>().enabled = false;
    go.GetComponent.<Renderer>().shadowCastingMode = go.GetComponent.<Renderer>().shadowCastingMode.Off;
    go.GetComponent.<Renderer>().receiveShadows = false;
  }

  function checkChildren(go: GameObject)
  {
    if (go.transform.childCount > 0)
    {
      Debug.Log("Child here");
    }
  }
}