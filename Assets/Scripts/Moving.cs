using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;
public class Moving : MonoBehaviour
{
    public float speed = 20f;
    public Rigidbody2D rb;
    void Start(){
        Scene currentScene = SceneManager.GetActiveScene();
        if (currentScene.name == "GameScene") {
            rb.transform.position += new Vector3(0,3.0f,0);
            StartCoroutine(CheckState());
        }
    }
    void OnMouseDrag(){
        Scene currentScene = SceneManager.GetActiveScene();
        if (currentScene.name == "GameScene"){
            Vector3 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            mousePos.x = mousePos.x > 2.32f ? 2.32f: mousePos.x;
            mousePos.x = mousePos.x < -2.32f ? -2.32f: mousePos.x;
            mousePos.y = mousePos.y > 4.3f ? 4.3f: mousePos.y;
            mousePos.y = mousePos.y < -4.3f ? -4.3f: mousePos.y;
            rb.position = Vector2.MoveTowards(rb.position, new Vector2(mousePos.x,mousePos.y), speed * Time.deltaTime * 4.5f);
        }
    }
    public IEnumerator CheckState(){
        float mustSpeed = StarsFalling.fallingSpeed;
        while (true){
            Vector3 scaleNormal = new Vector3(0.192f,0.192f,0.192f);
            float normalRotation = rb.rotation;
            float prevPosy = rb.transform.position.y;
            float prevPosx = rb.transform.position.x;
            float prevRotation = rb.rotation;
            yield return new WaitForSeconds(0.005f);
            float curPosy = rb.transform.position.y;
            float curPosx = rb.transform.position.x;
            float curRotation = rb.rotation;
            Vector3 scaleMove = new Vector3(0.164f,0.192f,0.192f);
            if (curPosy > prevPosy){
                StarsFalling.fallingSpeed += (curPosy - prevPosy) / 3 / Time.deltaTime;
            } else {
                StarsFalling.fallingSpeed = mustSpeed;
            }
            if (curPosx > prevPosx){
                rb.MoveRotation(rb.rotation - 50f * Time.deltaTime);
                rb.transform.localScale = scaleMove;
            } else if (curPosx < prevPosx){
                rb.MoveRotation(rb.rotation + 50f * Time.deltaTime);
                rb.transform.localScale = scaleMove;
            } else {
                if (curRotation != prevRotation){
                    rb.MoveRotation(normalRotation * Time.deltaTime);
                    rb.transform.localScale = scaleNormal;
                }
            }
        }
    }
}
