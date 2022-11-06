using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class smooth_slider : MonoBehaviour
{
    private float smooth;
    private Slider slider;
    // Start is called before the first frame update
    void Start()
    {
        slider = GetComponent<Slider>();
        smooth = PlayerPrefs.GetFloat("MouseSmoothing", 3);
        slider.value = smooth;
    }

    // Update is called once per frame
    //void Update()
    //{

    //}

    public void SaveSmoothingToDatabase()
    {
        smooth = slider.value;
        PlayerPrefs.SetFloat("MouseSmoothing", smooth);
        FindObjectOfType<PlayerControls>().smooth = smooth;
    }
}
