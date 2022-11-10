using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;
using UnityEngine.UI;

public class def_network : NetworkManager
{
    private NetworkManager manager;
    public SendLogs sender;
    public GameObject ui;
    public GameObject ui_cam;
    public InputField input;
    [Header("Launch Settings")]
    public bool startAsClient = false;

    // Start is called before the first frame update
    void Start()
    {
        manager = this;
        //if (startAsClient)
        //{
        //    connectToServer();
        //} else {
        //    startHost();
        //}
      
    }

    // Update is called once per frame
    //void Update()
    //{
        //Debug.Log("connectToServer: " + manager.networkAddress);
    //}


    public void hostStart()
    {
        manager.StartHost();
        Debug.Log("StartHost");
      
    }

    public void connectToServer()
    {
        manager.networkAddress = input.text;
        manager.StartClient();
        Debug.Log("connectToServer: "+manager.networkAddress);
      
    }

    //SERVER/HOST FUNCS

    public virtual void OnServerConnect(NetworkConnection conn)
    {
        //base.OnServerConnect(conn);
        Debug.Log("OnServerConnect");
    }

    public virtual void OnServerDisconnect(NetworkConnection conn)
    {
        //base.OnServerDisconnect(conn);
        Debug.Log("OnServerDisconnect");
    }

    public virtual void OnServerError(NetworkConnection conn, int errorCode)
    {
        Debug.Log("OnServerError: " + errorCode);
    }

    //CLIENT ONLY

    public virtual void OnClientConnect(NetworkConnection conn)
    {
        //base.OnClientConnect(conn);
        Debug.Log("OnClientConnect");
        sender.SendLog("" + conn.address,false);
    }

    public virtual void OnClientDisconnect(NetworkConnection conn)
    {
        //base.OnClientDisconnect(conn);
        Debug.Log("OnClientDisconnect");
      
    }

    public virtual void OnClientError(NetworkConnection conn, int errorCode)
    {
        Debug.Log("OnClientError");
      
    }

    // called when told to be not-ready by a server
    public virtual void OnClientNotReady(NetworkConnection conn)
    {
        Debug.Log("OnClientNotReady");
       
    }

}
