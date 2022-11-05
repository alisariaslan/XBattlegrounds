using System.Collections;
using System.Collections.Generic;

using UnityEngine;

public class Keys : MonoBehaviour
{
    public GameObject tablet;
    public PlayerControls player;
    public TabletAnim tabletAnim;
    // Start is called before the first frame update
    //void Start()
    //{
        
    //}

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            tablet.SetActive(!tablet.activeSelf);
            if (tablet.activeSelf)
            {
                Animator animator = tablet.GetComponent<Animator>();
                animator.Play("tabletOpen");
                player.paused = true;
                tabletAnim.SetCursor();
            }
            else
            {
                Cursor.lockState = CursorLockMode.Locked;
                Cursor.visible = false;
                player.paused = false;
            }
        }
        
    }
}
