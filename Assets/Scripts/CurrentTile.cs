using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEditor;
using UnityEngine;

public class CurrentTile : MonoBehaviour
{
    GameObject cursor;
    Selector cursor_script;

    List<GameObject> object_list = new List<GameObject>();

    GameObject current_tile;

    int state = 0;

    int max_state = 0;

    [MenuItem("AssetDatabase/loadAllAssetsAtPath")]

    // Use this for initialization
    void Start () {
        var all_prefab = Resources.LoadAll("ObjectToPlace", typeof(GameObject)).Cast<GameObject>();
        Debug.Log(all_prefab.Count());

        var normal_tiles = all_prefab.Where(g => g.tag == "Floor").ToList();
        Debug.Log(normal_tiles.Count);
        object_list.AddRange(normal_tiles);
        var monsters = all_prefab.Where(g => g.tag == "Monster").ToList();
        Debug.Log(monsters.Count);
        object_list.AddRange(monsters);
        var traps = all_prefab.Where(g => g.tag == "Trap").ToList();
        Debug.Log(traps.Count);
        object_list.AddRange(traps);

        cursor = GameObject.Find("SelectSquare") as GameObject;
        cursor_script = cursor.GetComponent(typeof(Selector)) as Selector;

        SetState(state);
        max_state = object_list.Count-1;
	}

    void SetState(int state)
    {
        GameObject obj = object_list[state];
        if (current_tile != null)
            Destroy(current_tile);
        current_tile = Instantiate(obj, transform);
    }
	
	// Update is called once per frame
	void Update ()
    {
        if (Input.GetKeyDown("space"))
            cursor_script.PlaceTile(current_tile);
    }

    public void MoveToLeft()
    {
        if (state != 0)
            state--;
        else
            state = max_state;
        SetState(state);
    }

    public void MoveToRight()
    {
        if (state != max_state)
            state++;
        else
            state = 0;
        SetState(state);
    }

    void UpdateObject()
    {

    }
}
