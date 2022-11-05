using System.Collections;
using System.Collections.Generic;

using UnityEngine;
using UnityEngine.UI;

public class Keys : MonoBehaviour
{
    public GameObject tablet;
    public GameObject console;
    public PlayerControls player;
    public MovementController movementController;
    public TabletAnim tabletAnim;
    public Button enter;
    public InputField inputField;
    // Start is called before the first frame update
    //void Start()
    //{

    //}

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Tab))
        {
            if (console.activeSelf)
                Console();
            Tablet();
        }
        if (Input.GetKeyDown(KeyCode.BackQuote))
        {
            if (tablet.activeSelf)
                Tablet();
            Console();
        }
        if(Input.GetKeyDown(KeyCode.Return))
        {
            if (console.activeSelf)
            {
                enter.onClick.Invoke();
                inputField.ActivateInputField();
            }
               
        }
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (tablet.activeSelf)
                Tablet();
            if (console.activeSelf)
                Console();
        }

    }

    private void Tablet()
    {
        tablet.SetActive(!tablet.activeSelf);
        if (tablet.activeSelf)
        {
            player.paused = true;
            tabletAnim.SetCursor();
        }
        else
        {
            WindowsClosed();
        }
    }

    private void Console()
    {
        console.SetActive(!console.activeSelf);
        if (console.activeSelf)
        {
            player.paused = true;
            movementController.paused = true;
            Cursor.visible = true;
            Cursor.lockState = CursorLockMode.None;
        }
        else
        {
            WindowsClosed();
        }
    }

    private void WindowsClosed()
    {
        Cursor.SetCursor(null, Vector2.zero, CursorMode.ForceSoftware);
        Cursor.lockState = CursorLockMode.Confined;
        Cursor.visible = false;
        player.paused = false;
        movementController.paused = false;
    }
}
