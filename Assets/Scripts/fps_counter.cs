using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class fps_counter : MonoBehaviour
{
	Text text; 
    // Start is called before the first frame update
    void Start()
    {
		text = GetComponent<Text>();
    }
	int current;
	// Update is called once per frame
	void Update()
    {
		current = (int)(1f / Time.unscaledDeltaTime);
		text.text = current.ToString();
	}
}
