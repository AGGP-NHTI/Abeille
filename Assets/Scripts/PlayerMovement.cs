using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    private Rigidbody rb;
    public float moveSpeed;

    bool left;
    bool right;

    // Start is called before the first frame update
    void Start()
    {
        rb = gameObject.GetComponent<Rigidbody>();
    }
    
    private void FixedUpdate()
    {
        GetInput();

        if (left == true)
        {
            MoveRight(-1);
        }
        if (right == true)
        {
            MoveRight(1);
        }
    }

    public void GetInput()
    {
        left = Input.GetKey(KeyCode.A);
        right = Input.GetKey(KeyCode.D);
    }

    void MoveRight(float value)
    {
        Vector3 direction = Vector3.zero;
        direction += gameObject.transform.right * moveSpeed * value;
        rb.velocity = direction;
    }
}
