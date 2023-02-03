using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;



public class Gamemanager : MonoBehaviour
{
    public GameObject player;
    public GameObject Starting;
    public GameObject Reset;
    public GameObject UI;
    public Text timeText;
    public Text recordText;
    public Text lastscore;
    public Text life;
    public Text level;
    public Text money;
    public RectTransform uiGroup;

    private float survibeTime;
    private bool isGameover;
    public static bool isStarting;

    public static int lv = 1;

    public GameObject bullet_lv1;
    public GameObject bullet_lv2;
    public GameObject bullet_lv3;

    public GameObject skill01_img;
    public GameObject skill02_img;
    public GameObject skill03_img;
    public Text skill01;
    public Text skill02;
    public Text skill03;

    public static int skillmode;
    public float amoney;


    // Start is called before the first frame update
    void Start()
    {
        
        survibeTime = 0f;
        isGameover = false;

        isStarting = false;
        skillmode = 2;

        Starting.SetActive(true);
        bullet_lv1.SetActive(false);
        UI.SetActive(false);
        


    }

    // Update is called once per frame
    void Update()
    {

        money.text = amoney + "";
        
        if (!isGameover && isStarting)
        {
            life.text = Bullet.lifecount + " / 3";
            
            //Debug.Log(Bullet.lifecount);

            survibeTime += Time.deltaTime;
            
            int min = (int)(survibeTime / 60);
            int sec = (int)(survibeTime % 60);
            timeText.text = ( string.Format("{0:00}", min) + ":" + string.Format("{0:00}", sec) );

            if ((int)survibeTime == 60)
            {
                lv = 2;
                bullet_lv2.SetActive(true);
            }
            if ((int)survibeTime == 120)
            {
                lv = 3;
                bullet_lv3.SetActive(true);
            }
            level.text = lv+"";
        }
        else
        {
            life.text = "0 / 3" ;
            if (Input.GetKeyDown(KeyCode.R))
            {
                restart();
            }
        }
    }

    public void GameStart()
    {
        isStarting = true;
        
        amoney += 10;
        
        Starting.SetActive(false);
        UI.SetActive(true);
        bullet_lv1.SetActive(true);
    }

    public void restart()
    {
        SceneManager.LoadScene("SampleScene");
    }

    public void EndGame()
    {
        isGameover = true;
        PlayerController.moving = true;
        UI.SetActive(false);
        Reset.SetActive(true);
        bullet_lv1.SetActive(false);

        lv = 1;
        bullet_lv2.SetActive(false);
        bullet_lv3.SetActive(false);

        float bestTime = PlayerPrefs.GetFloat("BestTime");

        if(survibeTime > bestTime)
        {
            bestTime = survibeTime;
            PlayerPrefs.SetFloat("BestTime", bestTime);
        }
        int min = (int)(survibeTime / 60);
        int sec = (int)(survibeTime % 60);
        lastscore.text = "Last Time : " + (string.Format("{0:00}", min) + ":" + string.Format("{0:00}", sec));
        
        min = (int)(bestTime / 60);
        sec = (int)(bestTime % 60);
        recordText.text = "Best Time : " + (string.Format("{0:00}", min) + ":" + string.Format("{0:00}", sec));


    }


    public void store()
    {
        uiGroup.anchoredPosition = Vector3.zero;
    }

    public void exitstore()
    {
        uiGroup.anchoredPosition = Vector3.down * 1000;
    }
    public void buy(int index)
    {
        Debug.Log(index);
        if(index == 1 && !isStarting )
        {
            skill01_img.SetActive(true);
            skill02_img.SetActive(false);
            skill03_img.SetActive(false);
            skill01.text = "ÀåÂø Áß";
            skill02.text = "X";
            skill03.text = "X";
            skillmode = index;
        }
        else if( index == 2 && !isStarting)
        {
            skill01_img.SetActive(false);
            skill02_img.SetActive(true);
            skill03_img.SetActive(false);
            skill01.text = "X";
            skill02.text = "ÀåÂø Áß";
            skill03.text = "X";
            skillmode = index;
        }
        else if( index == 3 && !isStarting)
        {
            skill01_img.SetActive(false);
            skill02_img.SetActive(false);
            skill03_img.SetActive(true);
            skill01.text = "X";
            skill02.text = "X";
            skill03.text = "ÀåÂø Áß";
            skillmode = index;
        }

        


    }


    

}
