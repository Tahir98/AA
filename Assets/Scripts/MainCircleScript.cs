using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainCircleScript : MonoBehaviour
{

    public GameObject smallCircle;

    public float fireSpeed;
    private float duration = 0;

    GameObject gameManager;

    void Start()
    {
        gameManager = GameObject.FindGameObjectWithTag("GameManager");
    }

    void Update()
    {
        duration += Time.deltaTime;

        if(Input.GetButtonDown("Fire1") && duration > fireSpeed) {
            initSmallCircle();
            duration = 0;
            gameManager.GetComponent<GameManager>().circleCount--;
            gameManager.GetComponent<GameManager>().UpdateCircleTexts();
        }
    }

    void initSmallCircle() {
        Instantiate(smallCircle, transform.position, transform.rotation);
    }
}
