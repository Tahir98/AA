using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SmallCircleScript : MonoBehaviour
{
    private Rigidbody2D rb;

    public float speed;
    private bool movementControl = false;

    GameObject gameManager;
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();

        gameManager = GameObject.FindGameObjectWithTag("GameManager");
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if(!movementControl)
            rb.MovePosition(rb.position + Vector2.up * speed * Time.fixedDeltaTime);
    }

    private void OnTriggerEnter2D(Collider2D collision) {
        if(collision.tag == "SpinningCircle") {
            movementControl = true;
            transform.SetParent(collision.gameObject.transform);

            if (gameManager.GetComponent<GameManager>().circleCount == 0) {
                gameManager.GetComponent<GameManager>().GameFinished();
            }
        }

        if(collision.tag == "SmallCircle") {
            gameManager.GetComponent<GameManager>().GameOver();
        }
    }
}
