using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class selected_graphic_tier : MonoBehaviour
{
	public Text text;
    // Start is called before the first frame update
    void Start()
    {
		int tier = PlayerPrefs.GetInt("VideoTier", 0);
		string level;
		switch (tier)
		{
			case 0:
				level = "Ultra";
				break;
			case 1:
				level = "High";
				break;
			case 2:
				level = "Medium";
				break;
			case 3:
				level = "Low";
				break;
			default:
				level = "Unknown";
				break;

		}
		text.text = level;
	}

    // Update is called once per frame
    //void Update()
    //{
        
    //}
}
