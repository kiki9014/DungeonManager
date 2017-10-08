using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Level : MonoBehaviour
{
    int level;
    Sprite[] number;
    GameObject levelNum;

    // Use this for initialization
    void Start ()
    {
        level = 0;
        number = Resources.LoadAll<Sprite>("Sprites/Numbers1-sheet");
        Debug.Log(number.Length);
        var levelObj = new GameObject();
        levelNum = Instantiate(levelObj, transform.position - new Vector3(0, 0, 0.1f), transform.rotation, transform);
        levelNum.name = name + "'s level";
        Debug.Log(levelNum);
        levelNum.AddComponent<SpriteRenderer>().sprite = number[level];
        Destroy(levelObj);
        LevelUp();

    }
	
	// Update is called once per frame
	void Update () {

    }

    public void LevelUp()
    {
        Debug.Log(level);
        levelNum.GetComponent<SpriteRenderer>().sprite = number[level];
        level = level + 1;
    }

    private void OnDestroy()
    {
        Destroy(levelNum);
    }
}
