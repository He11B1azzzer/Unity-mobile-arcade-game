using UnityEngine;

public class SoundControl : MonoBehaviour
{
    void Update()
    {
        if (PlayerPrefs.GetInt("SoundOn") == 1)
        {
            AudioListener.pause = false;
        }
        else
        {
            AudioListener.pause = true;
        }
    }
}
