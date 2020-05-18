using System.Collections;
using System.Collections.Generic;
using Unity.Mathematics;
using UnityEngine;

public class Weapon : MonoBehaviour
{
    public Transform firePoint;
    public GameObject bulletPrefab;

    // Update is called once per frame
    public void Shoot(bool xFlipped)
    {
        if (xFlipped) {
            firePoint.rotation = Quaternion.Euler(0f, 180f, 0f);
            firePoint.localPosition = new Vector3(-1f, .2f, 0f);
        }
        else
        {
            firePoint.rotation = Quaternion.Euler(0f, 0f, 0f);
            firePoint.localPosition = new Vector3(1f, .2f, 0f);


        }
        Instantiate(bulletPrefab, firePoint.position, firePoint.rotation);
    }
}
