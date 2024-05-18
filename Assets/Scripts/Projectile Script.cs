using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProjectileScript : MonoBehaviour
{
    [Header("Damage Settings")]
    [SerializeField] private float damageAmount = 20f;

    [Header("Projectile Type")]
    [SerializeField] private bool isTorpedo = false;
    [SerializeField] private float torpedoExplosionRadius = 5f;

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(isTorpedo) //For torpedo
        {
            foreach (Collider2D entity in Physics2D.OverlapCircleAll(transform.position, torpedoExplosionRadius))
            {
                if (entity.GetComponent<Health>() != null)
                {
                    entity.GetComponent<Health>().TakeDamage(damageAmount);
                }
            }
            Destroy(this.gameObject);
        }
        else          //For bullet
        {
            if(collision.gameObject.GetComponent<Health>() != null)
            {
                collision.gameObject.GetComponent<Health>().TakeDamage(damageAmount);
            }
            Destroy(this.gameObject);
        }
    }

    private void OnDrawGizmos()
    {
        Gizmos.DrawWireSphere(transform.position, torpedoExplosionRadius);
    }
}
