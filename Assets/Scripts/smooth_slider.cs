using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class smooth_slider : MonoBehaviour
{
    public Slider slider;
    private float smooth;

    void Start()
    {
        smooth = PlayerPrefs.GetFloat("MouseSmoothing", 3);
        slider.value = smooth;
    }

    public void SaveSmoothingToDatabase()
    {
        smooth = slider.value;
        PlayerPrefs.SetFloat("MouseSmoothing", smooth);
    }
}
