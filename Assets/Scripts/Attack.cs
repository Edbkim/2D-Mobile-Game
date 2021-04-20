using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Attack : MonoBehaviour
{
    //variable to determine if the damage function can be called
    private bool _hittable = true;

    private void OnTriggerEnter2D(Collider2D other)
    {
        Debug.Log("Hit: " + other.name);

        IDamageable hit = other.GetComponent<IDamageable>();

        if (hit != null)
        {
            if (_hittable == true)
            {
                hit.Damage();
                _hittable = false;
                StartCoroutine(DamageCooldown());
            }
        }
    }

    IEnumerator DamageCooldown()
    {
        yield return new WaitForSeconds(1f);
        _hittable = true;
    }
}
