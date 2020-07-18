using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameOverController : MonoBehaviour
{
    public Text scoreText;
    public Text scoreDef;
    public AudioSource KeyPress;
    public void DrawScore(){
        Scene currentScene = SceneManager.GetActiveScene();
        if (currentScene.name == "GameOver"){
            scoreText.text = ScoreScript.scoreValue.ToString();
            scoreDef.text = "YOUR SCORE";
        }
    }
    public void Retry()
    {
        KeyPress.Play();
        BonusPointsController.checkPos = false;
        BonusPointsController.checkNeg = false;
        BonusPointsController.bonusRunning = false;
        BonusPointsController.debuffRunning = false;
        Scene currentScene = SceneManager.GetActiveScene();
        if (currentScene.name == "GameOver"){
            SceneManager.LoadScene("GameScene");
            ScoreScript.scoreValue = 0;
            StarsFalling.fallingSpeed = 10f;
            BonusPointsController.countdownTimePos = 5;
            BonusPointsController.countdownTimeNeg = 5;
        }
    }
    public void exitGame(){
        KeyPress.Play();
        Application.Quit();
    }
}
