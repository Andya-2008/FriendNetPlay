using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StopClawFromNet : MonoBehaviour
{
    public bool myColliderLeft = true;
    public bool myColliderRight = true;
    [SerializeField]GameObject clawColliderLeft;
    [SerializeField]GameObject clawColliderRight;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    /*
    private void OnTriggerEnter2D(Collider2D collision)
    { 
        if (collision.gameObject == clawColliderLeft || collision.gameObject == clawColliderRight)
        {
            Debug.Log(collision.gameObject.name);
            if (myColliderLeft)
            {
                GameObject.Find("ScorePos").GetComponent<HoopCheck>().canMoveRight=false;
            }
            if (myColliderRight)
            {
                GameObject.Find("ScorePos").GetComponent<HoopCheck>().canMoveLeft = false;
            }
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {   
        if (collision.gameObject == (clawColliderLeft || clawColliderRight))
        {
            if (myColliderLeft)
            {
                GameObject.Find("ScorePos").GetComponent<HoopCheck>().canMoveRight = true;
            }
            if (myColliderRight)
            {
                GameObject.Find("ScorePos").GetComponent<HoopCheck>().canMoveLeft = true;
            }
        }
    }
    */
}
