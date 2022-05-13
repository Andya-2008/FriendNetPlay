using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelManager : MonoBehaviour
{
    public int levelNum = 1;
    public GameObject Hoop;
    public Transform Level1HoopPos;
    public Transform Level2HoopPos;
    public Transform Level4HoopPos;
    public Transform Level4HoopPos2;
    int RandomLevel4Pos;
    float startTime;
    bool levelPosSwitchBool;

    private void Start()
    {
        startTime = Time.time;
    }
    public void NextLevel()
    {
        levelNum += 1;
    }

    private void Update()
    {
        if(Input.GetKeyDown(KeyCode.Space))
        {
            NextLevel();
        }
        if(levelNum==1)
        {
            //Nothing happens on level 1
        }
        if(levelNum==2)
        {
            //Hoop is moved to the right side on level 2
            Hoop.transform.position = Level2HoopPos.position;
        }
        if(levelNum==3)
        {
            if(Time.time-startTime >=5 && !levelPosSwitchBool)
            {
                startTime = Time.time;
                levelPosSwitchBool = true;
                Hoop.transform.position = Level1HoopPos.position;
            }
            if (Time.time - startTime >= 5 && levelPosSwitchBool)
            {
                startTime = Time.time;
                levelPosSwitchBool = false;
                Hoop.transform.position = Level2HoopPos.position;
            }
        }
        if(levelNum==4)
        {
            if (Time.time - startTime >= 5 && RandomLevel4Pos == 0)
            {
                RandomLevel4Pos = Random.Range(0, 4);
                startTime = Time.time;
                levelPosSwitchBool = true;
                Hoop.transform.position = Level1HoopPos.position;
            }
            if (Time.time - startTime >= 5 && RandomLevel4Pos == 1)
            {
                RandomLevel4Pos = Random.Range(0, 4);
                startTime = Time.time;
                levelPosSwitchBool = false;
                Hoop.transform.position = Level2HoopPos.position;
            }
            if (Time.time - startTime >= 5 && RandomLevel4Pos == 2)
            {
                RandomLevel4Pos = Random.Range(0, 4);
                startTime = Time.time;
                levelPosSwitchBool = true;
                Hoop.transform.position = Level4HoopPos.position;
            }
            if (Time.time - startTime >= 5 && RandomLevel4Pos == 3)
            {
                RandomLevel4Pos = Random.Range(0, 4);
                startTime = Time.time;
                levelPosSwitchBool = false;
                Hoop.transform.position = Level4HoopPos2.position;
            }
        }
        if (levelNum == 5)
        {
            if (Time.time - startTime >= 3 && RandomLevel4Pos == 0)
            {
                RandomLevel4Pos = Random.Range(1, 4);
                startTime = Time.time;
                levelPosSwitchBool = true;
                Hoop.transform.position = Level1HoopPos.position;
            }
            if (Time.time - startTime >= 3 && RandomLevel4Pos == 1)
            {
                RandomLevel4Pos = Random.Range(0, 4);
                startTime = Time.time;
                levelPosSwitchBool = false;
                Hoop.transform.position = Level2HoopPos.position;
            }
            if (Time.time - startTime >= 3 && RandomLevel4Pos == 2)
            {
                RandomLevel4Pos = Random.Range(0, 4);
                startTime = Time.time;
                levelPosSwitchBool = true;
                Hoop.transform.position = Level4HoopPos.position;
            }
            if (Time.time - startTime >= 3 && RandomLevel4Pos == 3)
            {
                RandomLevel4Pos = Random.Range(0, 3);
                startTime = Time.time;
                levelPosSwitchBool = false;
                Hoop.transform.position = Level4HoopPos2.position;
            }
        }
        if (levelNum == 6)
        {
            Hoop.GetComponent<HoopMover>().enabled = true;
        }
        if (levelNum == 7)
        {
            Hoop.GetComponent<HoopMover>().DirRight = 15;
            Hoop.GetComponent<HoopMover>().DirUp = 15;
        }
    }
}
