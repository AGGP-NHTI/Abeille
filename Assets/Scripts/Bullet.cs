using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    Rigidbody2D RB;
    public float Damage = 10;
    public float Knockback = 0;

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
        Guy player = collision.gameObject.GetComponentInParent<Guy>();
        if (player)
        {
            Vector2 direction = (collision.gameObject.transform.position - gameObject.transform.position).normalized;
            player.TakeDamage(Damage, Knockback, direction);
        }
        
        if(!collision.gameObject.GetComponent<Bullet>())
        {
            Destroy(gameObject);
        }
    }
}
