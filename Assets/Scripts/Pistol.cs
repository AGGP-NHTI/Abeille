using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pistol : MonoBehaviour
{
    public GameObject Projectile;
    public GameObject BSpawn;
    public float gunDamage;
    public AudioSource shot;

    // Update is called once per frame
    public virtual void Update()
    {
        
    }

    public virtual void Fire()
    {
        shot.Play();

        Bullet bullet = Projectile.GetComponent<Bullet>();

        gunDamage = 4;

        bullet.Damage = gunDamage;

        var b = Instantiate(Projectile, BSpawn.transform.position, transform.rotation);
        Destroy(b, 2f);

    }
}
