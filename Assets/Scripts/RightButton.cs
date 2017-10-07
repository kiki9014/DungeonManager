using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RightButton : MonoBehaviour {
    CurrentTile currTile;

	// Use this for initialization
	void Start () {
        currTile = (GameObject.Find("current_state") as GameObject).GetComponent("CurrentTile") as CurrentTile;
	}
	
	// Update is called once per frame
	void Update ()
    {
        if (Input.GetKeyDown("d"))
        {
            currTile.MoveToRight();
        }

    }

    private void OnMouseDown()
    {
        currTile.MoveToRight();
    }
}
