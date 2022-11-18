using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;
using UnityEngine.UI;

public class cmd_switch : MonoBehaviour
{

	public SendLogs sendLogs;
	public def_network def_Network;
	public GameObject ui_cam;

	public GameObject errorPanel;
	public Text errorHeader;
	public Text errorText;

	public void input_module(string input)
	{
		string[] input_split = input.Split(' ');

		if (input_split.Length == 1)
			switch (input)
			{
				case "help":
					sendLogs.SendLog("help -> Shows you list of commands.", false);
					sendLogs.SendLog("kill -> Kills the player.", false);
					sendLogs.SendLog("leave -> Stops host OR stops Client.", false);
					break;
				case "leave":
					if (def_Network.amIhost)
					{
						def_Network.stop_host();
						sendLogs.SendLog("Manual host stop requested...", false);
					}
					else
					{
						def_Network.stop_client();
						sendLogs.SendLog("Manual client stop requested...", false);
					}
					break;


				default:
					sendLogs.SendLog("Invalid command! Write \"help\" for another commands.", false);
					break;
			}
		else
		{
			string allText = "";
			foreach (string s in input_split)
			{
				allText += s + " ";
			}
			
			switch (input_split[0])
			{
				case "error":
					errorHeader.text = input_split[1];

					errorText.text = allText;
					errorPanel.SetActive(true);
					break;
			}
			
		}
	}
}
