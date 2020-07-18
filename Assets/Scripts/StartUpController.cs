using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
public class StartUpController: MonoBehaviour
{   void Start()
    {
        StartCoroutine(onStartUp());
        SceneManager.LoadScene("MainMenu");
    }
    public IEnumerator onStartUp(){
        yield return new WaitForSeconds(3f);
    }
}