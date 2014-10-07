﻿using UnityEngine;
using System.Collections;

public class CollapsingPlatform : Platform {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		destoryIfOffScreen ();
	}

	void OnCollisionExit2D(Collision2D col) {
		if (col.gameObject.tag == Tags.TAG_PLAYER) {
			Destroy(gameObject);
		}

	}
}
