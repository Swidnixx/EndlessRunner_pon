using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    #region Singleton
    public static GameManager Instance;
    private void Awake()
    {
        Instance = this;
    }
    #endregion

    public GameObject gameOverPanel;
    public Text scoreText;
    public Text coinText;
    public float worldSpeed = 2.5f;
    float score;
    int coins;
    float highScore;

    private void Start()
    {
        magnet.magnetActive = false;

        coins = PlayerPrefs.GetInt("Coins");
        coinText.text = coins.ToString();

        highScore = PlayerPrefs.GetFloat("HighScore");
    }

    private void Update()
    {
        score += worldSpeed * Time.deltaTime;
        scoreText.text = score.ToString("F0");

        if(score > highScore)
        {
            highScore = score;
            PlayerPrefs.SetFloat("HighScore", highScore);
        }
    }

    public void GameOver()
    {
        gameOverPanel.SetActive(true);
        Time.timeScale = 0;
    }

    public void Restart()
    {
        SceneManager.LoadScene( SceneManager.GetActiveScene().name );
        Time.timeScale = 1;
    }

    public void CoinCollect()
    {
        coins++;
        coinText.text = coins.ToString();
        PlayerPrefs.SetInt("Coins", coins);
    }


    public MagnetSO magnet;
    public void MagnetCollect()
    {
        if(magnet.magnetActive)
        {
            CancelInvoke(nameof(CancelMagnet));
        }
        magnet.magnetActive = true;
        Invoke( nameof(CancelMagnet), magnet.magnetDuration);
    }

    void CancelMagnet()
    {
        magnet.magnetActive = false;
    }
}
