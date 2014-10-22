﻿using UnityEngine;
using System.Collections;


public class ScenarioGameObjectFactory : GameObjectFactory {

	private GameObject newPlatform;
	private GameObject newItem;
	private GameObject newEnemy;
	private GameObject newObstacle;

	private int ypos = -2;
	private int xpos = 2;

	private RNGStateGenerator rng = new EndlessRNGStateGenerator();

	private int length;

	
	GameObject currentPlatform;

	public ScenarioGameObjectFactory(){
		rng.generateNextState ();

		switch (DifficultyManager.Instance.CURRENT_DIFFICULTY) {
		case DifficultyManager.Difficulty.easy:
			length = 20;
			break;
		case DifficultyManager.Difficulty.medium:
			length = 50;
			break;
		case DifficultyManager.Difficulty.hard:
			length = 100;
			break;
				}
	}

	public void setRNGDependency(RNGStateGenerator dependency){
		this.rng = dependency;
		}

	public override void generateLevelStart(){
		float y = -1.0f;
		for (int i = 0; i < 9; i ++) {
			rng.generateNextState();
			float lastX = generateOneTickPlatforms(y, (i==0));
			if(i == 0){
				GameObject player = GameObject.FindGameObjectWithTag (Tags.TAG_PLAYER);
				Vector3 temp = new Vector3(lastX + rng.currentRNGState.platformXVariance[rng.currentRNGState.platformCount-1],rng.currentRNGState.platformYVariance[rng.currentRNGState.platformCount-1],0.0f);
				player.transform.Translate(temp);
			}
			generateOneTickItems (y+.75f);
			generateOneTickEnemies (y,(i==0));
		//	generateOneTickObstacles (y);
			y += 2.75f;
		}
	}


	public override void generateTick(){
		for (int i = 0; i < this.length; i++) {
			rng.generateNextState ();
			
			float height = 17.0f;
			generateOneTickPlatforms (height, false);
			generateOneTickItems (height+.75f);
			generateOneTickEnemies (height,false);
				}
	}


	private float generateOneTickPlatforms(float y, bool firstTick){
		float currentX = 0.0f;
		switch (rng.currentRNGState.platformCount) {
		case(1):
			currentX = 0.0f;
			break;
		case(2):
			currentX = -2.0f;
			break;
		case(3):
			currentX = -4.0f;
			break;
		case(4):
			currentX = -6.0f;
			break;
		case(5):
			currentX = -8.0f;
			break;
		}
		
		for (int j = 0; j < rng.currentRNGState.platformCount; j++) {
			if(!firstTick){
				switch(rng.currentRNGState.platformTypes[j]){
				case RNGState.platformType.standard:
					this.newPlatform = (GameObject)Instantiate (Resources.Load ("Prefabs/Platforms/" + "pref_standard_platform"));
					break;
				case RNGState.platformType.collapsing:
					this.newPlatform = (GameObject)Instantiate (Resources.Load ("Prefabs/Platforms/" + "pref_collapsing_platform"));
					break;
				case RNGState.platformType.moving:
					this.newPlatform = (GameObject)Instantiate (Resources.Load ("Prefabs/Platforms/" + "pref_moving_platform"));
					break;
				}
			} else {
				this.newPlatform = (GameObject)Instantiate (Resources.Load ("Prefabs/Platforms/" + "pref_standard_platform"));
			}

				this.newPlatform.transform.position = new Vector3 (currentX + rng.currentRNGState.platformXVariance[j], y + rng.currentRNGState.platformYVariance[j], 0.0f);

			currentX += 4.0f;
		}

		return currentX - 4.0f;
	}

	private void generateOneTickItems(float y){

		float currentX = 0.0f;
		switch (rng.currentRNGState.itemCount) {
		case(1):
			currentX = 0.0f;
			break;
		case(2):
			currentX = -2.0f;
			break;
		case(3):
			currentX = -4.0f;
			break;
		case(4):
			currentX = -6.0f;
			break;
		case(5):
			currentX = -8.0f;
			break;
		}
		for (int j = 0; j < rng.currentRNGState.itemCount; j++) {
			switch(rng.currentRNGState.itemTypes[j]){
			case RNGState.itemType.healthy:
				this.newItem = (GameObject)Instantiate (Resources.Load ("Prefabs/Items/" + "pref_healthyfood"));
				break;
			case RNGState.itemType.junk:
				this.newItem = (GameObject)Instantiate (Resources.Load ("Prefabs/Items/" + "pref_junkfood"));
				break;
			case RNGState.itemType.none:
				this.newItem = null;
				var temp = 0;
				break;
			}
			try{
				this.newItem.transform.position = new Vector3 (currentX + rng.currentRNGState.itemXVariance[j], y + rng.currentRNGState.itemYVariance[j], 0.0f);
			}catch (System.Exception e) {
				Debug.Log("Exception " + e);
			}
			currentX += 4.0f;
		}

	}

	private void generateOneTickEnemies(float y, bool firstTick){
		float currentX = 0.0f;
		switch (rng.currentRNGState.enemyCount) {
		case(1):
			currentX = 0.0f;
			break;
		case(2):
			currentX = -2.0f;
			break;
		case(3):
			currentX = -4.0f;
			break;
		case(4):
			currentX = -6.0f;
			break;
		case(5):
			currentX = -8.0f;
			break;
		}
		for (int j = 0; j < rng.currentRNGState.enemyCount; j++) {
			if(!firstTick){
				switch(rng.currentRNGState.enemyTypes[j]){
				case RNGState.enemyType.patrol:
					this.newEnemy = (GameObject)Instantiate (Resources.Load ("Prefabs/Enemies/" + "pref_basic_enemy"));
					break;
				case RNGState.enemyType.falling:
					this.newEnemy = (GameObject)Instantiate (Resources.Load ("Prefabs/Enemies/" + "pref_falling_enemy"));
					break;
				case RNGState.enemyType.shooting:
					this.newEnemy = (GameObject)Instantiate (Resources.Load ("Prefabs/Enemies/" + "Shooting_enemy"));
					break;
//				case RNGState.enemyType.stationary:
//					this.newEnemy = (GameObject)Instantiate (Resources.Load ("Prefabs/Enemies/" + "pref_stationary_enemy"));
//					break;
				case RNGState.enemyType.none:
					this.newEnemy = null;
					var temp = 0;
					break;
				}
			} 
			try{
				this.newEnemy.transform.position = new Vector3 (currentX + rng.currentRNGState.enemyXVariance[j], y + rng.currentRNGState.enemyYVariance[j], 0.0f);
			}catch (System.Exception e) {
				Debug.Log("Exception " + e);
			}
			currentX += 4.0f;
		}
	}


}
