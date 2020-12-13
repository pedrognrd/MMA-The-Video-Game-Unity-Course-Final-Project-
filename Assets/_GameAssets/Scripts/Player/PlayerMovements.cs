using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovements : MonoBehaviour
{
    [Range(1, 1000)]
    public float speed = 200;
    float x;
    float y;
    Animator animator;
    Rigidbody2D rigidBody;

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

        /*if (Mathf.Abs(rigidBody.velocity.x) > 0)
        {
            animator.SetBool("Walking", true);
        }
        else
        {
            animator.SetBool("Walking", false);
        }*/
    }
}

