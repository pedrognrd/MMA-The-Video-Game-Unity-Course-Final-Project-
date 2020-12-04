using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovements : MonoBehaviour
{
    [Range(1, 10)]
    public float jumpForce;
    [Range(1, 1000)]
    public float speed = 200;
    float x;
    float y;
    Rigidbody2D rigidBody;

    private void Awake()
    {
        rigidBody = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        x = Input.GetAxis("Horizontal");
        y = Input.GetAxis("Vertical");

        Displace();

        if (Input.GetKeyDown(KeyCode.X))
        {
            Jump();
        }
    }

    private void Displace()
    {
        rigidBody.velocity = new Vector2(x * Time.deltaTime * speed, rigidBody.velocity.y);

    }
    
    private void Jump() 
    {
        // to the right
        GetComponent<Rigidbody2D>().AddForce(Vector2.up * jumpForce, ForceMode2D.Impulse);
    }

    
}

