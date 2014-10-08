﻿using UnityEngine;
using System.Collections;

public class levelSelection : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void OnGUI(){

		GUI.skin.label.fontSize = 30;

		GUI.skin.label.alignment = TextAnchor.LowerCenter;

		if (GUI.Button (new Rect (Screen.width * 0.1f, Screen.height * 0.05f, Screen.width * 0.8f, Screen.height * 0.2f), "Endless")) {
			LevelSelection.CURRENT_THEME = Theme.endless;
			LevelSelection.LEVEL = 1;
			Application.LoadLevel("scn_mock");	
		}

		GUI.Label (new Rect(Screen.width * 0.1f, Screen.height * 0.35f, Screen.width * 0.25f, Screen.height * 0.2f), "Story");



		if (GUI.Button (new Rect(Screen.width * 0.35f, Screen.height * 0.35f, Screen.width * 0.1f, Screen.height * 0.2f), "1")) {
			LevelSelection.CURRENT_THEME = Theme.story;
			LevelSelection.LEVEL = 1;
			Application.LoadLevel("scn_mock");	
		}

		if (GUI.Button (new Rect(Screen.width * 0.55f, Screen.height * 0.35f, Screen.width * 0.1f, Screen.height * 0.2f), "2")) {
			LevelSelection.CURRENT_THEME = Theme.story;
			LevelSelection.LEVEL = 2;
			Application.LoadLevel("scn_mock");	
		}

		if (GUI.Button (new Rect(Screen.width * 0.75f, Screen.height * 0.35f, Screen.width * 0.1f, Screen.height * 0.2f), "3")) {
			LevelSelection.CURRENT_THEME = Theme.story;
			LevelSelection.LEVEL = 3;
			Application.LoadLevel("scn_mock");	
		}


		GUI.Label (new Rect(Screen.width * 0.1f, Screen.height * 0.65f, Screen.width * 0.25f, Screen.height * 0.2f), "Xmas");

		if (GUI.Button (new Rect (Screen.width * 0.35f, Screen.height * 0.75f, Screen.width * 0.1f, Screen.height * 0.2f), "1")) {
			LevelSelection.CURRENT_THEME = Theme.xmas;
			LevelSelection.LEVEL = 1;
			Application.LoadLevel("scn_mock");	
				}

		if (GUI.Button (new Rect (Screen.width * 0.55f, Screen.height * 0.75f, Screen.width * 0.1f, Screen.height * 0.2f), "2")) {
			LevelSelection.CURRENT_THEME = Theme.xmas;
			LevelSelection.LEVEL = 2;
			Application.LoadLevel("scn_mock");	
				};

		if (GUI.Button (new Rect (Screen.width * 0.75f, Screen.height * 0.75f, Screen.width * 0.1f, Screen.height * 0.2f), "3")) {
			LevelSelection.CURRENT_THEME = Theme.xmas;
			LevelSelection.LEVEL = 3;
			Application.LoadLevel("scn_mock");	
				};

	}
}
