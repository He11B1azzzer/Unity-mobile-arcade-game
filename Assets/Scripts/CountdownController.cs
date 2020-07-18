using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class CountdownController : MonoBehaviour
{
    public int countdownTime;
    public Text countdownDisplay;
    public GameObject countdownDisplayObj;
    private void Start()
    {
        Scene currentScene = SceneManager.GetActiveScene();
        if (currentScene.name == "GameScene"){
            StartCoroutine(CountdownToStart());
        }
    }
    IEnumerator CountdownToStart()
    {
        countdownDisplayObj.SetActive(true);
        while (countdownTime > 0)
        {
            countdownDisplay.text = countdownTime.ToString();
            yield return new WaitForSeconds(1f);
            countdownTime--;
        }

        countdownDisplay.text = "GO";

        yield return new WaitForSeconds(1f);

        countdownDisplay.text = "";
        countdownDisplayObj.SetActive(false);
    }

}

