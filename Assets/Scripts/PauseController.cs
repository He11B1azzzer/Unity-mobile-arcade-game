using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseController : MonoBehaviour
{
    public static bool isPaused = false;
    public GameObject pauseMenuUI;
    public GameObject quitObject;
    public GameObject countdownTextUI;
    public AudioSource KeyPress;
    public AudioSource background;
    void Start()
    {
        if (SceneManager.GetActiveScene().name == "GameScene")
        {
            background.Play();
        }
    }
    void Update()
    {
        if (isPaused)
        {
            background.volume = 0.1f;
        }
        else
        {
            background.volume = 0.35f;
        }
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (isPaused)
            {
                KeyPress.Play();
                Resume();
            }
            else
            {
                KeyPress.Play();
                Pause();
            }
        }
    }
    public void Resume()
    {
        KeyPress.Play();
        pauseMenuUI.SetActive(false);
        countdownTextUI.SetActive(true);
        Time.timeScale = 1f;
        isPaused = false;
    }
    public void Pause()
    {
        KeyPress.Play();
        pauseMenuUI.SetActive(true);
        countdownTextUI.SetActive(false);
        Time.timeScale = 0f;
        isPaused = true;
    }
    public void MainMenu()
    {
        KeyPress.Play();
        Time.timeScale = 1f;
        isPaused = false;
        SceneManager.LoadScene("MainMenu");
    }

    public void Quit()
    {
        KeyPress.Play();
        pauseMenuUI.SetActive(false);
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
        pauseMenuUI.SetActive(true);
    }
}
