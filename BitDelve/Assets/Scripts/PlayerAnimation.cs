using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAnimation : MonoBehaviour
{

    private Animator _anim;
    // Start is called before the first frame update
    void Start()
    {
        _anim = GetComponentInChildren<Animator>();
    }

    public void Move(float move, bool grounded) 
    {
        if (grounded)
        {
            _anim.SetFloat("Move", Mathf.Abs(move));
        }
        else
        {
            _anim.SetFloat("Move", 0);
        }
    }
    public void Jump()
    {
        _anim.SetBool("Jumping", true);
    }
    public void Land()
    {
        _anim.SetBool("Jumping", false);
    }

    public void Shoot()
    {
        _anim.SetBool("Shooting", true);
    }
    public void StopShooting()
    {
        _anim.SetBool("Shooting", false);
    }


}
