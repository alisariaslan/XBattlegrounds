using System.Collections;
using System.Collections.Generic;
using System.Net;
using System.Net.Sockets;
using UnityEngine;
using UnityEngine.UI;

public class get_my_ip : MonoBehaviour
{
	public Text text;
    // Start is called before the first frame update
    void Start()
    {
		IPHostEntry host;
		string localIP = "";
		host = Dns.GetHostEntry(Dns.GetHostName());
		foreach (IPAddress ip in host.AddressList)
		{
			if (ip.AddressFamily == AddressFamily.InterNetwork)
			{
				localIP = ip.ToString();
				break;
			}
		}
		text.text = localIP;
	}

    // Update is called once per frame
    //void Update()
    //{
        
    //}
}
