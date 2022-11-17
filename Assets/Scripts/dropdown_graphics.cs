using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class dropdown_graphics : MonoBehaviour
{
	public Dropdown dropdown;
	
    // Start is called before the first frame update
    void Start()
    {
		int tier = PlayerPrefs.GetInt("VideoTier", 0);
		dropdown.value = tier;
	}

	public void UpdateTier()
	{
		PlayerPrefs.SetInt("VideoTier", dropdown.value);
		FindObjectOfType<graphic_settings>().UpdateGraphics();
	}

}
