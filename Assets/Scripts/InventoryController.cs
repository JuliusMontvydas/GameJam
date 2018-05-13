using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class InventoryController : MonoBehaviour {
    public int items = 0;
    public int lives = 3;
    public Text itemsScore;
    public Text livesScore;
    private ScoreController scoreController;

    private void Start()
    {
        scoreController = FindObjectOfType<ScoreController>();
        setLives(3);
        items = 0;
        lives = 3;
    }

    public void addItem()
    {
        items++;
        itemsScore.text = items.ToString();
        if(items > PlayerPrefs.GetInt("highScore"))
        {
            scoreController.SavePlayerProgress(items);
            scoreController.LoadHighScore();
        }
        Debug.Log("Items: " + items);
    }

    public void minusItem()
    {
        items--;
        itemsScore.text = items.ToString();
        Debug.Log("Items: " + items);
    }

    public void setLives(int lives)
    {
        this.lives = lives;
        livesScore.text = lives.ToString();
    }

    public void takeDamage()
    {
        if(lives > 1)
        {
            lives--;
            livesScore.text = lives.ToString();
        }
        else
        {
            gameOver();
        }
    }

	public void addLive(int count = 1)
	{
		lives += count;
		livesScore.text = lives.ToString();
	}

    public void levelCleared()
    {
        if(items == 20)
        {
            // TO-DO... level cleared script
        }
    }

    public void gameOver()
    {
        scoreController.SavePlayerProgress(items);
        scoreController.LoadHighScore();
        //Debug.Log("Game Over!");
        SceneManager.LoadScene("GameOver");
        // TO-DO... game over script
    }
}
