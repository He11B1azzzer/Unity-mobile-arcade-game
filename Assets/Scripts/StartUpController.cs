using UnityEngine;
using UnityEngine.SceneManagement;
public class StartUpController: MonoBehaviour
{   void Start()
    {
        SceneManager.LoadScene("MainMenu");
    }
}