using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoubleKickShoe : ShoeBase
{
    public bool doublekick;
    public override void Kick()
    {
        if (Input.GetButtonDown("Fire2") && (kick == false && doublekick == false))
        {
            kicktimer = Time.time;
            kick = true;
            doublekick = true;
        }




        if (kick)
        {
            kickspawn.SetActive(true);
            foot2.transform.position = kickspawn.transform.position;
        }
        if (kick && Time.time >= kicktimer + kickdelay)
        {
            foot2.transform.position = footHolder.transform.position;
            kick = false;
            kicktimer = Time.time;
        }



        if (doublekick && !kick && Time.time >= kicktimer + kickdelay)
        {
            kickspawn.SetActive(true);
            foot2.transform.position = kickspawn.transform.position;
        }
        if ((doublekick && !kick) && Time.time >= kicktimer + kickdelay)
        {
            foot2.transform.position = footHolder.transform.position;
            doublekick = false;
        }






        if (!doublekick)
        {
            kickspawn.SetActive(false);
        }
    }
}
