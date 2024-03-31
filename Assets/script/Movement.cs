using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Movement : MonoBehaviour
{
    [SerializeField] private float speed;
    private Rigidbody2D body;

    private bool grounded;


    public GameObject lvl1;
    public GameObject lvl2;

    private void Awake ()
    {
        body = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        float horizontalInput = Input.GetAxis("Horizontal");
        body.velocity = new Vector2(horizontalInput* speed, body.velocity.y);

        if(horizontalInput > 0.01f) {
            transform.localScale = Vector3.one;}

        else if (horizontalInput < -0.01f) {
            transform.localScale = new Vector3(-1, 1, 1);
        }    

        if(Input.GetKey(KeyCode.Space) && grounded) {
            Jump();
        }


    }

    private void Jump() {
        body.velocity = new Vector2(body.velocity.x, speed);
        grounded = false;
    }

    private void OnCollisionEnter2D(Collision2D collision) {
        if(collision.gameObject.tag == "ground")
            grounded = true;
        if(collision.gameObject.tag == "Finish")
            RestartScene();   
        if (collision.gameObject.tag == "Win")
        {
            SceneManager.LoadScene("lvl2");
        }  
    }

    private void RestartScene() {

        string sceneToReload = "lvl1";

        SceneManager.LoadScene(sceneToReload);
    }

    

}
