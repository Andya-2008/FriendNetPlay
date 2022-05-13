using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameDevChecker : MonoBehaviour
{
    [SerializeField] Canvas DevCanvas;
    [SerializeField] Canvas PlayerCanvas;
    [SerializeField] GameObject DevCamera;
    [SerializeField] GameObject PlayerCamera;
    // Start is called before the first frame update
    void Start()
    {
        
            
        if (PlayerPrefs.GetString("PlayerType") == "Dev")
        {
            DevCanvas.GetComponent<Canvas>().enabled = true;
            PlayerCanvas.GetComponent<Canvas>().enabled = false;
            DevCamera.GetComponent<Camera>().enabled = true;
            PlayerCamera.GetComponent<Camera>().enabled = false;
        }
        else
        {
            PlayerCanvas.GetComponent<Canvas>().enabled = true;
            DevCanvas.GetComponent<Canvas>().enabled = false; 
            PlayerCamera.GetComponent<Camera>().enabled = true;
            DevCamera.GetComponent<Camera>().enabled = false;

        }
        
    }

}
