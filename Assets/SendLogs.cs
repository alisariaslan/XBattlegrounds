using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SendLogs : MonoBehaviour
{
    public Text txt;
    public InputField inputField;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void SendLog(string text,bool send_to_cmd)
    {
        txt.text += "\n"+ DateTime.Now.ToString("HH:mm:ss tt")+" -> "+text;
        if(send_to_cmd)
        FindObjectOfType<cmd_switch>().input_module(text);
    }

    public void SendFromInputBox()
    {
        SendLog(inputField.text,true);
        inputField.text = "";
    }
}
