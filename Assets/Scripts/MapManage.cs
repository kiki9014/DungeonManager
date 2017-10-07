using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MapManage : MonoBehaviour {

    Dictionary<Vector2, GameObject> map = new Dictionary<Vector2, GameObject>();
    Dictionary<Vector2, GameObject> monster_list = new Dictionary<Vector2, GameObject>();
    Dictionary<Vector2, GameObject> trap_list = new Dictionary<Vector2, GameObject>();

    Dictionary<string, Dictionary<Vector2, GameObject>> grid = new Dictionary<string, Dictionary<Vector2, GameObject>>();

    Dictionary<string, Vector2> singularPoint = new Dictionary<string, Vector2>();

    // Use this for initialization
    void Start () {
        grid.Add("Floor", map);
        grid.Add("Monster", monster_list);
        grid.Add("Trap", trap_list);
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public void PlaceTile(Vector3 position, Quaternion rotation,GameObject obj)
    {
        Vector2 coord = new Vector2(Mathf.Round(position.x*10), Mathf.Round(position.y*10));
        string key = obj.tag;

        if (map.ContainsKey(coord) && map[coord].name.StartsWith("Start") && key != "Floor")
            return;

        RemoveTile(position, obj.tag);
        var newObj = Instantiate(obj, position, rotation);
        newObj.name = newObj.name.Split('(')[0];
        grid[key].Add(coord, newObj);
        RemoveDuplicated(newObj.name, newObj.tag);

        if (newObj.name.StartsWith("Start")|| newObj.name.StartsWith ("Goal"))
        {
            singularPoint.Add(newObj.name, coord);
        }
    }

    public void RemoveTile(Vector3 position, string tag)
    {
        Vector2 coord = new Vector2(Mathf.Round(position.x * 10), Mathf.Round(position.y * 10));

        if (grid[tag].ContainsKey(coord))
        {
            GameObject objToRemove = grid[tag][coord];
            if (grid[tag].Remove(coord))
            {
                Destroy(objToRemove);
            }
        }
    }

    void RemoveDuplicated(string key, string tag)
    {
        Debug.Log(key+", " +tag);
        if (singularPoint.ContainsKey(key))
        {
            Vector2 singlePoint = singularPoint[key];
            if (singularPoint.Remove(key))
            {
                GameObject objToRemove = grid[tag][singlePoint];
                if (grid[tag].Remove(singlePoint))
                    Destroy(objToRemove);
            }

        }
    }
}
