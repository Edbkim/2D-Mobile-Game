using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpiderAnimationEvent : MonoBehaviour
{
    //handle to the spider
    private Spider _spider;
    

    private void Start()
    {
        // assign handle of spider
        _spider = GetComponentInParent<Spider>();
    }

    public void Fire()
    {
        //use handle to call attack method on spider
        _spider.Attack();
    }

}
