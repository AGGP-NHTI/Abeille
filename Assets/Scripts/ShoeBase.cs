using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShoeBase : MonoBehaviour
{
    public GameObject foot1;
    public GameObject foot2;
    public Guy guy;
    public GameObject legs;
    public GameObject FeetRoot;
    public GameObject ShoeExample;

    public GameObject kickspawn;
    public GameObject footHolder;

    public bool kick;
    public float kickdelay;
    public float kicktimer;


    // Start is called before the first frame update
    protected virtual void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        Kicking();

        foot1 = guy.activeshoesL;
        foot2 = guy.activeshoesR;






        foot1.transform.rotation = Quaternion.Euler(0.0f, 0.0f, gameObject.transform.rotation.z * -1.0f);
        foot2.transform.rotation = Quaternion.Euler(0.0f, 0.0f, gameObject.transform.rotation.z * -1.0f);
    }

    public void Walk(GameObject feets,float direction)
    {
        feets.transform.Rotate(new Vector3 (0,0,2.5f * direction));
    }

    public virtual void Kick()
    {
        kicktimer = Time.time;
        kick = true;
    }

    public virtual void Kicking()
    {
        if (kick)
        {
            kickspawn.SetActive(true);
            foot2.transform.position = kickspawn.transform.position;
        }
        if (kick && Time.time >= kicktimer + kickdelay)
        {
            foot2.transform.position = footHolder.transform.position;
            kick = false;
        }
        if(!kick)
        {
            kickspawn.SetActive(false);
        }
    }
}
