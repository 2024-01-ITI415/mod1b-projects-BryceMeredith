using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Arrow : MonoBehaviour
{
    public TextMeshProUGUI          countLives;
    public TextMeshProUGUI          gOver;
    public static float             rightX = 5f;
    private int                     lives;

    void OnCollisionEnter(Collision coll) {

        GameObject collidedWith = coll.gameObject; // collidedWith == arrow
        if (collidedWith.tag == "Arrow") {
            Destroy(collidedWith);
            lives = lives - 1;
            if (lives == 0){
                gameOver();
                SceneManager.LoadScene("Main-Prototype 1");
            }
            SetCountLives();
        }
    }

    void SetCountLives() {
        countLives.text = "Lives: " + lives.ToString();
    }

    void gameOver(){
        gOver.text = "Game Over!!!.";
    }

    void Start() {
        lives = 5;
        SetCountLives();
    }
}