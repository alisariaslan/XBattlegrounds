using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class sens_slider : MonoBehaviour
{
    private float sens;
    private Slider slider;
        //smooth
        
    // Start is called before the first frame update
    void Start()
    {
        slider = GetComponent<Slider>();
        sens = PlayerPrefs.GetFloat("MouseSensitivity", 2);
        slider.value = sens;
    }

    // Update is called once per frame
    //void Update()
    //{

    //}

    public void SaveSensToDatabase()
    {
        sens = slider.value;
        PlayerPrefs.SetFloat("MouseSensitivity", sens);
        FindObjectOfType<PlayerControls>().sens = sens;
    }

    //public void SaveSmoothingToDatabase(Slider slider)
    //{
    //    PlayerPrefs.SetFloat("MouseSmoothing", slider.value);
    //    smooth = slider.value;
    //}
}
