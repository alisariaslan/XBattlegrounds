using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class helper : MonoBehaviour
{
    public bool startHostNow = false;
    public bool spawnAtEditorCamLocation = false;
    // Start is called before the first frame update
    void Start()
    {
        if(spawnAtEditorCamLocation)
        {
            Camera editor_cam = SceneView.currentDrawingSceneView.camera;
            GameObject start_loc = GameObject.Find("NetworkStartPos");
            start_loc.transform.position = editor_cam.transform.position;
        }
        if(startHostNow)
        {
            FindObjectOfType<def_network>().hostStart();
        }
    }
        
    

    // Update is called once per frame
    //void Update()
    //{
        
    //}
}
