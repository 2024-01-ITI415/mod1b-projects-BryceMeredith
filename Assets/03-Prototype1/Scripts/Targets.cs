using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Targets : MonoBehaviour
{
    [Header("Set in Inspector")]
    public TextMeshProUGUI          keepScore;
    public GameObject               targetPrefab;
    public float                    speed = 1f;
    public float                    topAndBottomEdge = 10f;
    public float                    chanceToChangeDirections = 0.1f;
    private int                     score;


    // Update is called once per frame
    void Update()
    {
        Vector3 pos = transform.position;
        pos.y += (speed * Time.deltaTime);
        transform.position = pos;

        // Changing Direction
        if (pos.y <-topAndBottomEdge) {
            speed = Mathf.Abs(speed); // Move Up
        } else if (pos.y > topAndBottomEdge) {
            speed = -Mathf.Abs(speed); // Move Down
        }
    }

    void FixedUpdate() {
        if (Random.value < chanceToChangeDirections ){
            speed *= -1;
        }
    }

    void OnCollisionEnter(Collision coll) {
        GameObject collidedWith = coll.gameObject;
        if (collidedWith.tag == "Arrow") {
            Destroy(collidedWith);
            score = score + 100;
            SetScore();
        }
    }

    void SetScore() {
        keepScore.text = "Score: " + score.ToString();
    }

    void Start() {
        score = 0;
        SetScore();
    }
}
