﻿using UnityEngine;
using System.Collections;
using FightGame;
public class inputtest : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		Debug.Log("player 1" + GameManager.P1.Fighter.currentAction.ToString());
		Debug.Log("player 2" + GameManager.P2.Fighter.currentAction.ToString());
	}
	
}
