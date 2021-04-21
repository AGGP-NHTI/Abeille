using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pistol : MonoBehaviour
{
    public GameObject Projectile;
    public GameObject BSpawn;
    public float gunHarm;

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
        Bullet bullet = Projectile.GetComponent<Bullet>();

        gunHarm = 5;

        bullet.Damage = gunHarm;

        var b = Instantiate(Projectile, BSpawn.transform.position, transform.rotation);
        Destroy(b, 2f);
    }
}
