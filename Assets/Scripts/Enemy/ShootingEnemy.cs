﻿using UnityEngine;
using System.Collections;

public class ShootingEnemy : Enemy {
	
	int moveSpeed = 5;
	int touches = 0;
	int count = 0;

	float vertExtent;
	float horzExtent;
	
	float width;
	float height;
	
	bool isDead = false;
	
	// Use this for initialization
	void Start () {
		rigidbody2D.velocity = new Vector2(moveSpeed, 0); // assigning the speed at the start
	}
	 
	// Update is called once per frame
	void Update () {

		HandleShoot();

		vertExtent = Camera.main.camera.orthographicSize;
		horzExtent = vertExtent * Screen.width / Screen.height; 
		
		width = renderer.bounds.size.x / 2 + 0.5f; 
		height = renderer.bounds.size.y / 2 + 0.5f;
		
		if( !isDead ) {
			handleBirdMovement();
			handleTouchCollisions();
		}
		
		destoryIfOffScreen ();
		
	}

	void HandleShoot() {
		var player = GameObject.FindGameObjectWithTag("player");
		if (player != null){
			if (player.transform.position.y < gameObject.transform.position.y) {
				count = count + 1;	
				if (count % 150 == 0) {
					float distance = player.transform.position.x - gameObject.transform.position.x;
					int temp = -1;
					if (distance > 0) {
						temp = 1;
					}
					count = 0;
					var	currentPos = (GameObject) Instantiate(Resources.Load ("Prefabs/Items/" + "pref_junkfood"), gameObject.transform.position,Quaternion.identity);
					currentPos.rigidbody2D.velocity =  (GameObject.FindGameObjectWithTag("player").transform.position - gameObject.transform.position) / 2;
				}
			}
		}
	}

	
	// handles user touching screen
	void handleTouchCollisions() {
		if (Input.touchCount > 0) { // if user has touched the screen
			
			touches = Input.touchCount; 
			var touch = Input.GetTouch (touches - 1); // getting the last touch
			var touchPos = Camera.main.ScreenToWorldPoint (touch.position); // converting to correct co-ord system
			
			// if user touches the gameObject
			if (touchPos.x > (transform.position.x - width) && touchPos.x < (width + transform.position.x)) {
				if (touchPos.y > (transform.position.y - height) && touchPos.y < (height + transform.position.y)) {
					handleDeath();
				}
			}
		}
		
	}
	
	// handles the bird movement
	void handleBirdMovement() {
		
		if (transform.position.x < (horzExtent * -1 + width)) 
		{
			rigidbody2D.velocity = new Vector2(moveSpeed,0);	
		} else if ( transform.position.x > (horzExtent - width)) 
		{
			rigidbody2D.velocity = new Vector2(- 1 * moveSpeed,0);	
			
		}
	}
	
	void handleDeath() {
		Destroy(gameObject);
	}
	
	void OnCollisionEnter2D(Collision2D col) {
		
		if (col.gameObject.name == "KiwiBird") {
			// if player is above alien, kill alien and make player jump.
			if (col.gameObject.transform.position.y > gameObject.transform.position.y) {
				Destroy(gameObject)	;
				
				PlayerController other = (PlayerController) col.gameObject.GetComponent(typeof(PlayerController));
				other.boostPlayer(); // making the player jump
			} else {
				rigidbody2D.velocity = new Vector2(moveSpeed, 0); // assigning the speed at the start
			}
		}
	}
}

























