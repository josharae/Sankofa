using UnityEngine;
using System.Collections;



public class Moo : MonoBehaviour 
{
	public AudioClip clip;


	public GameObject One;
	public GameObject Two;
	public GameObject Three;
	public GameObject Four;
	public GameObject Five;
	public GameObject Six;
	public GameObject Seven;
	public GameObject Eight;
	public GameObject Nine;
	public GameObject Ten;
	public GameObject Eleven;
	public GameObject Twelve;
	public GameObject Thirteen;
	public GameObject Fourteen;

	private float speed = 0.1F;


	private GameObject[] target = new GameObject[14];


	private int Index = 1;

	//private int postNum = 0;
	//private ArrayList<GameObject> posts = new ArrayList<GameObject>();
	//posts.Set(0,from);
	//posts.Add(to);

	void Update()
	{
		target[0] = One;
		target[1] = Two;
		target[2] = Three;
		target[3] = Four;
		target[4] = Five;
		target[5] = Six;
		target[6] = Seven;
		target[7] = Eight;
		target[8] = Nine;
		target[9] = Ten;
		target[10] = Eleven;
		target[11] = Twelve;
		target[12] = Thirteen;
		target[13] = Fourteen;
		//transform.rotation = Quaternion.Slerp(from.transform.rotation, to.transform.rotation, Time.time * speed);
		Vector3 originalPosition = transform.position;
		Vector3 newPosition = (target[Index].transform.position);
		Vector3 offset = new Vector3(originalPosition.x - newPosition.x,originalPosition.y - newPosition.y ,originalPosition.z - newPosition.z); // = (0.5 ; -0.3)
		//float offsetLength =  Mathf.Sqrt(Mathf.Pow(offset.x,2) - Mathf.Pow(offset.z , 2));
		// = (0.5 / 0.583 ; -0.3 / 0.583) =(0.857 ; -0.515) = 
		//   

		// JUST LEFT / RIGHT
		//transform.LookAt(target[Index].transform);
		if(offset.x == 0 && offset.z < 0) //NOPE
		{
			if((Mathf.Abs(offset.z) <=  speed  * 1))
				transform.Translate(-offset.x,-offset.y,-offset.z);
			else
				transform.Translate(0,0,speed);
		}
		else if(offset.x == 0 && offset.z > 0) //YEP
		{
			if((Mathf.Abs(offset.z) <=  speed  * 1))
				transform.Translate(-offset.x,-offset.y,-offset.z);
			else
				transform.Translate(0,0,-speed);
		}


		// JUST Forward / Backward
		
		else if(offset.x < 0 && offset.z == 0) //NOPE
		{
			if((Mathf.Abs(offset.x) <=  speed  * 1))
				transform.Translate(-offset.x,-offset.y,-offset.z);
			else
				transform.Translate(speed,0,0);
		}
		else if(offset.x > 0 && offset.z == 0) //YEP
		{
			if((Mathf.Abs(offset.x) <=  speed  * 1))
				transform.Translate(-offset.x,-offset.y,-offset.z);
			else
				transform.Translate(-speed,0,0);
		}



		//    RIGHT    F/B

		//print(offset.x + "  :  " + offset.z);
		else if(offset.x > 0 && offset.z > 0)   // NOPE
		{
			if(  (  Mathf.Abs(offset.x)  <=  speed  * 1)   &&  ( Mathf.Abs(offset.z)  <=  speed  * 1))
			{
				if((  Mathf.Abs(offset.x)  <=  speed  * 1) &&  (Mathf.Abs(offset.z) <=  speed  * 1))
					transform.Translate(-offset.x,-offset.y,-offset.z);
				else if((  Mathf.Abs(offset.x)  <=  speed  * 1) && ! (Mathf.Abs(offset.z)  <=  speed  * 1))
				   transform.Translate(-offset.x,0,-speed);
				else if((  Mathf.Abs(offset.z)  <=  speed  * 1) && ! (Mathf.Abs(offset.x)  <=  speed  * 1))
					transform.Translate(-speed,0,-offset.z);
			}
			else
			transform.Translate(-speed,0,-speed);

		}
		else if(offset.x > 0 && offset.z < 0) // NOPE
		{
			if(  (  Mathf.Abs(offset.x)  <=  speed)   &&  ( Mathf.Abs(offset.z)  <=  speed  * 1))
			{
				if((  Mathf.Abs(offset.x)  <=  speed  * 1) &&  (Mathf.Abs(offset.z) <=  speed  * 1))
					transform.Translate(-offset.x,-offset.y,-offset.z);
				else if((  Mathf.Abs(offset.x)  <=  speed  * 1) && ! (Mathf.Abs(offset.z) <=  speed  * 1))
					transform.Translate(-offset.x,0,speed);
				else if((  Mathf.Abs(offset.z)  <=  speed  * 1) && ! (Mathf.Abs(offset.x)  <=  speed  * 1))
					transform.Translate(-speed,0,-offset.z);
			}
			else
			transform.Translate(-speed,0,speed);
		}


		//      LEFT     F/B


		else if(offset.x < 0 && offset.z > 0) // NOPE
		{
			if(  (  Mathf.Abs(offset.x)  <=  speed  * 1)   &&  ( Mathf.Abs(offset.z)  <=  speed  * 1))
			{
				if((  Mathf.Abs(offset.x)  <=  speed  * 1) &&  (Mathf.Abs(offset.z) <=  speed  * 1))
					transform.Translate(-offset.x,-offset.y,-offset.z);
				else if((  Mathf.Abs(offset.x)  <=  speed  * 1) && ! (Mathf.Abs(offset.z) <=  speed  * 1))
					transform.Translate(-offset.x,0,-speed);
				else if((  Mathf.Abs(offset.z)  <=  speed  * 1) && ! (Mathf.Abs(offset.x)  <=  speed  * 1))
					transform.Translate(speed,0,-offset.z);
			}
			else
			transform.Translate(speed,0,-speed);
		}
		else if(offset.x < 0 && offset.z < 0) // NOPE
		{
			if(  (  Mathf.Abs(offset.x)  <=  speed  * 1)   &&  ( Mathf.Abs(offset.z)  <=  speed  * 1))
			{
				if((  Mathf.Abs(offset.x)  <=  speed  * 1) &&  (Mathf.Abs(offset.z) <=  speed  * 1))
					transform.Translate(-offset.x,-offset.y,-offset.z);
				else if((  Mathf.Abs(offset.x)  <=  speed  * 1) && ! (Mathf.Abs(offset.z) <=  speed  * 1))
					transform.Translate(-offset.x,0,speed);
				else if((  Mathf.Abs(offset.z)  <=  speed  * 1) && ! (Mathf.Abs(offset.x)  <=  speed  * 1))
					transform.Translate(speed,0,-offset.z);
			}
			else
			transform.Translate(speed,0,speed);
		}





		// SWAP WHERE TO GO

		else
		{
			//                 GO TO NEXT POST                                      print("swap");
			//print("next");
			Index += 1;
			if(Index == 14)
				Index = 0;
		}	

	}

	void OnMouseDown()
	{
		AudioSource.PlayClipAtPoint(clip, transform.position);
	}   
}