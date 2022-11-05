using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovementController : MonoBehaviour
{
    public HeadBobbing headBobbing;
    public CharacterController controller;
    public float playerSpeed = 2.0f;
    public float jumpHeight = 1.0f;
    public float gravityValue = -10;
    public float sprintValue = 5;
    private Vector3 playerVelocity;
    private bool groundedPlayer;
    public float x, y;
    public float crouch_speed = 2f;

    // Start is called before the first frame update
    //void Start()
    //{

    //}

    // Update is called once per frame
    void Update()
    {

        groundedPlayer = controller.isGrounded;

        if (groundedPlayer && playerVelocity.y < 0)
        {
            playerVelocity.y = 0f;
        }

        float sprint = 1f;
        if (Input.GetKey(KeyCode.LeftShift))
        {
            sprint = sprintValue;
            headBobbing.bobbingAmount = .035f;
            headBobbing.walkingBobbingSpeed = 15f;
        }
        else
        {
            headBobbing.bobbingAmount = .025f;
            headBobbing.walkingBobbingSpeed = 10f;
        }

        x = Input.GetAxis("Horizontal");
        y = Input.GetAxis("Vertical");

        var camera = Camera.main;

        //camera forward and right vectors:
        Vector3 forward = camera.transform.forward;
        Vector3 right = camera.transform.right;

        //project forward and right vectors on the horizontal plane (y = 0)
        forward.y = 0f;
        right.y = 0f;
        forward.Normalize();
        right.Normalize();

        //this is the direction in the world space we want to move:
        Vector3 desiredMoveDirection = forward * y + right * x;
        controller.Move(desiredMoveDirection * Time.deltaTime * playerSpeed * sprint);


        if (Input.GetButtonDown("Jump") && groundedPlayer)
        {
            playerVelocity.y += Mathf.Sqrt(jumpHeight * -3.0f * gravityValue);
        }
        if (Input.GetKey(KeyCode.C))
        {
            if (controller.height > 1)
               controller.height -= Time.deltaTime * crouch_speed;
        }
        else
        {
            if (controller.height < 2)
               controller.height += Time.deltaTime * crouch_speed;
        }

        playerVelocity.y += gravityValue * Time.deltaTime ;
        controller.Move(playerVelocity * Time.deltaTime);

    }
    
}
