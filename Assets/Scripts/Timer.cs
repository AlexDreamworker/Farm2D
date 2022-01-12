using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Timer : MonoBehaviour
{
    public float timer;
    public TMP_Text timerTextInfo;

    private DateTime timerEnd;

    private void Start()
    {
        timerEnd = DateTime.Now.AddSeconds(timer);
    }

    private void Update()
    {
        TimeSpan delta = timerEnd - DateTime.Now;

        timerTextInfo.text = (delta.Minutes.ToString("00") + ":" + delta.Seconds.ToString("00"));

        if (delta.TotalSeconds <= 0)
        {
            GameController.GC.isLose = true;
            timerTextInfo.text = "";
        }
    }
}
