using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityStandardAssets.CrossPlatformInput;

public class Player : MonoBehaviour, IDamageable
{

    //variable for jumpForce
    [SerializeField]
    private float _jumpForce = 1;
    [SerializeField]
    private float _speed = 3f;

    public int Health { get; set; }
    public int diamond;


    private bool _grounded = false;
    private bool _resetJump = false;

    private Vector2 _velocity;

    private PlayerAnimation _pA;
    private Rigidbody2D _rb;
    private SpriteRenderer _sR;
    private SpriteRenderer _swordArc;

   

    // Start is called before the first frame update
    void Start()
    {
        _rb = GetComponent<Rigidbody2D>();
        _pA = GetComponent<PlayerAnimation>();
        _sR = GetComponentInChildren<SpriteRenderer>();
        _swordArc = transform.GetChild(1).GetComponent<SpriteRenderer>();

        Health = 4;
    }

    // Update is called once per frame
    void Update()
    {
        if (Health >= 1)
        {
            Movement();
            Attack();
        }
        else
        {
            return;
        }


    }

    private void Movement()
    {
        float h = CrossPlatformInputManager.GetAxis("Horizontal"); // Input.GetAxisRaw("Horizontal");
        _grounded = IsGrounded();


        if (h > 0)
        {
            Flip(true);
        }
        else if (h < 0)
        {
            Flip(false);
        }


        _rb.velocity = new Vector2(h * _speed, _rb.velocity.y);

        _pA.Move(Mathf.Abs(_rb.velocity.x));

        if (CrossPlatformInputManager.GetButtonDown("B_Button") || Input.GetKeyDown(KeyCode.Space) && IsGrounded() == true)
        {
            Debug.Log("Jump");
            _rb.velocity = new Vector2(_rb.velocity.x, _jumpForce);
            StartCoroutine(ResetJump());
            _pA.Jump(true);
        }
    }

    private void Attack()
    {
        if (CrossPlatformInputManager.GetButtonDown("A_Button") && _grounded == true)
        {
            _pA.Attack();
        }
    }

    bool IsGrounded()
    {
        RaycastHit2D hitInfo = Physics2D.Raycast(transform.position, Vector2.down, 1f, 1 << 8);

        Debug.DrawRay(transform.position, Vector3.down, Color.blue);
        if (hitInfo.collider != null)
        {
            if (_resetJump == false)
            {
                _pA.Jump(false);
                return true;
            }
        }

            return false;
        
    }

    IEnumerator ResetJump()
    {
        _resetJump = true;
        yield return new WaitForSeconds(0.1f);
        _resetJump = false;
    }

    void Flip(bool faceRight)
    {

        if (faceRight == true)
        {
            _sR.flipX = false;
            _swordArc.flipX = false;
            _swordArc.flipY = false;

            Vector3 newPos = _swordArc.transform.localPosition;
            newPos.x = 1.01f;
            _swordArc.transform.localPosition = newPos;
        }
        else if (faceRight == false)
        {
            _sR.flipX = true;
            _swordArc.flipX = true;
            _swordArc.flipY = true;

            Vector3 newPos = _swordArc.transform.localPosition;
            newPos.x = -1.01f;
            _swordArc.transform.localPosition = newPos;
        }

    }

    public void Damage()
    {
        Debug.Log("Player Damage()");
        //remove 1 health
        //update UI display
        //check for dead
        //play death animation

        if (Health < 1)
        {
            return;
        }

        Health--;
        UIManager.Instance.UpdateLives(Health);

        if (Health < 1)
        {
            _pA.Death();
        }


    }

    public void AddGems(int amount)
    {
        diamond += amount;
        UIManager.Instance.UpdateGemCount(diamond);
    }


}
