using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LungeShoe : ShoeBase
{
    public Vector2 lunge;
    Rigidbody2D RB;
    public void Start()
    {
        RB = guy.gameObject.GetComponent<Rigidbody2D>();
    }

    public override void Kicking()
    {
        if (kick && guy.IsGrounded())
        {
            RB.AddForce(new Vector2( lunge.x * guy.facingH.x, lunge.y));
        }
        base.Kicking();
    }
}
