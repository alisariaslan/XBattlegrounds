using UnityEngine;

public class GraphicManager : MonoBehaviour
{
	public RectTransform joyStickL, joyStickR;

	public GameObject waterAdvanced, waterSimple;
	public Material superSimpleWaterShader;  
	public GameObject post_proces_obj;
	public GameObject fps_counter;


	public void UpdateUI(string device)
	{
		string fpsC = PlayerPrefs.GetString("FpsCounter", "false");
		if (fpsC.Equals("true"))
		{
			fps_counter.SetActive(true);
		}
		else
		{
			fps_counter.SetActive(false);
		}
		
		if (device.Equals("Desktop"))
		{
			
		} else
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
	
}
