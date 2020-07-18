using System.Collections;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
public class ScoreScript : MonoBehaviour
{

    public static int scoreValue = 0;
    Text scoreText;
    void Start()
    {
        scoreText = GetComponent<Text>();
    }

    void Update()
    {
        Scene currentScene = SceneManager.GetActiveScene();
        if (currentScene.name == "GameScene"){
            scoreText.text = scoreValue.ToString();
        }
        if (scoreValue < 0){
            FallingTargets.fallingSpeed = 15f;
            BarriersFalling.fallingSpeed = 15f;
            SpawningTargets.lowEdgePos = 0.055f;
            SpawningTargets.highEdgePos = 1.055f;
            SpawningTargets.lowEdgeNeg = 0.055f;
            SpawningTargets.highEdgeNeg = 2.055f;
            SceneManager.LoadScene("GameOver");
        }
    }
}