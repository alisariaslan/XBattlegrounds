using UnityEngine;
using UnityEngine.UI;

public class GeneralSettingsSetter : MonoBehaviour
{
	public string PrefsValue;
	public string PrefsDefaultValue;

	// Start is called before the first frame update
	void Start()
	{
		string isActive = PlayerPrefs.GetString(PrefsValue, PrefsDefaultValue);
		if (isActive.Equals("true"))
		 	gameObject.GetComponent<Toggle>().isOn = true;
	}

	// Update is called once per frame
	public void UpdateSettings()
	{
		string isActive = gameObject.GetComponent<Toggle>().isOn ? "true" : "false";
		PlayerPrefs.SetString("FpsCounter", isActive);
		//FindObjectOfType<GraphicManager>().UpdateUI();
	}

}
