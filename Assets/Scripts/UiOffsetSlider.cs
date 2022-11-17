using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UiOffsetSlider : MonoBehaviour
{
    public Slider uiOffsetSlider;

    // Start is called before the first frame update
    void Start()
    {
        int myvalue = PlayerPrefs.GetInt("UiOffset", 0);
		uiOffsetSlider.value = myvalue;
    }

    // Update is called once per frame
    public void UpdateUiOffset()
    {
        PlayerPrefs.SetInt("UiOffset",(int) uiOffsetSlider.value);
        FindObjectOfType<graphic_settings>().UpdateUIForMobile();
    }
}
