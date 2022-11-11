using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class input_ip_connect : MonoBehaviour
{
    public InputField input;

    // Start is called before the first frame update
    void Start()
    {
        input.text = PlayerPrefs.GetString("LastConnectedIP", "");
    }

    // Update is called once per frame
    public void SaveDatabase()
    {
        PlayerPrefs.SetString("LastConnectedIP", input.text);
    }
}
