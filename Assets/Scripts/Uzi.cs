using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Uzi : MonoBehaviour
{
    public GameObject Bullet;
    public GameObject BSpawn;
    public float firedelay;
    float firetimer;

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
        var b = Instantiate(Bullet, BSpawn.transform.position, transform.rotation);
        Destroy(b, 2f);
    }
}
