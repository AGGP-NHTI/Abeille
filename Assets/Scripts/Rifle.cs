using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rifle : Pistol
{
    public float delay;
    public float delayTimer;
    bool fired;

    public override void Update()
    {
        base.Update();
        if (fired && Time.time >= delay + delayTimer)
        {
            GameObject b = Instantiate(Projectile, BSpawn.transform.position, transform.rotation);
            Destroy(b, 2f);
            shot.Play();
            fired = false;
        }
    }

    public override void Fire()
    {
        shot.Play();
        Bullet bullet = Projectile.GetComponent<Bullet>();

        bullet.Damage = gunDamage;

        fired = true;
        delayTimer = Time.time;
        GameObject a = Instantiate(Projectile, BSpawn.transform.position, transform.rotation);
        Destroy(a, 2f);
        
    }
}
