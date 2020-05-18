using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class WalkToEdge : MonoBehaviour
{

    public bool walkingLeft = true;
    public Rigidbody2D _rb;
    public SpriteRenderer _sr;
    public float _crabSpeed = 3.0f;
    // Start is called before the first frame update
    void Start()
    {
        _rb = GetComponent<Rigidbody2D>();
        _sr = GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        Debug.DrawRay(transform.position, Vector3.down, Color.green);

        Vector3 leftFoot = transform.position + new Vector3(-.8f, 0);
        Vector3 rightFoot = transform.position + new Vector3(.8f, 0);
        Debug.DrawRay(leftFoot, Vector3.down, Color.green);
        Debug.DrawRay(rightFoot, Vector3.down, Color.green);

        if (walkingLeft)
        {
            _rb.velocity = new Vector2(-_crabSpeed, _rb.velocity.y);
            RaycastHit2D hitInfo = Physics2D.Raycast(leftFoot, Vector2.down, 1.7f);
            if(hitInfo.collider == null)
            {
                walkingLeft = false;
                _sr.flipX = true;
            }

        }
        else
        {
            _rb.velocity = new Vector2(_crabSpeed, _rb.velocity.y);
            RaycastHit2D hitInfo = Physics2D.Raycast(rightFoot, Vector2.down, 1.7f);
            if (hitInfo.collider == null)
            {
                walkingLeft = true;
                _sr.flipX = false;
            }
        }

    }
}
