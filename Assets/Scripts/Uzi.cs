using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Uzi : Pistol
{
    public float firedelay;
    float firetimer;

    public override void Fire()
    {
        if (Time.time >= firetimer + firedelay)
        {
            firetimer = Time.time;

            shot.Play();

            Bullet bullet = Projectile.GetComponent<Bullet>();

            bullet.Damage = gunDamage;

            var b = Instantiate(Projectile, BSpawn.transform.position, transform.rotation);
            Destroy(b, 2f);
        }
    }
}
