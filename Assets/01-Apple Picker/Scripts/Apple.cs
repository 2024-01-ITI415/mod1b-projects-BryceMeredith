using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Apple : MonoBehaviour
{
    public static float bottomY = -20f;

    // Update is called once per frame
    void Update()
    {
        if (transform.position.y < bottomY)
        {
            Destroy(this.gameObject);

            //Get as referecne to the ApplePicker component of the Main Camera
            ApplePicker apScript = Camera.main.GetComponent<ApplePicker>();
            // Call the puhblic AppleDestroyed() method of apScript
            apScript.AppleDestroyed();
        }
    }
}
