using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyFollow : MonoBehaviour
{
    [Header("Settings")]
    [SerializeField] private float speed;
    [SerializeField] private float rotationSpeed;

    private Rigidbody2D rb;
    private PlayerAwarness playerAwarness;
    private Vector2 targetDirection;

    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        playerAwarness = GetComponent<PlayerAwarness>();

    }
    private void FixedUpdate()
    {
        UpdateTargetDirection();
        RotateTowardsTarget();
        setVelocity();
    }
    private void UpdateTargetDirection()
    {
        if (playerAwarness.AwareOfPlayer)
        {
            targetDirection = playerAwarness.DirectionToPlayer;
        }
        else
        {
            targetDirection = Vector2.zero;
        }
    }
    private void RotateTowardsTarget()
    {
        if (targetDirection == Vector2.zero)
        {
            return;
        }
        Quaternion targetRotation = Quaternion.LookRotation(transform.forward, targetDirection);
        Quaternion rotation = Quaternion.RotateTowards(transform.rotation, targetRotation, rotationSpeed * Time.deltaTime);
        rb.SetRotation(rotation);

    }
    private void setVelocity()
    {
        if (targetDirection == Vector2.zero)
        {
            rb.velocity = Vector2.zero;
        }
        else
        {
            rb.velocity = transform.up * speed;
        }
    }
}
