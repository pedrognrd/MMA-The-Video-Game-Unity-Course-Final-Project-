

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovements : MonoBehaviour
{
    [Range(1, 1000)]
    public float speed = 200f;
    float x;
    float y;
    Animator animator;
    Rigidbody2D rigidBody;
    public Vector3 endPosition;

    private void Awake()
    {
        rigidBody = GetComponent<Rigidbody2D>();
        animator = GetComponentInChildren<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        x = Input.GetAxis("Horizontal");
        y = Input.GetAxis("Vertical");

        Displace();
    }

    private void Displace()
    {
        rigidBody.velocity = new Vector2(x * Time.deltaTime * speed, rigidBody.velocity.y);
    }
    /*public Vector3 endPosition;
    public float speed = 1f; // The monster will move a one unity per second
    public void Update()
    {
        float step = speed * Time.deltaTime;
        transform.position = Vector3.MoveTowards(transform.position, endPosition, step);
    }*/
}


