using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Moving : MonoBehaviour
{
    private float speed = 20f;
    public Rigidbody2D rb;
    void Start(){
  
        if (SceneManager.GetActiveScene().name == "GameScene") {
            StartCoroutine(CheckState());
        }
    }
    void Update()
    {
        OnTouch();
    }
    void OnTouch()
    {
        if (SceneManager.GetActiveScene().name == "GameScene")
        {
            rb.position = new Vector2(Mathf.Clamp(rb.transform.position.x,-2.32f,2.32f),
                                                Mathf.Clamp(rb.transform.position.y,-4.3f,4.3f));
            rb.position = Vector2.MoveTowards(rb.position,
                                                new Vector2(Camera.main.ScreenToWorldPoint(Input.mousePosition).x,
                                                Camera.main.ScreenToWorldPoint(Input.mousePosition).y),
                                                speed * Time.deltaTime * 4.5f);
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
                StarsFalling.fallingSpeed += (curPosy - prevPosy) / 2 / Time.deltaTime;
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
