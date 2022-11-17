using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering.PostProcessing;
using UnityStandardAssets.Water;

public class graphic_settings : MonoBehaviour
{
	public RectTransform joyStickL, joyStickR;
	public Terrain terrain;
	public GameObject waterAdvanced, waterSimple;
	public Material superSimpleWaterShader;  
	private DepthOfField water_dof;
	public GameObject post_proces_obj;

	//// Start is called before the first frame update
	//void Start()
	//{

	//     terrain = GetComponent<Terrain>();


	//}

	//// Update is called once per frame
	//void Update()
	//{

	//    float dist = PlayerPrefs.GetInt("RenderDistance", 500);
	//    terrain.treeDistance = dist;
	//    terrain.treeBillboardDistance = dist / 5;
	//}
	public string device_type;
	public void UpdateGraphics()
	{
		float tier = PlayerPrefs.GetInt("VideoTier", 0);
		pp_settings pp = FindObjectOfType<pp_settings>();
		if (device_type.Equals("Desktop"))
		{
			terrain.detailObjectDistance = 250 - (tier * 50);
			terrain.detailObjectDensity = .25f - (tier / 50);
			terrain.treeDistance = 250 - (tier * 50);
			terrain.treeBillboardDistance = 250 - (tier * 50);
			if (tier >= 2)
			{
				waterSimple.SetActive(true);
				waterAdvanced.SetActive(false);
			}
			else
			{
				waterAdvanced.SetActive(true);
				waterSimple.SetActive(false);
			}
		}
		else if (device_type.Equals("Handheld"))
		{
			waterSimple.SetActive(true);
			waterSimple.GetComponent<MeshRenderer>().material = superSimpleWaterShader;
			waterSimple.GetComponent<PostProcessVolume>().profile.TryGetSettings<DepthOfField>(out water_dof);
			water_dof.active = false;
			post_proces_obj.SetActive(false);
			////pp.tg_doff.isOn = false;
			
			terrain.detailObjectDistance = 125 - (tier * 50 / 2);
			terrain.detailObjectDensity = .125f - (tier / 50 * 1.5f);
			terrain.treeDistance = 125 - (tier * 50 / 2);
			terrain.treeBillboardDistance = 125 - (tier * 50 / 2);
		}


	}

	public void UpdateGraphicsForMobile(int tier)
	{
		PlayerPrefs.SetInt("VideoTier", tier);
		UpdateGraphics();
	}

	public void UpdateUIForPC()
	{

	}

	public void UpdateUIForMobile()
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
