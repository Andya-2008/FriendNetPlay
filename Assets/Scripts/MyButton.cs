using UnityEngine;
using System.Collections;
using UnityEngine.EventSystems;

public class MyButton : MonoBehaviour, IPointerDownHandler, IPointerUpHandler
{

    public bool buttonPressed;
    public string buttonType;
    public string controllerType;
    

    public void OnPointerDown(PointerEventData eventData)
    {
        GameObject.Find("Robot").GetComponent<ActuateRobot>().buttonDown(controllerType, buttonType);
        buttonPressed = true;
    }

    public void OnPointerUp(PointerEventData eventData)
    {
        GameObject.Find("Robot").GetComponent<ActuateRobot>().buttonUp(controllerType, buttonType);
        buttonPressed = false;
    }
}
