using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hole : MonoBehaviour
{

    int level = 0;
    public Sprite[] number;
    GameObject levelNum;

    // Use this for initialization
    void Start ()
    {
        var levelObj = new GameObject();
        levelNum = Instantiate(levelObj, transform.position - new Vector3(0, 0, 0.1f), transform.rotation, transform);
        LevelUp();

    }
	
	// Update is called once per frame
	void Update () {

    }

    public void LevelUp()
    {
        level++;
        levelNum.AddComponent<SpriteRenderer>().sprite = number[level];
    }

    private void OnDestroy()
    {
        Destroy(levelNum);
    }
}
