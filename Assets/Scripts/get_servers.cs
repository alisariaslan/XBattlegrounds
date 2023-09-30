using System.Collections;
using System.Net.NetworkInformation;
using System.Net.Sockets;
using UnityEngine;
using UnityEngine.UI;

public class get_servers : MonoBehaviour
{
	public GameObject template;
	public GameObject content;
	public Sprite online, lan, favorite, history;
	public string lastType;

	void Start()
	{
		CallGetServers();
	}

	public void ClearContent()
	{
		foreach (Transform child in content.transform)
		{
			Destroy(child.gameObject);
		}
	}

	public void CallLastType()
	{
		switch (lastType)
		{
			case "#lan":
				CallGetLAN();
				break;
			default:
				CallGetServers();
				break;
		}
	}

	public void CallGetServers()
	{
		StartCoroutine(GetServers());
	}

	public void CallGetLAN()
	{
		StartCoroutine(GetLAN());
	}

	IEnumerator GetServers()
	{
		//string url = "http://localhost:8080/get_servers.php";
		//string url = "http://
		yield return new WaitForSeconds(1.0f);
	}

	IEnumerator GetLAN()
	{
		//IPHostEntry host;
		//host = Dns.GetHostEntry(Dns.GetHostName());
		//foreach (IPAddress ip in host.AddressList)
		//{
		//	AddToContent("#lan", ip.ToString(), "1/30", "Massacre Island", lan);
		//}

		NetworkInterface[] nics = NetworkInterface.GetAllNetworkInterfaces();
		foreach (NetworkInterface adapter in nics)
		{
			foreach (var x in adapter.GetIPProperties().UnicastAddresses)
			{
				if (x.Address.AddressFamily == AddressFamily.InterNetwork && x.IsDnsEligible)
				{
					AddToContent("#lan", x.Address.ToString(), "1/30", "Massacre Island", lan);
				}
			}
		}

		//NetworkInterface[] nics = NetworkInterface.GetAllNetworkInterfaces();

		//foreach (NetworkInterface adapter in nics)
		//{
		//	if (adapter.OperationalStatus == OperationalStatus.Up)
		//	{
		//		if (adapter.NetworkInterfaceType == NetworkInterfaceType.Wireless80211)
		//		{
		//			//Console.WriteLine("Wifi");
		//			AddToContent("#lan", adapter.GetPhysicalAddress().ToString(), "1/30", "Massacre Island", lan);
		//		}
		//		else
		//		{
		//			//Console.WriteLine("do your work");
		//			AddToContent("#lan", adapter.GetPhysicalAddress().ToString(), "1/30", "Massacre Island", lan);
		//		}
		//	}
		//}

		//var addresses = Dns.GetHostEntryAsync((Dns.GetHostName()))
		//		.Result
		//		.AddressList
		//		.Where(x => x.AddressFamily == AddressFamily.InterNetwork)
		//		.Select(x => x.ToString())
		//		.ToArray();

		//foreach (var address in addresses)
		//{
		//	AddToContent("#lan", address, "1/30", "Massacre Island", lan);
		//}

		//string[] strIP = null;
		//int count = 0;

		//IPHostEntry HostEntry = Dns.GetHostEntry((Dns.GetHostName()));
		//if (HostEntry.AddressList.Length > 0)
		//{
		//	strIP = new string[HostEntry.AddressList.Length];
		//	foreach (IPAddress ip in HostEntry.AddressList)
		//	{
		//		if (ip.AddressFamily == AddressFamily.InterNetwork)
		//		{
		//			strIP[count] = ip.ToString();
		//			count++;
		//		}
		//	}
		//}

		//foreach (string str in strIP)
		//{
		//	AddToContent("#lan", str, "1/30", "Massacre Island", lan);
		//}

		yield return new WaitForSeconds(0.0f);
	}

	

	//void OnConnected(NetworkMessage netMsg)
	//{
	//	Debug.Log("Client connected");
	//}

	public void AddToContent(string type, string ip, string players, string map_name, Sprite sprite)
	{

		GameObject cpy = Instantiate(template, content.transform);
		cpy.GetComponentInChildren<Text>().text = type + " | " + ip + " | " + players + " | " + map_name;
		cpy.transform.GetChild(0).GetComponent<Image>().sprite = sprite;
		lastType = type;
	}

}
