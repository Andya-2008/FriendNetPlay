using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AutoDisconnectManager : MonoBehaviour
{
    public float autoStartTime;
    bool alreadyLoaded;
    // Start is called before the first frame update
    private void Awake()
    {
        autoStartTime = Time.time;
    }

    // Update is called once per frame
    void Update()
    {

        if (PlayerPrefs.GetString("PlayerType") == "Dev")
        {
            if (Time.time - autoStartTime >= 60 && !alreadyLoaded)
            {
                alreadyLoaded = true;
                GameObject.Find("GameOverManager").GetComponent<GameOverManager>().CallLogOut();
            }
        }

    }
}
