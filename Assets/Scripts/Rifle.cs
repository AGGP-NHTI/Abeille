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
            GameObject b = Instantiate(Bullet, BSpawn.transform.position, transform.rotation);
            Destroy(b, 2f);
            fired = false;
        }
    }

    public override void Fire()
    {

        fired = true;
        delayTimer = Time.time;
        GameObject a = Instantiate(Bullet, BSpawn.transform.position, transform.rotation);
        Destroy(a, 2f);
    }
}
