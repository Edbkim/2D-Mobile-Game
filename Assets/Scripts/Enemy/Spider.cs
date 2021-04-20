using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spider : Enemy, IDamageable
{
    public int Health { get; set; }

    [SerializeField]
    private GameObject _acid;

    //use this for initialization
    public override void Init()
    {
        base.Init();

        Health = base.health;
    }

    public override void Update()
    {
        
    }

    public void Damage()
    {

        if (isDead == true)
        {
            return;
        }

        Health--;
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

    public override void Movement()
    {
        //sit still
    }

    public void Attack()
    {
        //instantiate acid effect
        Instantiate(_acid, transform.position, Quaternion.identity);
    }
}
