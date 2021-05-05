using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pistol : MonoBehaviour
{
    public GameObject Projectile;
    public GameObject BSpawn;
    public float gunDamage = 4;
    protected float firetimer;
    public float firedelay;
    public AudioSource shot;

    // Update is called once per frame
    public virtual void Update()
    {
        
    }

    public virtual void Fire()
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
