using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class menuManager : MonoBehaviour
{
    public GameObject gameUi, menuUi, aboutUi, button,buts;
    bool sound;
    public Image soundImage,bgImage;
    public Sprite sOn, sOff;
    public Color[] colors;
    public AudioSource bgMusic;
    int bgindex;
    public GameObject notification,mail;

    void Start()
    {
        bgindex=Random.Range(0, 8);
        sound = true;
        gameUi.SetActive(false);
        aboutUi.SetActive(false);
        menuUi.SetActive(true);
        
        StartCoroutine("addButton");
        
        
    }

    // Update is called once per frame
    void Update()
    {
        
        bgImage.color=colors[bgindex];

        if (sound)
        {
            soundImage.sprite = sOn;
        }
        else
        {
            soundImage.sprite = sOff;

        }
    }
    IEnumerator addButton()
    {
        yield return new WaitForSeconds(7);
        Instantiate(button, button.transform.position, Quaternion.identity, buts.transform);
        yield return new WaitForSeconds(7);
        Instantiate(button, button.transform.position, Quaternion.identity, buts.transform);
        yield return new WaitForSeconds(7);
        Instantiate(button, button.transform.position, Quaternion.identity, buts.transform);
        yield return new WaitForSeconds(7);
        Instantiate(button, button.transform.position, Quaternion.identity, buts.transform);
        yield return new WaitForSeconds(7);
        Instantiate(button, button.transform.position, Quaternion.identity, buts.transform);
        yield return new WaitForSeconds(7);
        Instantiate(button, button.transform.position, Quaternion.identity, buts.transform);
        yield return new WaitForSeconds(7);
        Instantiate(button, button.transform.position, Quaternion.identity, buts.transform);

    }
    public void startBut()
    {
        bgindex=Random.Range(0,8);

        gameUi.SetActive(true);
        aboutUi.SetActive(false);
        menuUi.SetActive(false);
    }
    public void aboutBut()
    {
        bgindex=Random.Range(0, 8);

        gameUi.SetActive(false);
        aboutUi.SetActive(true);
        menuUi.SetActive(false);
    }
    public void menuBut()
    {
        bgindex=Random.Range(0, 8);

        gameUi.SetActive(false);
        aboutUi.SetActive(false);
        menuUi.SetActive(true);
    }
    public void soundBut()
    {
        if (sound)
        {
            bgMusic.Pause();

            sound = false;
        }
        else
        {
            bgMusic.Play();

            sound = true;
        }
    }

    public void emailBut()
    {
        //Application.OpenURL("http://unity3d.com/");
        GameObject noti=Instantiate(notification, mail.transform.position, Quaternion.identity, mail.transform);
        //"acandar@gmail.com".CopyToClipboard();
        TextEditor te = new TextEditor();
        te.text = "acandar@gmail.com";
        te.SelectAll();
        te.Copy();
        Destroy(noti,3f);

    }

    public void buycofeeBut()
    {
        Application.OpenURL("https://www.papara.com/personal/qr?c=0&a=25.0&d=bana%20kahve%20ismarla&ac=1875080102");
    }
    public void quit()
    {
        Application.Quit();
    }
}
