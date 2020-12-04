using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerOrientation : MonoBehaviour
{
    float x;
    
    // Update is called once per frame
    void Update()
    {
        x = Input.GetAxis("Horizontal");
        if (x > 0)
        {
            transform.localScale = new Vector3(1,1,1);
        }
        if (x < 0)
        {
            transform.localScale = new Vector3(-1, 1, 1);
        }
    }
}
