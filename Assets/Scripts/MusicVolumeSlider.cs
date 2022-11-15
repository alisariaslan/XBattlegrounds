using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MusicVolumeSlider : MonoBehaviour
{
    public Slider musicVslider;
    // Start is called before the first frame update
    void Start()
    {
        float musicValue = PlayerPrefs.GetFloat("MusicVolume", 1);
        musicVslider.value = musicValue;
    }

    // Update is called once per frame
    public void UpdateMusicVolume()
    {
        PlayerPrefs.SetFloat("MusicVolume", musicVslider.value);
        FindObjectOfType<MainVolumeSlider>().UpdateAllObjects();
    }
    
}
