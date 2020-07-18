using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class BarriersFalling : MonoBehaviour
{
    public static float fallingSpeed = 15f;

    void Update()
    {
        if (transform.position.y < -5.5f){
            Destroy(gameObject);
        }
        if (PauseController.isPaused){
            transform.position = transform.position;
        } else {
            transform.position -= new Vector3(0, fallingSpeed * Time.deltaTime, 0);
        }     
    }
}
