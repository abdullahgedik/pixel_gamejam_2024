using System.Collections;
using System.Collections.Generic;
using Unity.Mathematics;
using UnityEngine;

public class TorpedoFire : MonoBehaviour
{
    [Header("References")]
    [SerializeField] private Transform firePoint;
    [SerializeField] private Transform projectileParent;
    [SerializeField] private GameObject torpedoProjectilePrefab;

    [Header("Torpedo Fire Settings")]
    [SerializeField] private float fireForce;
    [SerializeField] private float cooldown;

    private float nextTimeToFire;
    private float fireTime;

    private GameObject torpedo;

    private void Start()
    {
        nextTimeToFire = cooldown;
        fireTime = nextTimeToFire;
    }

    private void Update()
    {
        fireTime += Time.deltaTime;
    }

    public void Fire()
    {
        if (fireTime >= nextTimeToFire)
        {
            //Create Projectile and Add Force
            torpedo = Instantiate(torpedoProjectilePrefab, firePoint.position, firePoint.rotation);
            torpedo.GetComponent<Rigidbody2D>().AddForce(firePoint.right * -fireForce, ForceMode2D.Impulse);
            torpedo.transform.parent = projectileParent;
            Destroy(torpedo, 4f);

            //Reset Cooldown
            fireTime = 0;
        }
    }
}
