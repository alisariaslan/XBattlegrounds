using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;

public class cmd_switch : MonoBehaviour
{
 
    
    public SendLogs sendLogs;

#pragma warning disable CS0618 // Type or member is obsolete
    public NetworkManager networkManager;
#pragma warning restore CS0618 // Type or member is obsolete
                              //public Camera camera;
    public GameObject destoryThis;
    // Start is called before the first frame update
    //void Start()
    //{
        
    //}

    //// Update is called once per frame
    //void Update()
    //{
        
    //}

    public void input_module(string input)
    {
        switch (input)
        {
            case "help":
                sendLogs.SendLog("Sadece help komutu mevcut",false);
                break;
            case "sclient":
                destoryThis.SetActive(false);
                networkManager.StartClient();
                break;
            case "sserver":
                networkManager.StartServer();
                break;
            case "shost":
                if(destoryThis!=null)
                destoryThis.SetActive(false);
                if(!networkManager.IsClientConnected())
                    networkManager.StartHost();
                else
                    sendLogs.SendLog("Zaten bir sunucu var", false);
                break;

            default:
                sendLogs.SendLog("Gecersiz komut!!",false);
                break;
        }
    }
}
