using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerControls : MonoBehaviour
{
    public bool lockCursor;
    public bool paused = false;
    //public MovementController movementController;
    public GameObject characterBody;
    public GameObject defaultCamera;
    public Vector2 clampInDegrees = new Vector2(360, 180);
   
    public Slider senSlider, smoothSlider;

    private Vector2 sensitivity;
    private Vector2 smoothing;
    private Vector2 _mouseAbsolute;
    private Vector2 _smoothMouse;
    private Vector2 targetDirection;
    private Vector2 targetCharacterDirection;

    void Start()
    {
        if (lockCursor)
        {
            Cursor.lockState = CursorLockMode.Locked;
            Cursor.visible = false;
        }
        // Set target direction to the camera's initial orientation.
        targetDirection = transform.localRotation.eulerAngles;
        targetCharacterDirection = characterBody.transform.localRotation.eulerAngles;
        //LOAD SENS SETTINGS
        senSlider.value = PlayerPrefs.GetFloat("MouseSensitivity", 2);
       smoothSlider.value = PlayerPrefs.GetFloat("MouseSmoothing", 3);
    }

    void Update()
    {
        if (!paused)
        {
            sensitivity = new Vector2(senSlider.value, senSlider.value);
            smoothing = new Vector2(senSlider.value, senSlider.value);
            
            // Allow the script to clamp based on a desired target value.
            var targetOrientation = Quaternion.Euler(targetDirection);
            var targetCharacterOrientation = Quaternion.Euler(targetCharacterDirection);

            // Get raw mouse input for a cleaner reading on more sensitive mice.
            var mouseDelta = new Vector2(Input.GetAxisRaw("Mouse X"), Input.GetAxisRaw("Mouse Y"));

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

    public void SaveSensToDatabase()
    {
        PlayerPrefs.SetFloat("MouseSensitivity", senSlider.value);
    }

    public void SaveSmoothingToDatabase()
    {
        PlayerPrefs.SetFloat("MouseSmoothing", smoothSlider.value);
    }

}