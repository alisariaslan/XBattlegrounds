using System;
using UnityEngine;
using UnityEngine.UI;

public class GameConsole : MonoBehaviour
{
    public Text textField_;
    public InputField inputField_;
    private static Text textField;
    private static InputField inputField;

    void Start()
    {
        textField = textField_;
        inputField = inputField_;
    }

    public static void NewLog(string text)
    {
        textField.text = $"{DateTime.Now.ToString("HH:mm:ss")} - {text}\n{textField.text}";
    }

    public void SendFromInputBox()
    {
        ExecuteCommand(inputField.text);
        inputField.text = "";
    }

    public static void ExecuteCommand(string text)
    {
        switch (text)
        {
            case "start hosting":
                FindObjectOfType<GameManager>().StartHosting();
                break;
            default:
                NewLog(text);
                break;
        }
    }

}
