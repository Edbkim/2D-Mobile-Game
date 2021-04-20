using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AcidEffect : MonoBehaviour
{
    private float _speed = 3f;

    private void Start()
    {
        Destroy(this.gameObject, 5f);
    }

    private void Update()
    {
        transform.Translate(Vector3.right * _speed * Time.deltaTime);

    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Player")
        {
            IDamageable hit = other.GetComponent <IDamageable>();

            if (hit != null)
            {
                hit.Damage();
                Destroy(this.gameObject);
            }
        }
    }



    //move left at 3m per second
    //detect player and deal damage (IDamagable interface)
    //Destroy this after 5 seconds




}
