using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Guy : MonoBehaviour
{
    Rigidbody2D RB;
    bool Grounded;
    public GameObject feet;
    Legs Legs;

    // Start is called before the first frame update
    void Start()
    {
        RB = gameObject.GetComponent<Rigidbody2D>();
        Grounded = false;
        Legs = feet.GetComponent<Legs>();
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.W) && Grounded)
        {
            RB.AddForce(new Vector2(0, 150));
            Grounded = false;
        }
        if(Input.GetKey(KeyCode.D))
        {
            RB.AddForce(new Vector2(1, 0));
            Legs.Walk(feet, -1);
        }
        if(Input.GetKey(KeyCode.A))
        {
            RB.AddForce(new Vector2(-1, 0));
            Legs.Walk(feet, 1);
        }

    }

    public void OnCollisionEnter2D(Collision2D collision)
    {
        Grounded = true;
    }
    public void OnCollisionExit2D(Collision2D collision)
    {
        Grounded = false;
    }


}
