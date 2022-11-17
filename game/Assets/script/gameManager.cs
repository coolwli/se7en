using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class gameManager : MonoBehaviour
{
    public int score, minDeger, myTime;
    public Text scoreText, deadText, countText, bestScore;
    bool dead, stopped;
    public GameObject StopUi, resumeButton, scoreObject;
    public buttonScript[] buts;
    float count = -1;
    Animator anim;




    void Start()
    {

        minDeger = 7;
        scoreObject.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if (PlayerPrefs.HasKey("hasWin"))
        {
            bestScore.text = "EN IYI SKOR: " + PlayerPrefs.GetInt("hasWin").ToString();
        }
        else
        {
            
            bestScore.text = "";
        }
        if (!dead && !stopped)
        {
            myTime = (int)count;
            count += Time.deltaTime;
            countText.text = myTime.ToString();

        }

        scoreText.text = score.ToString();
        if (score == 777)
        {
            if (PlayerPrefs.HasKey("hasWin"))
            {
                if (PlayerPrefs.GetInt("hasWin") > myTime)
                {
                    PlayerPrefs.SetInt("hasWin", myTime);
                }
            }
            else
                PlayerPrefs.SetInt("hasWin", myTime);


            stopped = true;
            resumeButton.SetActive(false);

            deadText.text = "7AMAMLANDI";
            StopUi.SetActive(true);
            scoreObject.SetActive(true);
            scoreObject.GetComponent<Text>().text = "SKORUN: " + myTime.ToString() + "sn";

        }

    }
    public void add(int deger)
    {

        if (!dead)
        {
            for (int i = 0; i < buts.Length; i++)
            {

                if (buts[i].value < minDeger)
                {
                    minDeger = buts[i].value;
                    anim = buts[i].GetComponent<Animator>();
                }
            }
            if (deger == minDeger)
            {
                score = score + deger;
                minDeger = score;
                for (int i = 0; i < buts.Length; i++)
                {
                    buts[i].set();
                }

            }
            else
            {
                dead = true;
                StartCoroutine("deadAnim");
            }
        }


    }
    public void restart()
    {
        score = 7;
        count = -1;
        minDeger = 7;
        dead = false;
        stopped = false;
        StopUi.SetActive(false);
        resumeButton.SetActive(true);

        for (int i = 0; i < buts.Length; i++)
        {
            buts[i].set();
        }
    }
    public void stopGame()
    {
        stopped = true;
        deadText.text = "S7OP";
        StopUi.SetActive(true);

    }
    public void resume()
    {
        stopped = false;
        StopUi.SetActive(false);
    }
    IEnumerator deadAnim()
    {
        anim.Play("deadAnim");
        yield return new WaitForSeconds(2.0f);
        resumeButton.SetActive(false);
        deadText.text = "KAYBE77IN";
        StopUi.SetActive(true);
    }

}
