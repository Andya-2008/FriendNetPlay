using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HoopCheck : MonoBehaviour
{
    [SerializeField] GameObject Ball;
    [SerializeField] ParticleSystem ConfettiEffect;
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        
        
            if (collision.gameObject == Ball.gameObject)
            {
                Debug.Log("Boom");
                GameObject.Find("ScoreManager").GetComponent<ScoreManager>().levelCount += 1;
                ConfettiEffect.Play();
            }
    }
}
