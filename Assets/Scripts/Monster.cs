using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Monster : MonoBehaviour {

    Level level;

	// Use this for initialization
	void Start () {
        level = GetComponent<Level>();
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public void LevelUp()
    {
        level.LevelUp();
    }
}
