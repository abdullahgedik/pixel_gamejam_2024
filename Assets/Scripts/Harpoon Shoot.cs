using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HarpoonShoot : MonoBehaviour
{
    [Header("References")]
    [SerializeField] private Transform firePoint;
    [SerializeField] private GameObject harpoon;
    [SerializeField] private GameObject fakeHarpoon;

    [Header("Harpoon Gun Rotation Settings")]
    [SerializeField] private float rotationSpeed;
    [SerializeField] private float minRotation;
    [SerializeField] private float maxRotation;

    [Header("Harpoon Gun Shoot Settings")]
    [SerializeField] private float fireForce;
    [SerializeField] private float maxDistance;

    //Rotation
    private Vector3 currentRotation;
    private float harpoonGunRotation;

    private void Start()
    {
        currentRotation = transform.localEulerAngles;
        harpoonGunRotation = rotationSpeed * Time.deltaTime;
    }

    private void Update()
    {
        currentRotation.z = Mathf.Clamp(currentRotation.z, minRotation, maxRotation);

        transform.localEulerAngles = currentRotation;
    }

    public void RotateRight()
    {
        currentRotation.z += harpoonGunRotation;
    }
    public void RotateLeft()
    {
        currentRotation.z -= harpoonGunRotation;
    }

    public void ShootHarpoon()
    {

    }
}
