using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GunShoot : MonoBehaviour
{
    [Header("References")]
    [SerializeField] private Transform firePoint;
    [SerializeField] private GameObject bulletPrefab;

    public void RotateRight()
    {
        transform.Rotate(new Vector3(0, 0, .75f), Space.Self);
    }
    public void RotateLeft()
    {
        transform.Rotate(new Vector3(0, 0, -.75f), Space.Self);
    }
    public void Fire()
    {
        Instantiate(bulletPrefab, firePoint.position, firePoint.rotation);
    }
}
