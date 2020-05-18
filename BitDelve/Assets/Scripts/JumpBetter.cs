using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JumpBetter : MonoBehaviour
{

    public float gravMultiplier = 1.5f;
    Rigidbody2D _rb;
    // Start is called before the first frame update
    void Awake()
    {
        _rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        if (_rb.velocity.y < 0)
        {
            _rb.velocity += Vector2.up * Physics2D.gravity.y * gravMultiplier * Time.deltaTime;
        }
        else if (_rb.velocity.y > 0 && !Input.GetKey(KeyCode.Z))
        {
            _rb.velocity += Vector2.up * Physics2D.gravity.y * Time.deltaTime;
        }
    }
}
