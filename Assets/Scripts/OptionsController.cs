using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class OptionsController : MonoBehaviour
{
    public AudioSource KeyPress;
    public void Option1(){
        KeyPress.Play();
    }
    public void Option2(){
        KeyPress.Play();
    }
    public void Back(){
        KeyPress.Play();
        SceneManager.LoadScene("MainMenu");
    }
    void Update()
    {
        if (Application.platform == RuntimePlatform.Android) { 
            if (Input.GetKeyDown(KeyCode.Escape)) {
                SceneManager.LoadScene("MainMenu");
                KeyPress.Play();
            }
        }
    }
}
