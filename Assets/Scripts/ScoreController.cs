using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreController : MonoBehaviour {

    private PlayerProgress playerProgress;
    public Text highScoreUI;

    private void Start()
    {
        LoadHighScore();
    }

    public void LoadHighScore()
    {
        playerProgress = new PlayerProgress();

        if (PlayerPrefs.HasKey("highScore"))
        {
            playerProgress.highScore = PlayerPrefs.GetInt("highScore");
        }

        highScoreUI.text = playerProgress.highScore.ToString();
    }

    public void SavePlayerProgress(int score)
    {
        PlayerPrefs.SetInt("highScore", value: score);
    }

}
