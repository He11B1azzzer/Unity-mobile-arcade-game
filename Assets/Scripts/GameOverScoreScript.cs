﻿using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
public class GameOverScoreScript : MonoBehaviour
{

    public Text scoreText;
    void Update(){
        if (ScoreScript.scoreValue < 0){
            ScoreScript.scoreValue = 0;
        }
        scoreText.text = ScoreScript.scoreValue.ToString();
    }
}
