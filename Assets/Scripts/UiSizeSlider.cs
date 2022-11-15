using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UiSizeSlider : MonoBehaviour
{
    public Slider uiSizeSlider;

	public RectTransform joyStickL, joyStickR;

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
		UpdateAllUISize();
	}

	public void UpdateAllUISize()
	{
		float my_size = PlayerPrefs.GetInt("UiSize", 0);
		float my_offset = PlayerPrefs.GetInt("UiOffset", 0);
		my_size++;
		my_offset++;
		
			joyStickL.sizeDelta = (new Vector2(200 * my_size, 200 * my_size));
			joyStickL.anchoredPosition = (new Vector2(100 * (my_offset), 100 * (my_offset)));
			joyStickR.sizeDelta = (new Vector2(200 * my_size, 200 * my_size));
			joyStickR.anchoredPosition = (new Vector2(-100 * (my_offset), 100 * (my_offset)));

		
	}
}
