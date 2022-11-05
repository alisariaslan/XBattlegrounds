using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Sync : MonoBehaviour
{
    // Start is called before the first frame update
    public Toggle toggle;
    void Start()
    {
        QualitySettings.vSyncCount = 1;
        toggle.isOn = true;
    }

    // Update is called once per frame
    //void Update()
    //{

    //}

    public void Toggle()
    {
        if(toggle.isOn)
        {
            QualitySettings.vSyncCount = 1;
        } else
        {
            QualitySettings.vSyncCount = 0;
        }
    }
}
