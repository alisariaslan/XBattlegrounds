using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Sync : MonoBehaviour
{
    // Start is called before the first frame update
    public Toggle tg_vsync;

    void Start()
    {
        tg_vsync.isOn = PlayerPrefs.GetInt("Sync", 1) == 1 ? true : false;
    }

    public void SetSync()
    {
        QualitySettings.vSyncCount = tg_vsync.isOn ? 1 : 0;
        PlayerPrefs.SetInt("Sync", tg_vsync.isOn ? 1 : 0);
    }
}
