using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Foot : MonoBehaviour
{
    Rigidbody2D RB;
    public float Damage = 10;
    public float Knockback = 0;

    // Start is called before the first frame update
    void Start()
    {
        RB = gameObject.GetComponent<Rigidbody2D>();
    }


    public void OnTriggerEnter2D(Collider2D collision)
    {
        Guy player = collision.gameObject.GetComponentInParent<Guy>();
        if (player)
        {
            Vector2 direction = (collision.gameObject.transform.position - gameObject.transform.position).normalized;
            player.TakeDamage(Damage, Knockback, direction);
        }
    }
}
