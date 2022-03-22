using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
public class GameManager : MonoBehaviour {

    GameObject spinningCircle;
    GameObject mainCircle;

    public Animator animator;

    public Text levelText;

    private bool isGameFinished = false;
    private float duration = 0;

    public Button menuButton;
    public Button restartButton;

    public Text rt1;
    public Text rt2;
    public Text rt3;

    public int circleCount;

    void Start()
    {
        spinningCircle = GameObject.FindGameObjectWithTag("SpinningCircle");
        mainCircle = GameObject.FindGameObjectWithTag("MainCircle");

        levelText.text = SceneManager.GetActiveScene().name;
  
        if(circleCount < 1) {
            Debug.Log("Circle cannot be less than 1");
        }
        else if(circleCount == 1) {
            rt1.text = "" + circleCount;
        }
        else if(circleCount == 2) {
            rt1.text = "" + circleCount;
            rt2.text = "" + (circleCount - 1);
        }
        else {
            rt1.text = "" + circleCount;
            rt2.text = "" + (circleCount - 1);
            rt3.text = "" + (circleCount - 2);
        }
    }

    public void Update() {
        if(animator.GetCurrentAnimatorStateInfo(0).IsName("GameFinished") && animator.GetCurrentAnimatorStateInfo(0).normalizedTime > 1.5) {
            SceneManager.LoadScene("MainMenu");
        }

        if (animator.GetCurrentAnimatorStateInfo(0).IsName("GameOver") && animator.GetCurrentAnimatorStateInfo(0).normalizedTime > 1.5) {
            SceneManager.LoadScene("MainMenu");
        }
    }


    public void UpdateCircleTexts() {
        if (circleCount < 1) {
            rt1.text = "" + circleCount;
            rt2.text = "";
            rt3.text = "";
        }
        else if (circleCount == 1) {
            rt1.text = "" + circleCount;
            rt2.text = "";
            rt3.text = "";
        }
        else if (circleCount == 2) {
            rt1.text = "" + circleCount;
            rt2.text = "" + (circleCount - 1);
            rt3.text = "";
        }
        else {
            rt1.text = "" + circleCount;
            rt2.text = "" + (circleCount - 1);
            rt3.text = "" + (circleCount - 2);
        }
    }

    public void GameFinished () {
        spinningCircle.GetComponent<Spin>().enabled = false;
        mainCircle.GetComponent<MainCircleScript>().enabled = false;

        animator.SetTrigger("IsGameFinished");

        PlayerPrefs.SetString("Level",SceneManager.GetActiveScene().name);
        
    }


    public void GameOver() {
        spinningCircle.GetComponent<Spin>().enabled = false;
        mainCircle.GetComponent<MainCircleScript>().enabled = false;

        animator.SetTrigger("IsGameOver");
    }
}
