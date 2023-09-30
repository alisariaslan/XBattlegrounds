using UnityEngine;

public class SelectedPlatform : MonoBehaviour
{
    public string device_type;
    public bool isMobile = false;

    // Start is called before the first frame update
    void Start()
    {

        //Check if the device running this is a console
        if (SystemInfo.deviceType == DeviceType.Console)
        {
            //Change the text of the label
            device_type = "Console";
        }

        //Check if the device running this is a desktop
        else if (SystemInfo.deviceType == DeviceType.Desktop)
        {
            device_type = "Desktop";
			
			
		}

        //Check if the device running this is a handheld
        else if (SystemInfo.deviceType == DeviceType.Handheld)
        {
            device_type = "Handheld";
		}

        //Check if the device running this is unknown
        else if (SystemInfo.deviceType == DeviceType.Unknown)
        {
            device_type = "Unknown";
        }


        if(isMobile)
        {
            device_type = "Handheld";
        }
		
		FindObjectOfType<Keys>().SetUi(device_type);
		FindObjectOfType<graphic_settings>().device_type = this.device_type;
		FindObjectOfType<graphic_settings>().UpdateGraphics();
		FindObjectOfType<graphic_settings>().UpdateUI();

	}
	
}
