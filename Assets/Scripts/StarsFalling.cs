using UnityEngine;

public class StarsFalling : MonoBehaviour
{
    public static float fallingSpeed = 8f;
    void Update(){
        if (transform.position.y < -5.1f){
            Destroy (gameObject);
        }
        transform.position -= new Vector3 (0,fallingSpeed*Time.deltaTime,0);
    }
}
