using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SceneManagement;

public class GameController : MonoBehaviour
{
    public static GameController GC;

    public GameObject textWin, textLose, restartButton, joystick, bombButton, pauseImage, timerTextInfo;
    public bool isWin, isLose;

    private void Awake()
    {
        GC = this;
        Time.timeScale = 1;
    }

    private void Update()
    {
        if (isWin)
        {
            textWin.SetActive(true);
            UiInfo();
        }

        if (isLose)
        {
            textLose.SetActive(true);
            UiInfo();
        }
    }

    void UiInfo()
    {
        Time.timeScale = 0f;
        pauseImage.SetActive(true);
        restartButton.SetActive(true);
        joystick.SetActive(false);
        bombButton.SetActive(false);
        timerTextInfo.SetActive(false);
    }

    public void Restart()
    {
        SceneManager.LoadScene("Game");
    }
}
