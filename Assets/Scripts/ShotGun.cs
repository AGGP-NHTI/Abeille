using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShotGun : Pistol
{

    public override void Fire()
    {
        GameObject a = Instantiate(Bullet, BSpawn.transform.position, transform.rotation);
        GameObject b = Instantiate(Bullet, BSpawn.transform.position, transform.rotation);
        GameObject c = Instantiate(Bullet, BSpawn.transform.position, transform.rotation);
        a.transform.Rotate(0, 0, 15);
        c.transform.Rotate(0, 0, -15);
        Destroy(a, 2f);
        Destroy(b, 2f);
        Destroy(c, 2f);
    }
}
