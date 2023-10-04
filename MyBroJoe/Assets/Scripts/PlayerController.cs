using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController : MonoBehaviour
{
    [SerializeField] private float jumpingPower = 15f;
    private Rigidbody rb;
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

    // Triggers Jump
    public void OnJump(InputAction.CallbackContext context)
    {
        if(context.started)
        {
            Jump();
        }

    }

    private void Jump()
    {
        rb.velocity = new Vector3(rb.velocity.x, jumpingPower, rb.velocity.z);
    }
}
