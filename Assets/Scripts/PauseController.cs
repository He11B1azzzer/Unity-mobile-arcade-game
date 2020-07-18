using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseController : MonoBehaviour
{
    public static bool isPaused = false;
    public GameObject pauseMenuUI;
    public GameObject countdownTextUI;
    public AudioSource KeyPress;
    void Update()
    {
        if (Application.platform == RuntimePlatform.Android) { 
            if (Input.GetKeyDown(KeyCode.Escape)) {
                if (isPaused){
                    Resume();
                } else {
                    Pause();
                }            
            }
        }
    }
    public void Resume(){
        KeyPress.Play();
        pauseMenuUI.SetActive(false);
        countdownTextUI.SetActive(true);
        Time.timeScale = 1f;
        isPaused = false;
    }
    public void Pause(){
        KeyPress.Play();
        pauseMenuUI.SetActive(true);
        countdownTextUI.SetActive(false);
        Time.timeScale = 0f;
        isPaused = true;
    }
    public void MainMenu(){
        KeyPress.Play();
        Time.timeScale = 1f;
        isPaused = false;
        SceneManager.LoadScene("MainMenu");
        
    }

    public void Quit(){
        KeyPress.Play();
        pauseMenuUI.SetActive(false);
        Time.timeScale = 1f;
        isPaused = false;
        Application.Quit();
    }
}
