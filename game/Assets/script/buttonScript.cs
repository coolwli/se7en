using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;



public class buttonScript : MonoBehaviour
{
    public int value;
    public TMP_Text valueText;
    public gameManager game;



    void Start()
    {
        value = Random.Range(1, 5);
    }

    void Update()
    {
        valueText.text = value.ToString();
    }
    public void click()
    {
        game.add(value);
    }
    public void set()
    {

        value = Random.Range(game.score / 7, game.score * 2 / 3);
        if (value + game.score > 777)
        {
            value = 777 - game.score;
        }

    }

}
