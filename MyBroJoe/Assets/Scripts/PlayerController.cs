using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController : MonoBehaviour
{
    private Rigidbody rb;
    private bool isGrounded = true;

    [SerializeField] private float jumpingPower = 15f;

    // Start is called before the first frame update
    void Start()
    {
        // Grabs rigidbody from this game object
        rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {

    }

    //This is a default method that runs everytime the player collider hits another collider
    private void OnCollisionEnter(Collision collision)
    {
        //The tag is set on the ground object. Any object that has the tag ground will tell us that the player is grounded
        if (collision.collider.CompareTag("Ground"))
        {
            isGrounded = true;
        }
    }

    //This is a default method that runs everytime the player collider leaves contact with another collider
    private void OnCollisionExit(Collision collision)
    {
        // If the collider that was left is a ground we are no longer grounded. We also check that our y velocity is positive. This
        // means that we are moving upward and the jump button is hit. If the ball rolls off of a platform this would not allow the
        // player to jump. 
        if (collision.collider.CompareTag("Ground") && rb.velocity.y > .01)
        {
            isGrounded = false;
        }
    }

    // Triggers Jump
    public void OnJump(InputAction.CallbackContext context)
    {
        if (context.started)
        {
            if (isGrounded)
            {
                Jump();
            }
        }

    }

    private void Jump()
    {
        rb.velocity = new Vector3(rb.velocity.x, jumpingPower, rb.velocity.z);
    }
}
