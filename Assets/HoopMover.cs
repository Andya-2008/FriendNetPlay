using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HoopMover : MonoBehaviour
{
    public float DirUp;
    public float DirRight;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Move(DirUp, DirRight);
    }

    public void Move(float dir_up, float dir_right)
    {
        this.transform.Translate(0, dir_up/20*Time.deltaTime, 0);
        this.transform.Translate(dir_right/20*Time.deltaTime, 0, 0);
    }

}
