using System.Collections;
using UnityEngine;
public class SpawningStars : MonoBehaviour
{
    public GameObject oneForAll;
    public GameObject star1;
    public GameObject star2;
    public GameObject star3;
    public GameObject star4;
    public GameObject star5;
    public GameObject star6;
    public GameObject star7;
    void Start()
    {
        GameObject[] gameObjects = GameObject.FindGameObjectsWithTag("Spawner");
        for (int i = gameObjects.Length; i != 1; i--)
        {
            Destroy(gameObjects[i]);
        }
        DontDestroyOnLoad(oneForAll);
        StartCoroutine(SpawnStar());
    }

    IEnumerator SpawnStar()
    {
        while (true)
        {
            Instantiate(star1, new Vector2(Random.Range(-3.1f, 3.1f), 5), Quaternion.identity);
            Instantiate(star2, new Vector2(Random.Range(-3.1f, 3.1f), 5), Quaternion.identity);
            Instantiate(star3, new Vector2(Random.Range(-3.1f, 3.1f), 5), Quaternion.identity);
            Instantiate(star5, new Vector2(Random.Range(-3.1f, 3.1f), 5), Quaternion.identity);
            Instantiate(star5, new Vector2(Random.Range(-3.1f, 3.1f), 5), Quaternion.identity);
            yield return new WaitForSeconds(Random.Range(0.01f, 0.075f));
        }
    }
}
