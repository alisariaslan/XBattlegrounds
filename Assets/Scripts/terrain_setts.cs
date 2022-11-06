using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class terrain_setts : MonoBehaviour
{
    private int dist;
    // Start is called before the first frame update
    void Start()
    {
        dist = PlayerPrefs.GetInt("RenderDistance", 500);
        Terrain terrain = GetComponent<Terrain>();
        terrain.treeDistance = dist;
        terrain.treeBillboardDistance = dist / 5;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
