﻿using UnityEngine;
using System.Collections;

public class RNGState {

	public enum Bias {left, right, center}

	public int ticks { get; set; }
	public float bias;

	public float leftBias = -1.5f;
	public float centerBias = 0.0f;
	public float rightBias = 1.5f;

	public int platformCount { get; set; }
	public int enemyCount { get; set; }
	public int itemCount { get; set; }
	public int obstacleCount { get; set; }

	public float[] platformXVariance { get; set; }
	public float[] platformYVariance{ get; set; }

	public float[] enemyXVariance { get; set; }
	public float[] enemyYVariance{ get; set; }

	public float[] itemXVariance { get; set; }
	public float[] itemYVariance{ get; set; }

	public float[] obstacleXVariance { get; set; }
	public float[] obstacleYVariance{ get; set; }

	public RNGState(){
	}

}
