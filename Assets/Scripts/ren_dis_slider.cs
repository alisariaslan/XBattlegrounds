using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ren_dis_slider : MonoBehaviour
{
    private int dist;
    private Slider slider;
    private Terrain terrain;
    // Start is called before the first frame update
    void Start()
    {
        terrain = FindObjectOfType<Terrain>();
        slider = GetComponent<Slider>();
        dist = PlayerPrefs.GetInt("RenderDistance", 500);
        slider.value = dist;
    }

    // Update is called once per frame
    //void Update()
    //{

    //}

    public void SaveRenderDistanceToDatabase()
    {
        dist = (int) slider.value;
        PlayerPrefs.SetFloat("RenderDistance", dist);
        terrain.treeDistance = dist;
        //terrain.basemapDistance = dist;
        terrain.treeBillboardDistance = dist/5;
        //terrain.detailObjectDistance = dist;
    }
}
