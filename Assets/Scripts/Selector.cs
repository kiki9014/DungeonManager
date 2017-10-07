using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Selector : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}

    public GameObject PlaceTile (GameObject obj)
    {
        float height = 0;
        switch (obj.tag)
        {
            case "Floor":
                height = 0.1f;
                break;
            case "Monster":
                height = 0.4f;
                break;
            case "Trap":
                height = 0.3f;
                break;
            default:
                break;
        }
        Vector3 currPose = Vector3.ProjectOnPlane(transform.position, new Vector3(0, 0, 1.0f));
        currPose = currPose - new Vector3(0, 0, height);

        return Instantiate(obj, currPose, transform.rotation);
    }
	
	// Update is called once per frame
	void Update () {
        
        if (Input.GetKeyDown("up"))
            transform.Translate(new Vector3(0, 0.1f, 0));
        if (Input.GetKeyDown("down"))
            transform.Translate(0, -0.1f, 0);
        if (Input.GetKeyDown("left"))
            transform.Translate(-0.1f, 0, 0);
        if (Input.GetKeyDown("right"))
            transform.Translate(0.1f, 0, 0);

    }
}
