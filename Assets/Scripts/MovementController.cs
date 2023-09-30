using UnityEngine;

#pragma warning disable CS0618 // Type or member is obsolete
public class MovementController : MonoBehaviour
#pragma warning restore CS0618 // Type or member is obsolete
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
	public new GameObject camera;

	public bool paused = false;

	private GameObject leftJoystick;
	private SimpleTouchController leftController;

	private string device_type;
	public bool isLocal = false;

	private void Start()
	{
		

		isLocal = true;
	}
	// Start is called before the first frame update
	public void StartFromRemote()
	{

		camera.SetActive(true);


		Keys keys = FindObjectOfType<Keys>();
		keys.movementController = this;
		keys.player = GetComponentInChildren<PlayerControls>();

		device_type = FindObjectOfType<SelectedPlatform>().device_type;
		if (device_type.Equals("Handheld"))
		{
			SwitchMovemementToLeftHand();
		}

		
		
		paused = false;

		

	}

	public void SwitchMovemementToLeftHand()
	{
		leftJoystick = GameObject.Find("jStick_left");
		
			leftController = leftJoystick.GetComponent<SimpleTouchController>();
	}
	
	public void SwitchMovemementToRightHand()
	{
		leftJoystick = GameObject.Find("jStick_right");
	
			leftController = leftJoystick.GetComponent<SimpleTouchController>();
	}


	

	// Update is called once per frame
	void Update()
	{

		if (!paused)
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

			if (device_type.Equals("Desktop"))
			{
				x = Input.GetAxis("Horizontal");
				y = Input.GetAxis("Vertical");
			}
			else if (device_type.Equals("Handheld"))
			{
				x = leftController.GetTouchPosition.x;
				y = leftController.GetTouchPosition.y;
			}

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
					controller.height -= Time.fixedDeltaTime * crouch_speed;
			}
			else
			{
				if (controller.height < 2)
					controller.height += Time.fixedDeltaTime * crouch_speed;
			}

			playerVelocity.y += gravityValue * Time.deltaTime;
			controller.Move(playerVelocity * Time.deltaTime);

		}

	}

}
