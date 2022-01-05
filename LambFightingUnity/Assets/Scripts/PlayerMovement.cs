using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour

{
    [SerializeField] private GameObject Enemy;
    private int playerSide;
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

        if (gameObject.transform.position.x < Enemy.transform.position.x) { playerSide = -1; } else { playerSide = 1; }

        float horizontalInput = Input.GetAxisRaw("Horizontal");
        body.velocity = new Vector2(horizontalInput * runSpeed, body.velocity.y);

        if (playerSide == -1)
        {
            anim.SetBool("Walk", horizontalInput > 0.01f);
            anim.SetBool("BackWalk", horizontalInput < -0.01f);
            gameObject.transform.localScale = new Vector3(-1, 1, 1);
        }
        else if (playerSide == 1)
        {
            anim.SetBool("Walk", horizontalInput < -0.01f);
            anim.SetBool("BackWalk", horizontalInput > 0.01f);
            gameObject.transform.localScale = Vector3.one;
        }
        if (Input.GetKey(KeyCode.W))
            body.velocity = new Vector2(body.velocity.x, runSpeed);

    }
}