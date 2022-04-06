using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Timer : MonoBehaviour
{
    [SerializeField] int limitTimer;

    public bool isRunning;
    public Text textTimer;

    float timeLevel;
    void Start()
    {
        timeLevel = limitTimer;
        isRunning = false;
    }

    void Update()
    {
        if(isRunning){
            timeLevel -= Time.deltaTime;
            textTimer.text = timeLevel.ToString("F0");
        }

        if(timeLevel <= 10){
            textTimer.color = Color.red;
        }
        if(timeLevel < 0){
            FindObjectOfType<MenuManager>().GameOverScene();
            Debug.Log("Acabou o tempo");
        }
    }
}
