using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SelectedPlatform : MonoBehaviour
{
    public string m_DeviceType;
    public SendLogs sendlog;
    
    // Start is called before the first frame update
    void Start()
    {
      
        if (SystemInfo.deviceType == DeviceType.Desktop)
        {
            //Change the text of the label
            m_DeviceType = "Desktop";



         
        }
        else if (SystemInfo.deviceType == DeviceType.Handheld)
        {
            m_DeviceType = "Mobile";


        }

        Debug.Log("Device Type: " + m_DeviceType);
        sendlog.SendLog("Device Type: " + m_DeviceType,false);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
