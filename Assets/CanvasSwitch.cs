using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CanvasSwitch : MonoBehaviour
{
    [SerializeField] GameObject ClawCanvas;
    [SerializeField] GameObject PivotCanvas1;
    [SerializeField] GameObject PivotCanvas2;
    [SerializeField] GameObject MoverCanvas;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.U))
        {
            MoverCanvas.GetComponent<Canvas>().enabled = true;
            PivotCanvas1.GetComponent<Canvas>().enabled = false;
            PivotCanvas2.GetComponent<Canvas>().enabled = false;
            ClawCanvas.GetComponent<Canvas>().enabled = false;
        }
        if (Input.GetKeyDown(KeyCode.I))
        {
            MoverCanvas.GetComponent<Canvas>().enabled = false;
            PivotCanvas1.GetComponent<Canvas>().enabled = true;
            PivotCanvas2.GetComponent<Canvas>().enabled = false;
            ClawCanvas.GetComponent<Canvas>().enabled = false;
        }
        if (Input.GetKeyDown(KeyCode.O))
        {
            MoverCanvas.GetComponent<Canvas>().enabled = false;
            PivotCanvas1.GetComponent<Canvas>().enabled = false;
            PivotCanvas2.GetComponent<Canvas>().enabled = true;
            ClawCanvas.GetComponent<Canvas>().enabled = false;
        }
        if (Input.GetKeyDown(KeyCode.P))
        {
            MoverCanvas.GetComponent<Canvas>().enabled = false;
            PivotCanvas1.GetComponent<Canvas>().enabled = false;
            PivotCanvas2.GetComponent<Canvas>().enabled = false;
            ClawCanvas.GetComponent<Canvas>().enabled = true;
        }
    }
}
