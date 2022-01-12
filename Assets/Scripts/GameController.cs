using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SceneManagement;

public class GameController : MonoBehaviour
{
    public static GameController GC;

    public GameObject textWin, textLose, restartButton, joystick, bombButton, pauseImage, timerTextInfo, coinSprite;
    public TMP_Text coinsCountText;

    [HideInInspector] public bool isWin, isLose;
    [HideInInspector] public int coinsCount = 0;

    private void Awake()
    {
        GC = this;

        Time.timeScale = 1;
        coinsCount = PlayerPrefs.GetInt("coins");
    }

    private void Update()
    {
        coinsCountText.text = "" + coinsCount;

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
        coinsCountText.text = "";
        joystick.SetActive(false);
        bombButton.SetActive(false);
        timerTextInfo.SetActive(false);
        coinSprite.SetActive(false);
    }

    public void GetCoins()
    {
        coinsCount++;
        PlayerPrefs.SetInt("coins", coinsCount);
    }

    public void Restart()
    {
        SceneManager.LoadScene("Game");
    }
}
