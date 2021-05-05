using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Uzi : Pistol
{
    public float firedelay;
    float firetimer;

    // Update is called once per frame
    public override void Update()
    {
        if (Time.time >= firetimer + firedelay)
        {
            firetimer = Time.time;
            Fire();
        }
    }

    public override void Fire()
    {
        shot.Play();

        Bullet bullet = Projectile.GetComponent<Bullet>();

        bullet.Damage = gunDamage;

        var b = Instantiate(Projectile, BSpawn.transform.position, transform.rotation);
        Destroy(b, 2f);
    }
}
