using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerMovement : MonoBehaviour
{
    [SerializeField] private float moveDistance = 5f;
    [SerializeField] private Rigidbody2D rb;
    [SerializeField] private Animator anim;

    private Vector2 movement;
    private float x, y = 0f;

    private enum MovementState {idle, teleport}

    [SerializeField] private AudioSource teleportSound; 

    // Update is called once per frame
    private void Update()
    {
        x = Input.GetAxisRaw("Horizontal");
        y = Input.GetAxisRaw("Vertical");

        movement = new Vector3(x, y, 0f);
        UpdateAnimation();
    }

    
    private void FixedUpdate()
    {
        rb.velocity = movement * moveDistance * Time.fixedDeltaTime;
        
    }

    private void UpdateAnimation()
    {
        MovementState state;

        if (x > 0f)
        {
            teleportSound.Play();
            state = MovementState.teleport;
        }

        else if (x < 0f) 
        {
            state = MovementState.teleport;
        }
        
        else if (y > 0f)
        {
            state = MovementState.teleport;
        }

        else if (y < 0f)
        {
            state = MovementState.teleport;
        }
        else
        {
            state = MovementState.idle;
        }

        anim.SetInteger("Player", (int)state);
    }

}
