using UnityEngine;

public class PpMovement : MonoBehaviour
{
    public float speed = 5f;
    public bool switchAxis = false;

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Return) || Input.GetKeyDown(KeyCode.KeypadEnter))
        {
            transform.position += new Vector3(1f, 0f, 0f);
        }
    }

    void FixedUpdate()
    {
        float horizontalMovement = Input.GetAxisRaw("Horizontal");
        float verticalMovement = Input.GetAxisRaw("Vertical");

        if (switchAxis)
        {
            transform.position += new Vector3(verticalMovement * speed * Time.fixedDeltaTime, horizontalMovement * speed * Time.fixedDeltaTime, 0f);
        }
        else
        {
            transform.position += new Vector3(horizontalMovement * speed * Time.fixedDeltaTime, verticalMovement * speed * Time.fixedDeltaTime, 0f);
        }
    }
}
