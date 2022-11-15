using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MainVolumeSlider : MonoBehaviour
{
    public Slider mainVslider;
    // Start is called before the first frame update
    void Start()
    {
        float mainValue = PlayerPrefs.GetFloat("MainVolume", 1);
        mainVslider.value = mainValue;
    }

    // Update is called once per frame
    public void UpdateMainVolume()
    {
        PlayerPrefs.SetFloat("MainVolume", mainVslider.value);
        UpdateAllObjects();
    }

    public void UpdateAllObjects()
    {
		if (FindObjectOfType<MenuCamera>())
			FindObjectOfType<MenuCamera>().ReSOUND();
	}
}
