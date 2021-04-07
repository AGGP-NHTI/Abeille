using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pistol : MonoBehaviour
{
    public GameObject Bullet;
    public GameObject BSpawn;

    // Update is called once per frame
    public virtual void Update()
    {
        if (Input.GetButtonDown("Fire1"))
        {
            Fire();
        }
    }

    public virtual void Fire()
    {
        var b = Instantiate(Bullet, BSpawn.transform.position, transform.rotation);
        Destroy(b, 2f);
    }
}
