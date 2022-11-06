using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class intro : MonoBehaviour
{
    //public float blackoutPlayTime = 5f;
    //public float nextSceneloadTime = 10f;

    //private float my_time = 0f;

    //// Start is called before the first frame update
    //void Start()
    //{

    //}

    // Update is called once per frame
    void Update()
    {
        //my_time += Time.deltaTime;
        //Debug.Log("time: "+my_time);
        //if (my_time > blackoutPlayTime)
        //{
        //    GetComponent<Animator>().Play("blackout");
        //}

        if (Input.GetKeyDown(KeyCode.Escape))
        {
            Destroy(GetComponent<Animator>());
            endOfBlackout();
        }


    }

    public void endOfBlackout()
    {
        SceneManager.LoadScene("main");
    }
}
