using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Uzi : MonoBehaviour
{
    public GameObject Projectile;
    public GameObject BSpawn;
    public float firedelay;
    float firetimer;
    float gunDamage = 2;
    public AudioSource shot;

    // Update is called once per frame
    void Update()
    {
        if (Input.GetButton("Fire1") && Time.time >= firetimer + firedelay)
        {
            firetimer = Time.time;
            Fire();
        }
    }

    public void Fire()
    {
        shot.Play();

        Bullet bullet = Projectile.GetComponent<Bullet>();

        bullet.Damage = gunDamage;

        var b = Instantiate(Projectile, BSpawn.transform.position, transform.rotation);
        Destroy(b, 2f);
    }
}
