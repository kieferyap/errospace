﻿using UnityEngine;
using System.Collections;
using System.Collections.Generic;


public class rocketMover : MonoBehaviour {

	public static float range = 10000;
	public bool isActive;
	public Transform planet;
	Collider2D firstCollider;
	public int starCount = 0;
	private int previousStarCount = 0;

	void OnTriggerEnter2D(Collider2D collider){
		firstCollider = collider;


	}
	
	void OnColliderExit2D(Collider2D collider){
		firstCollider = null;
	}
	/*
	void Start(){
		rigidbody2D.velocity = new Vector2 (0, 2);
	}*/
	void Update(){
		//print (firstCollider.transform.name);
		if (firstCollider != null && firstCollider.transform.name == "Star") {
			starCount+=1;
			Destroy(firstCollider.gameObject);
			firstCollider = null;
		}

		if(isActive){			
			print("making trails.");
			trailMaker.Instance.makeTrail(transform.position);
			// firstCollider != null && firstCollider.transform.name != "LevelBoundaries" 
			Vector3 offset = transform.position - planet.transform.position;
			float mag = offset.magnitude;
			offset.Normalize ();
			print(offset);
			Vector2 force = new Vector2 (offset.x / mag / mag, offset.y / mag / mag);
			
			rigidbody2D.velocity = rigidbody2D.velocity - force;
		}
		else{
			rigidbody2D.velocity = new Vector2 (0, 0);
		}
	}

}
