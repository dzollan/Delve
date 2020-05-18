using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Experimental.Rendering.Universal;
using UnityEngine.UIElements;

public class PlayerMovement : MonoBehaviour
{

    private Rigidbody2D _rigid;
    private PlayerAnimation _anim;
    private Weapon _weapon;
    private SpriteRenderer _sprite;
    private Light2D _flashLight;
    private Transform _lightTF;
    private bool _jumpReady = true;
    private bool _shootReady = true;

    [SerializeField]
    private float _jumpForce = 9.0f;
    [SerializeField]
    private bool _grounded = false;
    [SerializeField]
    private float _playerSpeed = 10.0f;
    // Start is called before the first frame update
    void Start()
    {
        _rigid = GetComponent<Rigidbody2D>();
        _anim = GetComponent<PlayerAnimation>();
        _sprite = GetComponent<SpriteRenderer>();
        _flashLight = GetComponentInChildren<Light2D>();
        _lightTF = _flashLight.gameObject.transform;
        _weapon = GetComponent<Weapon>();
    }

    // Update is called once per frame
    void Update()
    {
        //
        float horizontalInput = Input.GetAxisRaw("Horizontal");

        if (horizontalInput > 0 && _sprite.flipX)
        {
            _sprite.flipX = false;
            _lightTF.eulerAngles = Vector3.forward * 230;
            
        }
        else if(horizontalInput < 0 && !_sprite.flipX)
        {
            _sprite.flipX = true;
            _lightTF.eulerAngles = Vector3.forward * 130;
            

        }
        
        

        if (Input.GetKeyDown(KeyCode.Z) && _grounded == true && _jumpReady)
        {
            _rigid.velocity = new Vector2(_rigid.velocity.x, _jumpForce);
            _grounded = false;
            
            _anim.Jump();
            _anim.StopShooting();

            _jumpReady = false;
            StartCoroutine(JumpCooldown());
            
        }
        if (Input.GetKey(KeyCode.X) && _grounded && _shootReady)
        {
            _weapon.Shoot(_sprite.flipX);
            _anim.Shoot();
            _shootReady = false;
            StartCoroutine(ShootCooldown());
        }
        else if (!Input.GetKey(KeyCode.X) || !_grounded)
        {
                          _anim.StopShooting();
            
        }
        
        
        Vector3 leftFoot = transform.position + new Vector3(-.3f, 0);
        Vector3 rightFoot = transform.position + new Vector3(.3f, 0);


        RaycastHit2D leftInfo = Physics2D.Raycast(leftFoot, Vector2.down, 1.7f);
        RaycastHit2D rightInfo = Physics2D.Raycast(rightFoot, Vector2.down, 1.7f);



        if (leftInfo.collider != null || rightInfo.collider != null)
        {
            if (_jumpReady && _rigid.velocity.y < 0.1f)
            {
                _anim.Land();
                _grounded = true;

            }
        }
        else
        {
            _grounded = false;
        }


        _rigid.velocity = new Vector2(horizontalInput * _playerSpeed, _rigid.velocity.y);
        _anim.Move(horizontalInput, _grounded);

    }


    IEnumerator JumpCooldown()
    {
        yield return new WaitForSeconds(0.1f);
        _jumpReady = true;

    }
    IEnumerator ShootCooldown()
    {
        yield return new WaitForSeconds(0.2f);
        _shootReady = true;

    }
}
