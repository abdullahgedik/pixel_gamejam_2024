using System.Collections;
using System.Collections.Generic;
using System.Security;
using UnityEngine;

public class SubmarineMovement : MonoBehaviour
{
    [Header("Settings")]
    [SerializeField] private float maxSpeed = 5f;
    [SerializeField] private float incSpeed = 1.0f;

    private float horizontalSpeed = 0;
    private float verticalSpeed = 0;

    private void FixedUpdate()
    {
        transform.Translate(new Vector2(horizontalSpeed * Time.deltaTime, verticalSpeed * Time.deltaTime));
    }

    public void incHorizontalSpeed()
    {
        horizontalSpeed += incSpeed;
        if(horizontalSpeed >= maxSpeed)
            horizontalSpeed = maxSpeed;
    }
    public void decHorizontalSpeed()
    {
        horizontalSpeed -= incSpeed;
        if(horizontalSpeed <= -maxSpeed)
            horizontalSpeed = -maxSpeed;
    }
    public void incVerticalSpeed()
    {
        verticalSpeed += incSpeed;
        if(verticalSpeed >= maxSpeed)
            verticalSpeed = maxSpeed;
    }
    public void decVerticalSpeed()
    {
        verticalSpeed -= incSpeed;
        if(verticalSpeed <= -maxSpeed)
            verticalSpeed = -maxSpeed;
    }
}
