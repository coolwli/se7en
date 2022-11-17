using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;



public class menuButton : MonoBehaviour
{
    public TMP_Text scoreText;
    public float speed;
    public Vector3 target;
    void Start()
    {
        scoreText.text = Random.Range(0, 777).ToString();
        target = new Vector3(Random.Range(145, 930), Random.Range(70, 2090), 0);

    }

    // Update is called once per frame
    void Update()
    {
        if (transform.position == target)
        {
            target = new Vector3(Random.Range(145, 930), Random.Range(70, 2090), 0);


        }
        transform.position = Vector3.MoveTowards(transform.position, target, speed);


    }
}
