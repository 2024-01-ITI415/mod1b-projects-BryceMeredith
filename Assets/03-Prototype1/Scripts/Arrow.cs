using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Arrow : MonoBehaviour
{
    public static float             rightX = 5f;
    public int                      lives = 5;


    void OnCollisionEnter(Collision coll) {

        GameObject collidedWith = coll.gameObject; // collidedWith == the target or ground
        if (collidedWith.tag == "ground"){
            Destroy(this.gameObject);
            lives = lives - 1;
        } else {
            //Destroy(this.gameObject);
        }
    }
}