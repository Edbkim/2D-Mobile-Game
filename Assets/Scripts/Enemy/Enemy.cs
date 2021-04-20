using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Enemy : MonoBehaviour
{
    [SerializeField]
    protected int health;
    [SerializeField]
    protected float speed;
    [SerializeField]
    protected int gems;

    protected bool isHit = false;
    protected bool isDead = false;

    [SerializeField]
    protected GameObject diamond;

    [SerializeField]
    protected Transform pointA, pointB;

    protected Vector3 currentTarget;
    protected Animator anim;
    protected SpriteRenderer spriteR;
    protected Player player;

    private void Start()
    {
        Init();
    }

    public virtual void Init()
    {
        anim = GetComponentInChildren<Animator>();
        spriteR = GetComponentInChildren<SpriteRenderer>();
        player = GameObject.FindGameObjectWithTag("Player").GetComponent<Player>();
    }

    public virtual void Movement()
    {
        if (currentTarget == pointA.position)
        {
            spriteR.flipX = false;
        }
        else if (currentTarget == pointB.position)
        {
            spriteR.flipX = true;
        }


        if (transform.position == pointA.position)
        {
            currentTarget = pointB.position;
            anim.SetTrigger("Idle");

        }
        else if (transform.position == pointB.position)
        {
            currentTarget = pointA.position;
            anim.SetTrigger("Idle");
        }

        if (isHit == false)
        {
            transform.position = Vector3.MoveTowards(transform.position, currentTarget, speed * Time.deltaTime);
        }
        else if (isHit == true)
        {

           float distance = Vector3.Distance(transform.position, player.transform.position);

            //Debug.Log("Distance = " + distance);

            if (distance > 2.0f)
            {
                isHit = false;
                anim.SetBool("InCombat", false);
                
            }
        }

        if (anim.GetBool("InCombat") == true)
        {
            Vector3 direction = player.transform.localPosition - transform.localPosition;

            if (direction.x >= 0)
            {
                spriteR.flipX = false;
            }
            else if (direction.x < 0)
            {
                spriteR.flipX = true;
            }

        }

    }

    public virtual void Update()
    {
        if (this.anim.GetCurrentAnimatorStateInfo(0).IsName("Idle") && anim.GetBool("InCombat") == false)
        {
            return;
        }
        if (isDead == false)
        {
            Movement();
        }
        
    }


}
