using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;
using UnityEngine.UI;

public class def_network : NetworkManager
{
    public keep_alive keepAlive;
    public SendLogs sender;
    public GameObject ui;
    public GameObject ui_cam;
    public InputField inputIP, inputPort;
    public InputField inputSetPort;


    [Header("Launch Settings")]
    public bool startAsClient = false;

    [HideInInspector()]
    public bool amIhost = false;
    [HideInInspector()]
    public bool amIclient = false;

    private NetworkManager manager;

    void Start()
    {
        manager = this;
    }

    public void start_host()
    {
        manager = this;
        if (!inputSetPort.text.Equals(""))
            manager.networkPort = int.Parse(inputSetPort.text);
        else
            manager.networkPort = 7777;
        manager.networkAddress = "localhost";

        var host = manager.StartHost();
        if (host != null)
        {
            amIhost = true;
            Debug.Log("Host started. -> " + host);
            sender.SendLog("Host started. -> " + host, false);
            status_txt.text = "YOU ARE THE HOST";
            keepAlive.gameHosted();
        }
        else
        {
            amIhost = false;
            Debug.Log("Host failed! -> " + host.ToString());
            sender.SendLog("Host failed! -> " + host.ToString(), false);
        }
    }

    public void stop_host()
    {
        amIclient = false;
        amIhost = false;
        FindObjectOfType<keep_alive>().enable_ui();
        manager.StopHost();
        Debug.Log("Host stopped.");
        sender.SendLog("Host stopped.", false);
        status_txt.text = "";
    }


    public void start_client()
    {
        conn_btn.interactable = false;
        manager = this;

        if (!inputIP.text.Equals(""))
            manager.networkAddress = inputIP.text;
        else
            manager.networkAddress = "localhost";

        if (!inputPort.text.Equals(""))
            manager.networkPort = int.Parse(inputPort.text);
        else
            manager.networkPort = 7777;

        NetworkClient client = manager.StartClient();
        if (client == null)
        {
            conn_btn.interactable = true;
            Debug.Log("Something wrong with client! -> "+ client.ToString());
            sender.SendLog("Something wrong with client! -> " + client.ToString(), false);
        }
        else
        {
            client.RegisterHandler(MsgType.Disconnect, OnClientError); //OnError is registered here
            //NetworkServer.Listen(7777);
            //client.RegisterHandler(MsgType.Connect, OnClientConnect); //Connect is registered here
            Debug.Log("Attemp to connect -> " + manager.networkAddress+":"+manager.networkPort);
            sender.SendLog("Attemp to connect -> " + manager.networkAddress + ":" + manager.networkPort, false);
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
        if (GameObject.FindGameObjectsWithTag("Player").Length > 1)
            OnClientConnect();
        else if (connect_attempting)
            StartCoroutine(Connecting());
    }

    public Text status_txt;
    void OnClientError(NetworkMessage netMsg)
    {
        if (FindObjectOfType<keep_alive>().ingame)
            status_txt.text = "YOU HAVE LOST THE CONNECTION!";
        else
        {
            StopCoroutine(Connecting());
            amIclient = false;
            Debug.Log("Client failed!");
            sender.SendLog("Client failed!", false);
            connect_attempting = false;
            conn_btn_txt.text = "Connect";
            conn_btn.interactable = true;
        }
    }

    void OnClientConnect()
    {
        StopCoroutine(Connecting());
        amIclient = true;
        Debug.Log("Client started. -> " + client);
        sender.SendLog("Client started. -> " + client, false);
        connect_attempting = false;
        conn_btn_txt.text = "Connect";
        conn_btn.interactable = true;
        status_txt.text = "";
    }

    public void stop_client()
    {
        manager.StopClient();
        Debug.Log("Client stopped.");
        sender.SendLog("Client stopped.", false);
        status_txt.text = "";
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
