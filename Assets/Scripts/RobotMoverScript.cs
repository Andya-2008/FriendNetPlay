using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RobotMoverScript : MonoBehaviour
{
    [SerializeField] float moveSpeed = 100f;
    public bool moveLeft;
    public bool moveRight;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if(moveLeft )
        {
            MoveLeft();
        }
        if (moveRight )
        {
            MoveRight();
        }
    }

    void MoveRight()
    {
        if(this.transform.position.x <= 7.34)
        this.transform.Translate(moveSpeed/100*Time.deltaTime, 0, 0);
    }
    void MoveLeft()
    {
        if (this.transform.position.x >= -7.34)
            this.transform.Translate(-1*moveSpeed/100 * Time.deltaTime, 0, 0);
    }
}
