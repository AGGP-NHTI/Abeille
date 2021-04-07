using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Guy2 : MonoBehaviour
{
    public GameObject feet;
    public LayerMask groundLayer;
    public Color rayColor;

    Rigidbody2D RB;
    BoxCollider2D col;
    bool grounded;
    ShoeBase Legs;

    // Start is called before the first frame update
    void Start()
    {
        RB = gameObject.GetComponent<Rigidbody2D>();
        col = gameObject.GetComponent<BoxCollider2D>();
        grounded = false;
        Legs = feet.GetComponent<ShoeBase>();
    }

    // Update is called once per frame
    void Update()
    {
        grounded = IsGrounded();

        if (Input.GetKeyDown(KeyCode.W) && grounded)
        {
            RB.AddForce(new Vector2(0, 400));
        }
        if (Input.GetKey(KeyCode.D))
        {
            RB.AddForce(new Vector2(1, 0));
            Legs.Walk(feet, -1);
        }
        if (Input.GetKey(KeyCode.A))
        {
            RB.AddForce(new Vector2(-1, 0));
            Legs.Walk(feet, 1);
        }

    }

    bool IsGrounded()
    {
        RaycastHit2D hit = Physics2D.Raycast(col.bounds.center, Vector2.down, col.bounds.extents.y + 0.1f, groundLayer);
        Debug.DrawRay(col.bounds.center, Vector2.down * (col.bounds.extents.y + 0.1f), rayColor);
        return hit.collider != null;

    }
}
