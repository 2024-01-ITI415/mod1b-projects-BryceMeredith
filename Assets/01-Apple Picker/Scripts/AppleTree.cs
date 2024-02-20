using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AppleTree : MonoBehaviour
{

    [Header ("Set in Inspector")]
    // Prefab for instantiating apples
    public GameObject applePrefab;

    // Speed at which AppleTree moves
    public float speed = 1f;

    // Distance where AppleTree turns around
    public float leftAndRightEdge = 10f;

    // Chance that AppleTree will change directions
    public float chanceToChangeDirections = 0.1f;

    // Rate at which Apple will be instantiated
    public float secondsBetweenAppleDrops = 1f;


    // Start is called before the first frame update
    void Start()
    {
        // Dropping Apples every second
        Invoke ("DropApple", 2f);
    }

    void DropApple()
    {
        GameObject apple = Instantiate<GameObject> (applePrefab);
        apple.transform.position = transform.position;
        Invoke ("DropApple", secondsBetweenAppleDrops);
    }

    // Update is called once per frame
    void Update()
    {
        // Basic Movement
        Vector3 pos = transform.position;
        pos.x += speed * Time.deltaTime;
        transform.position = pos;
        
        // Changing Directions
        if (pos.x < -leftAndRightEdge)
        {
            speed = Mathf.Abs(speed); // Move Right
        }
        else if (pos.x > leftAndRightEdge)
        {
            speed = -Mathf.Abs(speed);  // Move Left
        }
    }

    void FixedUpdate()
    {
        // Changing Direction randomly is now based on time 
        if (Random.value < chanceToChangeDirections)
        {
            speed *= -1;  // Change Direction
        }
    }
}
