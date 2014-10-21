﻿using UnityEngine;
using System.Collections;


public abstract class Achievement {

	//Boolean which determines if this Achievement is unlocked by the player
	//true = unlocked, false = locked
	protected bool isUnlocked;

	//Unique key which determines an Achievement's identity
	protected string key;
	private bool isDisplayed = false;

	public string getKey() {
		return this.key;
	}

	public void displayAchievement() {

		if (PlayerPrefs.GetInt (this.key) == 0 && this.isUnlocked && !isDisplayed) {
			GameObject achieveText = new GameObject ();
			achieveText.AddComponent<GUIText> ();
			achieveText.transform.position = new Vector3 (0.3f, 0.9f, 0);
			achieveText.guiText.text = "New Achievement: " + this.key;
			achieveText.guiText.material.color = Color.white;
			isDisplayed = true;

			GameObject.Destroy(achieveText,5);
		} 
	}

	//Abstract method to be implemented by classes which subclass Achievement
	//Different subclasses will have different ways to unlock the Achievement
	//Returns true if unlocked, false if locked
	abstract public bool isAchievementUnlocked ();
}
