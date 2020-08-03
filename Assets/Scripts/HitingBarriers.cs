using UnityEngine;
using UnityEngine.SceneManagement;
public class HitingBarriers : MonoBehaviour
{
    void OnTriggerEnter2D(Collider2D coll)
    {
        if (coll.gameObject.tag == "Barrier"){
            FallingTargets.fallingSpeed = 15f;
            BarriersFalling.fallingSpeed = 15f;
            SpawningTargets.lowEdgePos = 0.055f;
            SpawningTargets.highEdgePos = 1.055f;
            SpawningTargets.lowEdgeNeg = 0.055f;
            SpawningTargets.highEdgeNeg = 2.055f;
            SceneManager.LoadScene("GameOver");       
        }
    }
}
