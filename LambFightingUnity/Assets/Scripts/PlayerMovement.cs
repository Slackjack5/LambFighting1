using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour

{
    private Rigidbody2D body;
    private Animator anim;
    [SerializeField] private float runSpeed;


    private void Awake()
    {
        //Grab references from rigidbody and animator from object
        body = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
    }

    private void Update()
    {
        float horizontalInput = Input.GetAxisRaw("Horizontal");
        body.velocity = new Vector2(horizontalInput * runSpeed, body.velocity.y);

        //Flip player when moving opposite direction
        if (horizontalInput > 0.01f)
            transform.localScale = new Vector3(-1, 1, 1);
        else if (horizontalInput < -0.01f)
            transform.localScale = Vector3.one;

        if (Input.GetKey(KeyCode.W))
            body.velocity = new Vector2(body.velocity.x, runSpeed);

        //Set Animator parameters
        anim.SetBool("Walk", horizontalInput != 0);
    }
}