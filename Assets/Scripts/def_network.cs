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

    [HideInInspector()]
    public bool amIhost = false;
    [HideInInspector()]
    public bool amIclient = false;

    void Start()
    {
        manager = this;
    }

    public void start_host()
    {
        manager = this;
        var host = manager.StartHost();
        if (host != null)
        {
            amIhost = true;
            Debug.Log("Host started. -> " + host);
            sender.SendLog("Host started. -> " + host, false);
        }
        else
        {
            amIhost = false;
            Debug.Log("Host failed!");
            sender.SendLog("Host failed!", false);
        }
    }

    public void stop_host()
    {
        manager.StopHost();
        Debug.Log("Host stopped.");
        sender.SendLog("Host stopped.", false);
    }


    public void start_client()
    {
       
        conn_btn.interactable = false;
        manager = this;
        manager.networkAddress = input.text;
        NetworkClient client  = manager.StartClient();
        if(client == null)
        {
            conn_btn.interactable = true;
            Debug.Log("Something wrong with ip adress! -> input: " + input.text);
            sender.SendLog("Something wrong with ip adress! -> input: " + input.text, false);
        } else
        {
            client.RegisterHandler(MsgType.Disconnect, OnClientError); //OnError is registered here
            client.RegisterHandler(MsgType.Connect, OnClientConnect); //Connect is registered here
            Debug.Log("Attemp to connect -> " + manager.networkAddress);
            sender.SendLog("Attemp to connect -> " + manager.networkAddress, false);
            connect_attempting = true;
            StartCoroutine(Connecting());
        }
       
    }
    public Button conn_btn;
    public Text conn_btn_txt;
    private bool connect_attempting = false;
    private IEnumerator Connecting()
    {
        conn_btn_txt.text = "Connecting.";
        yield return new WaitForSeconds(1.0f);
        conn_btn_txt.text = "Connecting..";
        yield return new WaitForSeconds(1.0f);
        conn_btn_txt.text = "Connecting...";
        yield return new WaitForSeconds(1.0f);
        if (connect_attempting)
        StartCoroutine(Connecting());
    }
    
    void OnClientError(NetworkMessage netMsg)
    {
        StopCoroutine(Connecting());
        amIclient = false;
        Debug.Log("Client failed!");
        sender.SendLog("Client failed!", false);
        connect_attempting = false;
        conn_btn_txt.text = "Connect";
        conn_btn.interactable = true;
    }

    void OnClientConnect(NetworkMessage netMsg)
    {
        StopCoroutine(Connecting());
        amIclient = true;
        Debug.Log("Client started. -> " + client);
        sender.SendLog("Client started. -> " + client, false);
        connect_attempting = false;
        conn_btn_txt.text = "Connect";
        conn_btn.interactable = true;
    }

    public void stop_client()
    {
        manager.StopClient();
        Debug.Log("Client stopped.");
        sender.SendLog("Client stopped.", false);
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
        sender.SendLog("" + conn.address, false);
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
