﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Save : Button {

	// Use this for initialization
	void Start () {
        base.Start();
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    private void OnMouseDown()
    {
        Debug.Log("Save");
    }
}
