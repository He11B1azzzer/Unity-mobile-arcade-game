using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
public class MainMenuController : MonoBehaviour
{
    public AudioSource KeyPress;
    public void PlayGame(){
        KeyPress.Play();
        SceneManager.LoadScene("GameScene");
        ScoreScript.scoreValue = 0;
    }
    public void Options(){
        KeyPress.Play();
        SceneManager.LoadScene("OptionsScene");
    }
    public void exitGame(){
        KeyPress.Play();
        Application.Quit();
    }

    void Update()
    {
        if (Application.platform == RuntimePlatform.Android) { 
            if (Input.GetKeyDown(KeyCode.Escape)) {
                Application.Quit();            
            }
        }
    }
}
