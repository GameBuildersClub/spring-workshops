using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    private Rigidbody2D rbody;
    public float jumpForce;
    private bool longJump = false;
    private float slamIncrease = 0;
    private float inputBuffTimer = 0;
    private float coyoteTimer = 0;

    private bool canJump = false;
    // Start is called before the first frame update
    void Start()
    {
        rbody = GetComponent<Rigidbody2D>();
    }

    private void Update()
    {
        if(Input.GetKeyDown(KeyCode.Space))
        {
            if(canJump || coyoteTimer > 0)
            {
                Jump();
            }
            else
            {
                inputBuffTimer = .2f;
            }
        }
        if(Input.GetKeyUp(KeyCode.Space))
        {
            longJump = false;
        }

        if (inputBuffTimer > 0)
        {
            inputBuffTimer -= Time.deltaTime;
            if(canJump)
            {
                Jump();
            }
        }
        if(coyoteTimer > 0)
        {
            coyoteTimer -= Time.deltaTime;
        }
    }

    void FixedUpdate()
    {
        if(longJump)
        {
            rbody.gravityScale = 1f + slamIncrease;
        }
        else
        {
            rbody.gravityScale = 4f + slamIncrease;
        }
        if(rbody.velocity.y < 0)
        {
            slamIncrease = .5f;
        }
        else
        {
            slamIncrease = 0;
        }
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        canJump = true;
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        canJump = false;
        if(rbody.velocity.y <= 0)
        {
            coyoteTimer = .2f;
        }
    }


    void Jump()
    {
        rbody.velocity = new Vector2(rbody.velocity.x, jumpForce);
        if(Input.GetKey(KeyCode.Space))
        {
            longJump = true;
        }
        else
        {
            longJump = false;
        }
    }
}
