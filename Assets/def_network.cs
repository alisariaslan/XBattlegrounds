using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;

public class def_network : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    // Create a server and listen on a port
    //public void SetupServer()
    //{
    //    NetworkServer.Listen(4444);
    //    isAtStartup = false;
    //}

    //// Create a client and connect to the server port
    //public void SetupClient()
    //{
    //    myClient = new NetworkClient();
    //    myClient.RegisterHandler(MsgType.Connect, OnConnected);
    //    myClient.Connect("127.0.0.1", 4444);
    //    isAtStartup = false;
    //}

    //// Create a local client and connect to the local server
    //public void SetupLocalClient()
    //{
    //    myClient = ClientScene.ConnectLocalServer();
    //    myClient.RegisterHandler(MsgType.Connect, OnConnected);
    //    isAtStartup = false;
    //}
}
