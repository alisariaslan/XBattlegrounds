using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EffectVolumeSlider : MonoBehaviour
{
    public Slider effectVslider;
    // Start is called before the first frame update
    void Start()
    {
        float effectValue = PlayerPrefs.GetFloat("EffectVolume", 1);
        effectVslider.value = effectValue;
    }

    // Update is called once per frame
    public void UpdateEffectVolume()
    {
        PlayerPrefs.SetFloat("EffectVolume", effectVslider.value);
        FindObjectOfType<MainVolumeSlider>().UpdateAllObjects();
    }
}
