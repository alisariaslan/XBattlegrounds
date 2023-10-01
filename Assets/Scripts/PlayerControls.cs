using UnityEngine;
using UnityEngine.UI;

public class PlayerControls : MonoBehaviour
{
    private Vector2 sensitivity;
    private Vector2 smoothing;
    private Vector2 _mouseAbsolute;
    private Vector2 _smoothMouse;
    private Vector2 targetDirection;
    private Vector2 targetCharacterDirection;

    public bool lockCursor;
    public bool paused = false;
    public GameObject characterBody;
    public Vector2 clampInDegrees = new Vector2(360, 180);

    public float sens, smooth;
    private Slider sensS, smoothS;

    private string device_type;

    private SimpleTouchController rightController;


	void Start()
    {
        //if (!isLocalPlayer)
        //{
        //    defaultCamera.SetActive(false);
        //    return;
        //}
        device_type = FindObjectOfType<PlatformManager>().device_type;
        
        if (lockCursor)
        {
            Cursor.lockState = CursorLockMode.Confined;
            Cursor.visible = false;
        }
        // Set target direction to the camera's initial orientation.
        targetDirection = transform.localRotation.eulerAngles;
        targetCharacterDirection = characterBody.transform.localRotation.eulerAngles;
        if (device_type.Equals("Handheld"))
        {
            rightController = GameObject.Find("jStick_right").GetComponent<SimpleTouchController>();
        }
    }

    void Update()
    {
        //if (!isLocalPlayer)
        //    return;
        sens = PlayerPrefs.GetFloat("MouseSensitivity", 2);
        smooth = PlayerPrefs.GetFloat("MouseSmoothing", 3);

        if (!paused)
        {
            sensitivity = new Vector2(sens, sens);
            smoothing = new Vector2(smooth, smooth);

            // Allow the script to clamp based on a desired target value.
            var targetOrientation = Quaternion.Euler(targetDirection);
            var targetCharacterOrientation = Quaternion.Euler(targetCharacterDirection);

            // Get raw mouse input for a cleaner reading on more sensitive mice.
            float x = 0, y = 0;
            if (device_type.Equals("Desktop"))
            {
                x = Input.GetAxisRaw("Mouse X");
                y = Input.GetAxisRaw("Mouse Y");
            }
            else if (device_type.Equals("Handheld"))
            {
                x = rightController.GetTouchPosition.x;
                y = rightController.GetTouchPosition.y;
            }
            var mouseDelta = new Vector2(x, y);

            // Scale input against the sensitivity setting and multiply that against the smoothing value.
            mouseDelta = Vector2.Scale(mouseDelta, new Vector2(sensitivity.x * smoothing.x, sensitivity.y * smoothing.y));

            // Interpolate mouse movement over time to apply smoothing delta.
            _smoothMouse.x = Mathf.Lerp(_smoothMouse.x, mouseDelta.x, 1f / smoothing.x);
            _smoothMouse.y = Mathf.Lerp(_smoothMouse.y, mouseDelta.y, 1f / smoothing.y);

            // Find the absolute mouse movement value from point zero.
            _mouseAbsolute += _smoothMouse;

            // Clamp and apply the local x value first, so as not to be affected by world transforms.
            if (clampInDegrees.x < 360)
                _mouseAbsolute.x = Mathf.Clamp(_mouseAbsolute.x, -clampInDegrees.x * 0.5f, clampInDegrees.x * 0.5f);

            // Then clamp and apply the global y value.
            if (clampInDegrees.y < 360)
                _mouseAbsolute.y = Mathf.Clamp(_mouseAbsolute.y, -clampInDegrees.y * 0.5f, clampInDegrees.y * 0.5f);

            var xRotation = Quaternion.AngleAxis(-_mouseAbsolute.y, targetOrientation * Vector3.right);
            transform.localRotation = xRotation * targetOrientation;

            var yRotation = Quaternion.AngleAxis(_mouseAbsolute.x, characterBody.transform.up);
            characterBody.transform.localRotation = yRotation;
            characterBody.transform.localRotation *= targetCharacterOrientation;
        }


    }





}
