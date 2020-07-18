using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SpawningTargets : MonoBehaviour
{
    public GameObject TargetPositive;
    public GameObject TargetNegative;
    public GameObject TargetBonus;
    public GameObject TargetDebuff;
    public GameObject InstantLose;
    public static float lowEdgeNeg = 0.055f;
    public static float highEdgeNeg = 2.055f;
    public static float lowEdgePos = 0.055f;
    public static float highEdgePos = 1.055f;
    public static float lowEdgeBon = 3f;
    public static float highEdgeBon = 8f;
    public static float lowEdgeDeb = 3f;
    public static float highEdgeDeb = 6f;
    void Start()
    {
        Scene currentScene = SceneManager.GetActiveScene();
        if (currentScene.name == "GameScene"){
            StartCoroutine(SpawnPositive());
            StartCoroutine(SpawnNegative());
            StartCoroutine(SpawnBonus());
            StartCoroutine(SpawnDebuff());
            StartCoroutine(SpawnInstantLose());
        }
    }

    IEnumerator SpawnPositive()
    {
        yield return new WaitForSeconds(7f);
        while (true)
        {
            float xPos = GenerateRandom.genRandom(-2.5, 2.5);
            Instantiate(TargetPositive, new Vector2(xPos, 5.5f), Quaternion.identity);
            yield return new WaitForSeconds(Random.Range(lowEdgePos, highEdgePos));
        }
    }

    IEnumerator SpawnNegative()
    {
        yield return new WaitForSeconds(5f);
        while (true)
        {
            float xPos = GenerateRandom.genRandom(-2.5, 2.5);
            Instantiate(TargetNegative, new Vector2(xPos, 5.5f), Quaternion.identity);
            yield return new WaitForSeconds(Random.Range(lowEdgeNeg, highEdgeNeg));
        }
    }

    IEnumerator SpawnBonus()
    {
        yield return new WaitForSeconds(6f);
        while (true)
        {
            float xPos = GenerateRandom.genRandom(-2.5, 2.5);
            Instantiate(TargetBonus, new Vector2(xPos, 5.5f), Quaternion.identity);
            yield return new WaitForSeconds(GenerateRandom.genRandom(Random.Range(lowEdgeBon, highEdgeBon), Random.Range(lowEdgeBon, highEdgeBon)));
        }
    }

    IEnumerator SpawnDebuff()
    {
        yield return new WaitForSeconds(6f);
        while (true)
        {
            float xPos = GenerateRandom.genRandom(-2.5, 2.5);
            Instantiate(TargetDebuff, new Vector2(xPos, 5.5f), Quaternion.identity);
            yield return new WaitForSeconds(GenerateRandom.genRandom(Random.Range(lowEdgeDeb, highEdgeDeb), Random.Range(lowEdgeDeb, highEdgeDeb)));
        }
    }

    IEnumerator SpawnInstantLose(){
        yield return new WaitForSeconds(Random.Range(6f,18f));
        while (true){
            float xPos = GenerateRandom.genRandom(-2.5, 2.5);
            Instantiate(InstantLose, new Vector2(xPos, 5.5f), Quaternion.identity);
            yield return new WaitForSeconds(Random.Range(2f,24f));
        }
    }
}   