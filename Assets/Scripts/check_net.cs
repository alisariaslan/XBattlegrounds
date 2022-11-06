using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class check_net : MonoBehaviour
{
    public Image image;
    public Sprite connect;
    public Sprite disconnect;
    public Text text;
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(CheckInternet());

    }

    private IEnumerator CheckInternet()
    {
        Check();

        yield return new WaitForSeconds(1.0f);

        StartCoroutine(CheckInternet());
    }
    
    void Check()
    {
        if (Application.internetReachability == NetworkReachability.NotReachable)
        {
            //Debug.Log("Error. Check internet connection!");
            text.text = "Disconnected!";
            image.sprite = disconnect;
        }
        else
        {
            //Debug.Log("Internet connection is OK!");
            text.text = "Connected.";
            image.sprite = connect;
        }
    }
}
