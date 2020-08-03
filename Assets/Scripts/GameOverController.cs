using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameOverController : MonoBehaviour
{
    public GameObject gameOverObject;
    public GameObject quitObject;
    public Text scoreText;
    public Text highScoreText;
    public AudioSource KeyPress;
    void Start()
    {
        if (SceneManager.GetActiveScene().name == "GameOver")
        {
            gameOverObject.SetActive(true);
            if (ScoreScript.scoreValue > 0)
            {
                scoreText.text = ScoreScript.scoreValue.ToString();
            }
            else
            {
                scoreText.text = 0.ToString();
            }
            if (ScoreScript.scoreValue > PlayerPrefs.GetInt("HighScore"))
            {
                PlayerPrefs.SetInt("HighScore", ScoreScript.scoreValue);
                highScoreText.text = ScoreScript.scoreValue.ToString();
            }
            else
            {
                highScoreText.text = PlayerPrefs.GetInt("HighScore").ToString();
            }
        }
    }
    public void Retry()
    {
        KeyPress.Play();
        BonusPointsController.checkPos = false;
        BonusPointsController.checkNeg = false;
        BonusPointsController.bonusRunning = false;
        BonusPointsController.debuffRunning = false;
        if (SceneManager.GetActiveScene().name == "GameOver")
        {
            SceneManager.LoadScene("GameScene");
            ScoreScript.scoreValue = 0;
            StarsFalling.fallingSpeed = 10f;
            BonusPointsController.countdownTimePos = 5;
            BonusPointsController.countdownTimeNeg = 5;
        }
    }

    public void Menu()
    {
        KeyPress.Play();
        SceneManager.LoadScene("MainMenu");
    }
    public void exitGame()
    {
        KeyPress.Play();
        gameOverObject.SetActive(false);
        quitObject.SetActive(true);
    }
    public void Yes()
    {
        KeyPress.Play();
        Application.Quit();
    }
    public void No()
    {
        KeyPress.Play();
        quitObject.SetActive(false);
        gameOverObject.SetActive(true);
    }
}
