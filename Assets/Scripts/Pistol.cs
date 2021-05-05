using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pistol : MonoBehaviour
{
    public GameObject Projectile;
    public GameObject BSpawn;
    public float gunDamage = 4;
    float firetimer;
    public AudioSource shot;

    // Update is called once per frame
    public virtual void Update()
    {
        
    }

    public virtual void Fire()
    {
        shot.Play();

        Bullet bullet = Projectile.GetComponent<Bullet>();

        bullet.Damage = gunDamage;

        var b = Instantiate(Projectile, BSpawn.transform.position, transform.rotation);
        Destroy(b, 2f);

    }
}
