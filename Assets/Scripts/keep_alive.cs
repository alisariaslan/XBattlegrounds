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
    public bool ingame = false;

    private GameObject[] players;
    private def_network def_Network;
    public SelectedPlatform selectedPlatform;
    public GameObject joysticks;

    // Start is called before the first frame update
    void Start()
    {
        def_Network = FindObjectOfType<def_network>();
    }

    // Update is called once per frame
    void Update()
    {
        //if (def_Network.amIclient || def_Network.amIhost)
        //{
        //    players = GameObject.FindGameObjectsWithTag("Player");
        //    if (players.Length > 0)
        //    {
        //        ingame = true;
        //        player_counter_text.text = players.Length.ToString();
        //        ingame_panel.SetActive(true);
        //        ui_panel.SetActive(false);
        //        ui_cam.SetActive(false);
        //    }
        //    else
        //    {
        //        enable_ui();
        //    }
        //}

    }

    public void enable_ui()
    {
        ui_cam.SetActive(true);
        ingame = false;
        ingame_panel.SetActive(false);
        ui_panel.SetActive(true);
        Cursor.visible = true;
        Cursor.lockState = CursorLockMode.None;
        Cursor.SetCursor(null, Vector2.zero, CursorMode.ForceSoftware);
        if (selectedPlatform.device_type.Equals("Handheld"))
        {
            joysticks.SetActive(false);
        }
    }
    
    public void force_leave()
    {
        
    }

    public void gameEntered()
    {
        
    } 

    public void gameHosted()
    {
        players = GameObject.FindGameObjectsWithTag("Player");
        ingame = true;
        player_counter_text.text = players.Length.ToString();
        ingame_panel.SetActive(true);
        ui_panel.SetActive(false);
        ui_cam.SetActive(false);
        if (selectedPlatform.device_type.Equals("Handheld"))
        {
            joysticks.SetActive(true);
        }
        
    }
}
