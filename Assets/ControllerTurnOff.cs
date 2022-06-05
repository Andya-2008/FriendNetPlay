using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ControllerTurnOff : MonoBehaviour
{
    // Start is called before the first frame update
    float startTime;
    void Start()
    {
        startTime = Time.time;
    }

    // Update is called once per frame
    void Update()
    {
        if(PlayerPrefs.GetString("PlayerType")=="Dev")
        if(Time.time-startTime > 1)
        {
            this.gameObject.SetActive(false);
        }
    }
}
