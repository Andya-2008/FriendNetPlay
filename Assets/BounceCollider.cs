using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BounceCollider : MonoBehaviour
{
    [SerializeField] bool collider1;
    [SerializeField] bool collider2;
    [SerializeField] bool collider3;
    [SerializeField] bool collider4;
    [SerializeField] GameObject InsideHoopCollider;
    [SerializeField] GameObject InsideHoopCollider1;
    [SerializeField] GameObject InsideHoopCollider2;
    [SerializeField] GameObject InsideHoopCollider3;
    float startTime;
    // Start is called before the first frame update
    void Start()
    {
        startTime = Time.time;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (Time.time - startTime > .1)
        {
            if (collision.gameObject != InsideHoopCollider && collision.gameObject != InsideHoopCollider1 && collision.gameObject != InsideHoopCollider2 && collision.gameObject != InsideHoopCollider3)
            {
                Debug.Log(collision.gameObject.name);
                if (collider1 || collider2)
                {
                    GameObject.Find("Hoop").GetComponent<HoopMover>().DirRight *= -1;
                }
                if (collider3 || collider4)
                {
                    GameObject.Find("Hoop").GetComponent<HoopMover>().DirUp *= -1;
                }
            }
        }
    }
}
