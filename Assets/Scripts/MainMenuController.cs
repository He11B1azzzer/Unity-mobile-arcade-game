using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
public class MainMenuController : MonoBehaviour
{
    public AudioSource KeyPress;
    public AudioSource background;
    public GameObject mainMenuObject;
    public GameObject optionsObject;
    public GameObject quitObject;
    private GameObject previousObject;
    private GameObject previousObjectBefore;
    public Text helpFieldText;
    void Start()
    {
        background.Play();
        mainMenuObject.SetActive(true);
        helpFieldText.text = "";
    }
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            KeyPress.Play();
            if (mainMenuObject.activeSelf)
            {
                mainMenuObject.SetActive(false);
                previousObject = mainMenuObject;
                quitObject.SetActive(true);
                previousObjectBefore = quitObject;
            }
            else
            {
                previousObjectBefore.SetActive(false);
                previousObject.SetActive(true);
            }
        }
    }

    public void Play()
    {
        KeyPress.Play();
        SceneManager.LoadScene("GameScene");
    }

    public void Options()
    {
        KeyPress.Play();
        mainMenuObject.SetActive(false);
        previousObject = mainMenuObject;
        optionsObject.SetActive(true);
        previousObjectBefore = optionsObject;
    }

    public void SoundOn()
    {
        PlayerPrefs.SetInt("SoundOn", 1);
        helpFieldText.text = "SOUND IS ON";
    }
    public void SoundOff()
    {
        PlayerPrefs.SetInt("SoundOn", 0);
        helpFieldText.text = "SOUND IS OFF";
    }
    public void Quit()
    {
        KeyPress.Play();
        mainMenuObject.SetActive(false);
        previousObject = mainMenuObject;
        quitObject.SetActive(true);
        previousObjectBefore = quitObject;
    }

    public void Back()
    {
        KeyPress.Play();
        optionsObject.SetActive(false);
        mainMenuObject.SetActive(true);
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
        mainMenuObject.SetActive(true);
    }
}