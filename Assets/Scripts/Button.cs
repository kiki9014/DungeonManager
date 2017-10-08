using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Button : MonoBehaviour {

    Sprite[] font;

	// Use this for initialization
	protected virtual void Start () {
        font = Resources.LoadAll<Sprite>("Sprites/Font");

        string buttonName = name;
        Debug.Log(buttonName);
        GameObject emptyObj = new GameObject();
        for (int i = 0; i < buttonName.Length; i++)
        {
            var obj = Instantiate(emptyObj, transform.position - new Vector3(((buttonName.Length - 1) / 2 - i) * 0.1f + 0.05f,0,0), transform.rotation, transform);
            obj.name = buttonName[i].ToString();
            obj.AddComponent<SpriteRenderer>().sprite = font[buttonName[i] - 'A'];
        }
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
