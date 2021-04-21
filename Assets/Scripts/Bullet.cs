﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    Rigidbody2D RB;
    public float Damage;

    // Start is called before the first frame update
    void Start()
    {
        RB = gameObject.GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        RB.velocity = (transform.right * 30f);
        
    }

    public void OnCollisionEnter2D(Collision2D collision)
    {
        if(!collision.gameObject.GetComponent<Bullet>())
        {
            Destroy(gameObject);
        }
    }
}
