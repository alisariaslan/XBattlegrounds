using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class server_list_btn : MonoBehaviour
{
	public Text text;
	// Start is called before the first frame update
	private string ParseAndReturnIP(string text)
	{
		string[] parsedTexts = text.Split('|');
		for (int i = 0; i < parsedTexts.Length; i++)
		{
			parsedTexts[i] = parsedTexts[i].Trim();
		}
		return parsedTexts[1];
	}

	// Update is called once per frame
	public void Connect()
    {
		string ip = ParseAndReturnIP(text.text);
		GameObject.Find("btn_join_w_ip").GetComponent<Button>().onClick.Invoke();
		GameObject.Find("input_ip").GetComponent<InputField>().text = ip;
		
    }
}
