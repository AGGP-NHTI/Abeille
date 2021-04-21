using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShotGun : Pistol
{

    public override void Fire()
    {
        Bullet bullet = Projectile.GetComponent<Bullet>();

        gunHarm = 10;

        bullet.Damage = gunHarm;

        GameObject a = Instantiate(Projectile, BSpawn.transform.position, transform.rotation);
        GameObject b = Instantiate(Projectile, BSpawn.transform.position, transform.rotation);
        GameObject c = Instantiate(Projectile, BSpawn.transform.position, transform.rotation);
        a.transform.Rotate(0, 0, 15);
        c.transform.Rotate(0, 0, -15);
        Destroy(a, 2f);
        Destroy(b, 2f);
        Destroy(c, 2f);
    }
}
