using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class fps_counter_set : MonoBehaviour
{
	public Toggle toggle;
	// Start is called before the first frame update
	void Start()
	{
		int isActive = PlayerPrefs.GetInt("FpsCounter", 0);
		if (isActive == 1)
			toggle.isOn = true;
	}

	// Update is called once per frame
	public void UpdateCounterSettings()
	{
		int isActive = toggle.isOn ? 1 : 0;
		PlayerPrefs.SetInt("FpsCounter", isActive);
		FindObjectOfType<graphic_settings>().UpdateUI();
	}

}
