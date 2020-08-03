using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;
public class SpawnBarrier : MonoBehaviour
{
    public GameObject LeftBarrier;
    public GameObject RightBarrier;
    public GameObject Box1;
    public GameObject Box2;
    public GameObject Stick1;
    public GameObject Stick2;
    void Start()
    {
        Scene currentScene = SceneManager.GetActiveScene();
        if (currentScene.name == "GameScene"){
            StartCoroutine(SpawnBarrLeft());
            StartCoroutine(SpawnBarrRight());
            StartCoroutine(SpawnBox1());
            StartCoroutine(SpawnBox2());
            StartCoroutine(SpawnStick1());
        }
    }
    IEnumerator SpawnBarrLeft(){
        yield return new WaitForSeconds(Random.Range(3f,6f));
        while (true){
            float xPos = Random.Range(-4f,-3f);
            Instantiate(LeftBarrier, new Vector2(xPos,5.5f),Quaternion.identity);
            yield return new WaitForSeconds(Random.Range(1f,4f));
        }
    }
    IEnumerator SpawnBarrRight(){
        yield return new WaitForSeconds(Random.Range(3f,6f));
        while (true){
            float xPos = Random.Range(3f,4f);
            Instantiate(RightBarrier, new Vector2(xPos, 5.5f), Quaternion.identity);
            yield return new WaitForSeconds(Random.Range(2f,5f));
        }
    }

    IEnumerator SpawnBox1(){
        yield return new WaitForSeconds(8f);
        while (true){
            float xPos = Random.Range(-3f,3f);
            Instantiate(Box1, new Vector2(xPos, 5.5f), Quaternion.identity);
            yield return new WaitForSeconds(Random.Range(4f,8f));
        }
    }
    IEnumerator SpawnBox2(){
        yield return new WaitForSeconds(12f);
        while (true){
            float xPos = Random.Range(-3f,3f);
            Instantiate(Box2, new Vector2(xPos, 5.5f), Quaternion.identity);
            yield return new WaitForSeconds(Random.Range(4f,24f));
        }
    }

    IEnumerator SpawnStick1(){
        yield return new WaitForSeconds(18f);
        while (true){
            float xPos = Random.Range(-1.5f,1.5f);
            Instantiate(Stick1, new Vector2(xPos,5.5f), Quaternion.identity);
            yield return new WaitForSeconds(Random.Range(2f,6f));
        }
    }
    IEnumerator SpawnStick2(){
        yield return new WaitForSeconds(24f);
        while (true){
            float xPos = Random.Range(-2f,2f);
            Instantiate(Stick2, new Vector2(xPos,5.5f), Quaternion.identity);
            yield return new WaitForSeconds(Random.Range(2f,14f));
        }
    }
}
