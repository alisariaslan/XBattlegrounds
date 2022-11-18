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
	public bool alreadyStart = false;
    // Start is called before the first frame update
    void Start()
    {
        def_Network = FindObjectOfType<def_network>();
    }

    // Update is called once per frame
    void Update()
    {
        if(ingame)
        {
            players = GameObject.FindGameObjectsWithTag("Player");
            player_counter_text.text = players.Length.ToString();
			
			if(!alreadyStart)
			{
				foreach (GameObject player in players)
				{
					if (player.GetComponent<MovementController>().isLocal)
					{
						player.GetComponent<MovementController>().StartRemote();
						alreadyStart = true;
						return;
					}
				}
			}
			
		}

    }

    public void enable_ui()
    {
		ingame = false;
		alreadyStart = false;
		ui_cam.SetActive(true);
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

	public void disable_ui()
	{
		ui_cam.SetActive(false);
		
		ingame_panel.SetActive(true);
		ui_panel.SetActive(false);
		Cursor.visible = false;
		Cursor.lockState = CursorLockMode.Confined;
		Cursor.SetCursor(null, Vector2.zero, CursorMode.ForceSoftware);
		if (selectedPlatform.device_type.Equals("Handheld"))
		{
			joysticks.SetActive(true);
		}
		ingame = true;
	}

	public void gameConnected()
    {
		disable_ui();
	}
}
