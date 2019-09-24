using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Timer : MonoBehaviour
{
    Text text;
    float theTime;
    public float speed = 1;
    // Start is called before the first frame update
    void Start()
    {
        // assigning the text on the screen
        text = GetComponent<Text>();
    }

    // Update is called once per frame
    void Update()
    {
        theTime += Time.deltaTime * speed;
        // values of the minutes and seconds are in seconds so minutes need to be divided by 60
        string minutes = Mathf.Floor((theTime % 3600)/ 60).ToString("00");
        string seconds = ((theTime % 60).ToString("00"));
        // time is displayed
        text.text = minutes + ":" + seconds; 
    }
}
