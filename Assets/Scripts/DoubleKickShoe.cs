using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoubleKickShoe : ShoeBase
{
    bool doublekick;
    bool kicking;
    public Foot foot;
    float baseknockback;

    protected override void Start()
    {
        baseknockback = foot.Knockback;
    }

    public override void Kick()
    {
        kicktimer = Time.time;
        kick = true;
        doublekick = true;
    }

    public override void Kicking()
    {
        if (kick)
        {
            //foot.Knockback = 0 - foot.Knockback;
            kickspawn.SetActive(true);
            foot2.transform.position = kickspawn.transform.position;
        }

        if (kick && (Time.time >= kicktimer + kickdelay))
        {
            foot2.transform.position = footHolder.transform.position;
            kick = false;
            kicktimer = Time.time;
        }

        //foot.Knockback = baseknockback;

        if (doublekick && !kicking && !kick && Time.time >= kicktimer + kickdelay)
        {
            kickspawn.SetActive(true);
            kicking = true;
            foot2.transform.position = kickspawn.transform.position;
            kicktimer = Time.time;
        }
        
        if ((doublekick && !kick) && Time.time >= kicktimer + kickdelay)
        {
            kicking = false;
            foot2.transform.position = footHolder.transform.position;
            doublekick = false;
        }


        if (!doublekick)
        {
            kickspawn.SetActive(false);
        }
    }
}
