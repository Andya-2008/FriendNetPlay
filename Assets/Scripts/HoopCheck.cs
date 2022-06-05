using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HoopCheck : MonoBehaviour
{
    [SerializeField] GameObject Ball;
    [SerializeField] ParticleSystem ConfettiEffect;
    float startTime;
    public bool canMoveLeft = true;
    public bool canMoveRight = true;

    // Start is called before the first frame update
    void Start()
    {
        startTime = Time.time;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {


        if (collision.gameObject == Ball.gameObject)
        {
            if (Time.time - startTime > 3)
            {
                if (canMoveLeft && canMoveRight)
                {
                    startTime = Time.time;
                    GameObject.Find("LevelManager").GetComponent<LevelManager>().NextLevel();
                    GameObject.Find("ScoreManager").GetComponent<ScoreManager>().levelCount += 1;
                    ConfettiEffect.Play();
                }
            }
        }
    }
}
