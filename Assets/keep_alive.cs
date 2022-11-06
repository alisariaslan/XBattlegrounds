using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class keep_alive : MonoBehaviour
{
    public GameObject ui_cam;
    public GameObject ui_panel;
    public GameObject ingame_panel;
    public Text player_counter_text;

    private GameObject[] players;
    
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        players = GameObject.FindGameObjectsWithTag("Player");
       
        if (players.Length > 0)
        {
            player_counter_text.text = players.Length.ToString();
            ingame_panel.SetActive(true);
            ui_panel.SetActive(false);
            ui_cam.SetActive(false);
            
        }
        else
        {
            ingame_panel.SetActive(false);
            ui_panel.SetActive(true);
            ui_cam.SetActive(true);
        }


    }
}
