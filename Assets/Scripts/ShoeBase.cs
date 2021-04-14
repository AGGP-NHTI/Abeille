using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShoeBase : MonoBehaviour
{
    public GameObject foot1;
    public GameObject foot2;

    public GameObject kickspawn;
    public GameObject footHolder;

    bool kick;
    public float kickdelay;
    float kicktimer;


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Kick();








        foot1.transform.rotation = Quaternion.Euler(0.0f, 0.0f, gameObject.transform.rotation.z * -1.0f);
        foot2.transform.rotation = Quaternion.Euler(0.0f, 0.0f, gameObject.transform.rotation.z * -1.0f);
    }

    public void Walk(GameObject feets,float direction)
    {
        feets.transform.Rotate(new Vector3 (0,0,2.5f * direction));
    }

    public void Kick()
    {
        if (Input.GetButtonDown("Fire2") && kick == false)
        {
            kicktimer = Time.time;
            kick = true;
        }
        if (kick)
        {
            foot2.transform.position = kickspawn.transform.position;
        }
        if (kick && Time.time >= kicktimer + kickdelay)
        {
            foot2.transform.position = footHolder.transform.position;
            kick = false;
        }
    }
}
