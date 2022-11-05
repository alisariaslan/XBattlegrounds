using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class cmd_switch : MonoBehaviour
{
    public SendLogs sendLogs;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void input_module(string input)
    {
        switch (input)
        {
            case "help":
                sendLogs.SendLog("Sadece help komutu mevcut",false);
                break;
            
              
            default:
                sendLogs.SendLog("Gecersiz komut!!",false);
                break;
        }
    }
}
