using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class LogicScript : MonoBehaviour
{
    public int playerScore;
    public Text scoreText;
    public Text highScoreText;
    public GameObject gameOverScreen;
    public AudioSource scoreSound;
    public AudioSource backgroundMusic;

    void Start()
    {
        backgroundMusic.loop = true;
        DisplayHighScore();
    }

    // Adds a command to the Unity object under the ... that executes the following code(?)
    [ContextMenu("Increase Score")]
    public void addScore(int scoreToAdd)
    {
        playerScore = playerScore + scoreToAdd;
        scoreText.text = playerScore.ToString();
        UpdateHighScore(playerScore);
        DisplayHighScore();
        scoreSound.Play();
    }

    public void DisplayHighScore()
    {
        int highScore = PlayerPrefs.GetInt("HighScore", 0); // Get the high score, default to 0
        highScoreText.text = "High Score: " + highScore.ToString(); // Update UI with high score
    }


    public void UpdateHighScore(int newScore)
    {
        // PlayerPrefs is a class that store player preferences between sessions
        int currentHighScore = PlayerPrefs.GetInt("HighScore", 0); // Get the current high score if there is one, default to 0 in case there is not
        if (newScore > currentHighScore)
        {
            PlayerPrefs.SetInt("HighScore", newScore); // Set the new high score
            PlayerPrefs.Save(); // Save changes to PlayerPrefs
        }
    }


    public void restartGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    public void gameOver()
    {
        gameOverScreen.SetActive(true);
    }
}
