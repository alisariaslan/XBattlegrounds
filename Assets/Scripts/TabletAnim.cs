using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TabletAnim : MonoBehaviour
{
    public Texture2D cursorTexture;
 
    // Start is called before the first frame update
    void Start()
    {
        SetCursor();
    }

    //// Update is called once per frame
    //void Update()
    //{

    //}

    void StartIdle()
    {
        Animator animator = GetComponent<Animator>();
        animator.Play("tabletStay");
        Cursor.lockState = CursorLockMode.Confined;
        Cursor.visible = true;
    }

    public void SetCursor()
    {
        Cursor.SetCursor(cursorTexture, Vector2.zero, CursorMode.ForceSoftware);
    }

    //void OnMouseExit()
    //{
    //    Cursor.SetCursor(null, Vector2.zero, cursorMode);
    //}
}
