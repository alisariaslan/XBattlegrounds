using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class sens_slider : MonoBehaviour
{
    public Slider slider;
    private float sens;
    
    void Start()
    {
        sens = PlayerPrefs.GetFloat("MouseSensitivity", 2);
        slider.value = sens;
    }

    public void SaveSensToDatabase()
    {
        sens = slider.value;
        PlayerPrefs.SetFloat("MouseSensitivity", sens);
    }
}
