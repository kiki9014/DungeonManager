using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LeftButton : MonoBehaviour
{
    CurrentTile currTile;

    // Use this for initialization
    void Start ()
    {
        currTile = (GameObject.Find("current_state") as GameObject).GetComponent("CurrentTile") as CurrentTile;

    }
	
	// Update is called once per frame
	void Update ()
    {
        if (Input.GetKeyDown("a"))
        {
            currTile.MoveToLeft();
        }

    }

    private void OnMouseDown()
    {
        currTile.MoveToLeft();
    }
}
