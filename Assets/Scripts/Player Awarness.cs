using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAwarness : MonoBehaviour
{
    public bool AwareOfPlayer { get; private set; }
    public Vector2 DirectionToPlayer { get; private set; }

    [SerializeField]
    private float playerAwarnessDistance;

    private Transform player;
    private Vector2 enemyToPlayerVector;

    private void Awake()
    {
        player = FindObjectOfType<SubmarineMovement>().transform;
    }
    void Update()
    {
        if (player != null)
            enemyToPlayerVector = player.position - transform.position;
        DirectionToPlayer = enemyToPlayerVector.normalized;

        if (enemyToPlayerVector.magnitude <= playerAwarnessDistance)
        {
            AwareOfPlayer = true;
        }
        else
        {
            AwareOfPlayer = false;
        }

    }
}
