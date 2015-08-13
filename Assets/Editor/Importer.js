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
            go.GetComponent.<Renderer>().enabled = false;
            go.GetComponent.<Renderer>().shadowCastingMode = go.GetComponent.<Renderer>().shadowCastingMode.Off;
            go.GetComponent.<Renderer>().receiveShadows = false;
            // Debug.Log("Wall added");
          }
          
          else if(values[i] == "navmesh")
          {
            go.GetComponent.<Renderer>().enabled = false;
            go.GetComponent.<Renderer>().shadowCastingMode = go.GetComponent.<Renderer>().shadowCastingMode.Off;
            go.GetComponent.<Renderer>().receiveShadows = false;
            go.GetComponent.<MeshCollider>().enabled = false;
            Debug.Log("Navmesh added");
          }
      }   
  }

  static function OnPostprocessAllAssets (importedAssets : String[], deletedAssets : String[], movedAssets : String[], movedFromAssetPaths : String[]) {
    // Debug.Log("Number of square doors: " + squareDoors);
    // Debug.Log("Number of arc doors: " + arcDoors);
    // Debug.Log("Number of doors: " + numberOfDoors);

  }
}