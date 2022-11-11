using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class input_port_host : MonoBehaviour
{
    public InputField input;

    // Start is called before the first frame update
    void Start()
    {
        input.text = PlayerPrefs.GetString("LastHostedPort", "");
    }

    // Update is called once per frame
    public void SaveDatabase()
    {
        PlayerPrefs.SetString("LastHostedPort", input.text);
    }
}
