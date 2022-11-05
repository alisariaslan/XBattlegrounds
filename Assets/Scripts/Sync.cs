using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Sync : MonoBehaviour
{
    // Start is called before the first frame update
    public Toggle t0;

    void Start()
    {
        t0.isOn = PlayerPrefs.GetInt("Sync", 1) == 1 ? true : false;
    }

    public void SetSync()
    {
        QualitySettings.vSyncCount = t0.isOn ? 1 : 0;
        PlayerPrefs.SetInt("Sync", t0.isOn ? 1 : 0);
    }
}
