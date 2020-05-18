using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TakesDamage : MonoBehaviour
{
    public int hP = 3;
    public void TakeDamage()
    {
        hP--;
        if(hP <= 0)
        {
            Destroy(gameObject);
        }
    }
}
