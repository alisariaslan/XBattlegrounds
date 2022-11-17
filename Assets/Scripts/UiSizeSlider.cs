using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UiSizeSlider : MonoBehaviour
{
    public Slider uiSizeSlider;

	// Start is called before the first frame update
	void Start()
    {	
		int myvalue = PlayerPrefs.GetInt("UiSize", 0);
		uiSizeSlider.value = myvalue;
    }

    // Update is called once per frame
    public void UpdateUiSize()
    {
		PlayerPrefs.SetInt("UiSize",(int) uiSizeSlider.value);
		FindObjectOfType<graphic_settings>().UpdateUIForMobile();
	}
	
}
