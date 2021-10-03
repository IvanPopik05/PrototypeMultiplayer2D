using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Timer : MonoBehaviour
{
    [SerializeField] private Text timeText;
    public static float timerRemaining = 5;
    public static bool isTimer = true;
    void Start()
    {
        timeText.text = timerRemaining.ToString();
    }
    void Update()
    {
        if (isTimer)
        {
            if (timerRemaining > 0)
            {
                timerRemaining -= Time.deltaTime;
                timeText.text = Mathf.Round(timerRemaining).ToString();
            }
            else 
            {
                isTimer = false;
                timerRemaining = 0;
                AgentUI.canPlay = true;
            }
        }
    }
}
