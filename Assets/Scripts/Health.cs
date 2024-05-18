using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Health : MonoBehaviour
{
    [Header("Settings")]
    [SerializeField] private float healthPoint = 100f;

    public void TakeDamage(float amount)
    {
        healthPoint -= amount;
        if(healthPoint <= 0)
        {
            Die();
        }
    }

    private void Die()
    {
        Destroy(gameObject);
    }
}
