using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MenuCamera : MonoBehaviour
{
  
 
    // Start is called before the first frame update
    //void Start()
    //{
    //    ReSOUND();
    //}

    public void ReSOUND()
    {
        float mainValue, musicValue, effectValue;
        mainValue = PlayerPrefs.GetFloat("MainVolume", 1);
        musicValue = PlayerPrefs.GetFloat("MusicVolume", 1);
        effectValue = PlayerPrefs.GetFloat("EffectVolume", 1);
        this.GetComponent<AudioSource>().volume = mainValue * musicValue;
    }
	
	public void OnEnable()
	{
		ReSOUND();
	}


}
