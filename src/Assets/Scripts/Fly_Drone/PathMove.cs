﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PathMove : MonoBehaviour {

	// Use this for initialization
	void Start () {
        iTween.MoveTo(gameObject, iTween.Hash("path", iTweenPath.GetPath("path1"), "time", 30, "easetype", iTween.EaseType.linear));
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
