﻿using UnityEngine;
using System.Collections;

public class Phase2_script_GiwaAttack : MonoBehaviour
{
	GameObject player;
	public GameObject arenaPosition;
	private float MaxSpeed = 30;
	private bool isStunned = false, isSleeping = true, isChasing = false;
	Vector3 originalPosition;
	Quaternion originalRotation;
	float currentRate, initialRate = 0.02f, chargingTime = 5f;


	void Start()
	{
		player = GameObject.Find ("Player");
		originalPosition = this.transform.position;
		originalRotation = this.transform.rotation;
		currentRate = initialRate;
	}

	void FixedUpdate()
	{
		if(Vector3.Distance(this.transform.position,player.transform.position) < 150)
		{
			if(!isChasing){
				chargingTime = 5f;
				if(isStunned){
					chargingTime += 3f;
					isStunned = false;
				}
				Invoke ("charge",chargingTime);
			}
			else if(isChasing){
				//transform.LookAt(player.transform);
				Vector3 target = new Vector3(player.transform.position.x, this.transform.position.y, player.transform.position.z);
				transform.LookAt(target);
              //  Quaternion.LookRotation(new Vector3(player.transform.position.x, this.transform.position.y, player.transform.position.z) - this.transform.position);
				currentRate+=Time.deltaTime;
				float vel = Mathf.Lerp(0,MaxSpeed,currentRate);
				Vector3 movement = transform.forward * vel;
				Debug.Log(vel);
				movement.y = GetComponent<Rigidbody> ().velocity.y;
				//GetComponent<Rigidbody> ().AddRelativeForce(movement);
                transform.position += MaxSpeed * transform.forward * Time.deltaTime;
				//transform.Translate(MaxSpeed*Vector3.forward*Time.deltaTime);
			}
			//	this.GetComponent<Rigidbody>().AddRelativeForce(Vector3.forward * MaxSpeed);
		}
	}

	void charge()
	{
		isChasing = true;
		CancelInvoke ();
	}

	void resetPosition(){
		this.GetComponent<Rigidbody> ().velocity = Vector3.zero;
		this.GetComponent<Rigidbody> ().angularVelocity = Vector3.zero;
		this.transform.position = arenaPosition.transform.position;
		this.transform.rotation = originalRotation;
		currentRate = initialRate;
		isChasing = false;
	}

	void OnCollisionEnter(Collision other){
		if (other.gameObject.tag == Tags.Boulder || other.gameObject.tag == Tags.Player) {
			isStunned = true;
			resetPosition();
		}

		else if (other.gameObject.tag == Tags.WaterSpirit) {
			isSleeping = false;

		}
	}
}