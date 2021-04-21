using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class outofbounds : MonoBehaviour
{
    public void OnTriggerEnter2D(Collider2D collision)
    {
        Guy guy = collision.gameObject.GetComponent<Guy>();

        if (guy)
        {
            guy.TakeDamage(9001, 0, Vector2.zero); //thanks prof
        }
    }
}
