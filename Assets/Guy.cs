using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Guy : MonoBehaviour
{
    Rigidbody2D RB;

    // Start is called before the first frame update
    void Start()
    {
        RB = gameObject.GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.W))
        {
            RB.AddForce(new Vector2(0, 150));
        }
        if(Input.GetKey(KeyCode.D))
        {
            RB.AddForce(new Vector2(1, 0));
        }
        if(Input.GetKey(KeyCode.A))
        {
            RB.AddForce(new Vector2(-1, 0));
            
        }

    }
}
