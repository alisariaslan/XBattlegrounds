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

    public void SendLog(string text)
    {
        txt.text += "\n"+ DateTime.Now.ToString("HH:mm:ss tt")+" -> "+text;
    }

    public void SendFromInputBox()
    {
        SendLog(inputField.text);
        inputField.text = "";
    }
}
