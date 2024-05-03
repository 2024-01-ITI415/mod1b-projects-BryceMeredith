using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Targets : MonoBehaviour
{
    [Header("Set in Inspector")]
    public GameObject               targetPrefab;
    public float                    speed = 1f;
    public float                    topAndBottomEdge = 10f;
    public float                    chanceToChangeDirections = 0.1f;


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 pos = transform.position;
        pos.y += speed * Time.deltaTime;
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
        Destroy(this.gameObject);
    }
}
