using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class terrain_setts : MonoBehaviour
{


    public Terrain terrain;
    // Start is called before the first frame update
    void Start()
    {

         terrain = GetComponent<Terrain>();


    }

    // Update is called once per frame
    void Update()
    {
      
        float dist = PlayerPrefs.GetInt("RenderDistance", 500);
        terrain.treeDistance = dist;
        terrain.treeBillboardDistance = dist / 5;
    }
}
