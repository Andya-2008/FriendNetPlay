using UnityEngine;
using System.Collections;
using UnityEngine.EventSystems;

public class MyButton : MonoBehaviour, IPointerDownHandler, IPointerUpHandler
{

    public bool buttonPressed;
    public string cmd;
    

    public void OnPointerDown(PointerEventData eventData)
    {
        GameObject.Find("Robot").GetComponent<ActuateRobot>().buttonDown(cmd);
        buttonPressed = true;
    }

    public void OnPointerUp(PointerEventData eventData)
    {
        GameObject.Find("Robot").GetComponent<ActuateRobot>().buttonUp(cmd);
        buttonPressed = false;
    }
}
