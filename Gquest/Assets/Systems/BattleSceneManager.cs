﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BattleSceneManager : MonoBehaviour {

	// Use this for initialization
	void Start () {
        if(GameObject.Find("ButtonsPanel")) 
        GameObject.Find("ButtonsPanel").SetActive(false);
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
