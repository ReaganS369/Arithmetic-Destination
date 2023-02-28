using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float moveSpeed;
    private Vector2 moveDirection;
    [SerializeField]
    private Rigidbody2D rb;

    private void Update()
    {
        moveDirection = new Vector2(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical")).normalized;

        if (Input.GetKeyDown(KeyCode.Return))
        {
            // Swap move direction on enter key press
            if (moveDirection.x != 0)
            {
                moveDirection = new Vector2(0, moveDirection.x);
            }
            else if (moveDirection.y != 0)
            {
                moveDirection = new Vector2(moveDirection.y, 0);
            }
        }
    }

    private void FixedUpdate()
    {
        rb.velocity = moveDirection * moveSpeed;
    }
}
