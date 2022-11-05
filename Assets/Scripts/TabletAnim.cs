using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TabletAnim : MonoBehaviour
{
    public Texture2D cursorTexture;
    public CursorMode cursorMode = CursorMode.Auto;
    public Vector2 hotSpot = Vector2.zero;

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
        Cursor.SetCursor(cursorTexture, hotSpot, cursorMode);
    }

    //void OnMouseExit()
    //{
    //    Cursor.SetCursor(null, Vector2.zero, cursorMode);
    //}
}
