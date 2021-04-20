using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MossGiant : Enemy, IDamageable
{

    public int Health { get; set; }

    //Use for initialization
    public override void Init()
    {
        base.Init();
        Health = base.health;

    }

    public override void Movement()
    {
        base.Movement();

    }
    public void Damage()
    {

        if (isDead == true)
        {
            return;
        }

        Debug.Log("MossG Damage()");

        Health--;
        anim.SetTrigger("Hit");
        isHit = true;
        anim.SetBool("InCombat", true);

        Debug.Log("Health = " + Health);

        if (Health < 1)
        {
            isDead = true;
            anim.SetTrigger("Death");

            GameObject diaGO = Instantiate(diamond, transform.position, Quaternion.identity);
            Diamond diaScript = diaGO.GetComponent<Diamond>();
            if (diaScript != null)
            {
                diaScript.gems = base.gems;
            }
            
        }
    }

}
