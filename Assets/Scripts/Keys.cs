using System.Collections;
using System.Collections.Generic;

using UnityEngine;
using UnityEngine.UI;

public class Keys : MonoBehaviour
{
	public GameObject tablet;
	public GameObject console;
	public keep_alive keepAlive;

	public TabletAnim tabletAnim;
	public Button enter;
	public InputField inputField;
	[HideInInspector()]
	public PlayerControls player;
	[HideInInspector()]
	public MovementController movementController;
	public bool ingame;

	public GameObject triggerTablet;
	public GameObject joyStickL, joyStickR;

	private string device_type;

	void Update()
	{
		ingame = keepAlive.ingame;


		if (Input.GetKeyDown(KeyCode.Tab) && ingame)
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
		if (Input.GetKeyDown(KeyCode.Return))
		{
			if (console.activeSelf)
			{
				enter.onClick.Invoke();
				inputField.ActivateInputField();
			}

		}


	}

	public void SwitchHands(bool isLeft)
	{
		if (isLeft)
			movementController.SwitchMovemementToLeftHand();
		else
			movementController.SwitchMovemementToRightHand();
	}

	public void Tablet()
	{
		tablet.SetActive(!tablet.activeSelf);
		if (tablet.activeSelf)
		{
			player.paused = true;
			Cursor.visible = true;
			Cursor.lockState = CursorLockMode.Confined;
			tabletAnim.SetCursor();
			triggerTablet.SetActive(false);
			
			if (device_type.Equals("Handheld"))
			{
				joyStickL.SetActive(false);
				SwitchHands(false);
			}

		}
		else
		{
			Cursor.SetCursor(null, Vector2.zero, CursorMode.ForceSoftware);
			Cursor.lockState = CursorLockMode.Confined;
			Cursor.visible = false;
			player.paused = false;
			triggerTablet.SetActive(true);
			if (device_type.Equals("Handheld"))
			{
				joyStickL.SetActive(true);
				SwitchHands(true);
			}

		}
	}
	public Text console_txt;
	private void Console()
	{
		console.SetActive(!console.activeSelf);
		if (console.activeSelf)
		{
			if (player != null)
				player.paused = true;
			if (movementController != null)
				movementController.paused = true;
			Cursor.visible = true;
			Cursor.lockState = CursorLockMode.None;
			Cursor.SetCursor(null, Vector2.zero, CursorMode.ForceSoftware);
			inputField.ActivateInputField();
		}
		else
		{
			if (ingame)
			{
				Cursor.SetCursor(null, Vector2.zero, CursorMode.ForceSoftware);
				Cursor.lockState = CursorLockMode.Confined;
				Cursor.visible = false;
				if (player != null)
					player.paused = false;
				if (movementController != null)
					movementController.paused = false;
			}
			console_txt.text = "-> CONSOLE ACTIVATED <-";
		}
	}

	public void SetUi(string device_type)
	{
		this.device_type = device_type;
		if (device_type.Equals("Desktop"))
		{
			SetActivePCItems();
		}
		else if (device_type.Equals("Handheld"))
		{
			SetActiveMobileItems();
			
		}
	}

	public GameObject[] pc_obj;
	public GameObject[] tel_obj;

	public void SetActivePCItems()
	{
		foreach (GameObject item in pc_obj)
		{
			item.SetActive(true);
		}
	}

	public void SetActiveMobileItems()
	{
		foreach (GameObject item in tel_obj)
		{
			item.SetActive(true);
		}
	}
}
