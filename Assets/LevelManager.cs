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
    bool alreadySet;
    bool alreadyTimeSet;

    private void Start()
    {
        startTime = Time.time;
    }
    public void NextLevel()
    {
        alreadySet = false;
        levelNum += 1;
        if (levelNum >= 11)
        {
            GameObject.Find("GameOverManager").GetComponent<GameOverManager>().GameOverInitiate();
        }
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.L))
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
            if (!alreadySet)
            {
                alreadySet = true;
                Hoop.GetComponent<HoopMover>().DirRight *= 4;
                Hoop.GetComponent<HoopMover>().DirUp *= 4;
            }
        }
        if (levelNum == 8)
        {
            if (!alreadySet)
            {
                alreadySet = true;
                Hoop.GetComponent<HoopMover>().DirRight *= 2;
                Hoop.GetComponent<HoopMover>().DirUp *= 2;
            } 
        }
        if (levelNum == 9)
        {
            if(Time.time - startTime >= 3)
            {
                alreadyTimeSet = true;
            }
            if (alreadyTimeSet)
            {
                alreadyTimeSet = false;
                if (RandomLevel4Pos == 0)
                {
                    RandomLevel4Pos = Random.Range(1, 4);
                    startTime = Time.time;
                    levelPosSwitchBool = true;
                    Hoop.transform.position = Level1HoopPos.position;
                }
                if (RandomLevel4Pos == 1)
                {
                    RandomLevel4Pos = Random.Range(0, 4);
                    startTime = Time.time;
                    levelPosSwitchBool = false;
                    Hoop.transform.position = Level2HoopPos.position;
                }
                if (RandomLevel4Pos == 2)
                {
                    RandomLevel4Pos = Random.Range(0, 4);
                    startTime = Time.time;
                    levelPosSwitchBool = true;
                    Hoop.transform.position = Level4HoopPos.position;
                }
                if (RandomLevel4Pos == 3)
                {
                    RandomLevel4Pos = Random.Range(0, 3);
                    startTime = Time.time;
                    levelPosSwitchBool = false;
                    Hoop.transform.position = Level4HoopPos2.position;
                }
            }
            if (!alreadySet)
            {
                
                alreadySet = true;
                Hoop.GetComponent<HoopMover>().DirRight *= 2;
                Hoop.GetComponent<HoopMover>().DirUp *= 2;
            }
        }
        if (levelNum == 10)
        {
            if (Time.time - startTime >= 1.5)
            {
                alreadyTimeSet = true;
            }
            if (alreadyTimeSet)
            {
                alreadyTimeSet = false;
                if (RandomLevel4Pos == 0)
                {
                    RandomLevel4Pos = Random.Range(1, 4);
                    startTime = Time.time;
                    levelPosSwitchBool = true;
                    Hoop.transform.position = Level1HoopPos.position;
                }
                if (RandomLevel4Pos == 1)
                {
                    RandomLevel4Pos = Random.Range(0, 4);
                    startTime = Time.time;
                    levelPosSwitchBool = false;
                    Hoop.transform.position = Level2HoopPos.position;
                }
                if (RandomLevel4Pos == 2)
                {
                    RandomLevel4Pos = Random.Range(0, 4);
                    startTime = Time.time;
                    levelPosSwitchBool = true;
                    Hoop.transform.position = Level4HoopPos.position;
                }
                if (RandomLevel4Pos == 3)
                {
                    RandomLevel4Pos = Random.Range(0, 3);
                    startTime = Time.time;
                    levelPosSwitchBool = false;
                    Hoop.transform.position = Level4HoopPos2.position;
                }
            }
            if (!alreadySet)
            {

                alreadySet = true;
                Hoop.GetComponent<HoopMover>().DirRight *= 2;
                Hoop.GetComponent<HoopMover>().DirUp *= 2;
            }
        }
    }
}
