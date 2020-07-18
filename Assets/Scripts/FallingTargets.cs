using UnityEngine;

public class FallingTargets : MonoBehaviour
{
    public static float fallingSpeed = 15f;
    void Update()
    {
        if (transform.position.y < -5.1f)
        {
            if (gameObject.tag == "TargetPositive")
            {
                ScoreScript.scoreValue += HitingTargets.pointsSkipPos;
            }
            else if (gameObject.tag == "TargetNegative")
            {
                ScoreScript.scoreValue += HitingTargets.pointsSkipNeg;
            }
            Destroy(gameObject);
        }
        if (PauseController.isPaused){
            transform.position = transform.position;
        } else {
            transform.position -= new Vector3(0, fallingSpeed * Time.deltaTime, 0);
        }
        
    }
}
