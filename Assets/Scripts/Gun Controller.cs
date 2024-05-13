using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GunController : MonoBehaviour
{
    [Header("References")]
    [SerializeField] private GameObject gun;

    [Header("Input Settings")]
    [SerializeField] private KeyCode rLeft = KeyCode.A;
    [SerializeField] private KeyCode rRight = KeyCode.D;
    [SerializeField] private KeyCode Fire = KeyCode.Space;

    private GunShoot gunShoot;
    private bool utilityActive = false;

    private void Start()
    {
        gunShoot = gun.GetComponent<GunShoot>();
    }

    private void Update()
    {
        if (utilityActive)
        {
            if(Input.GetKey(rLeft))
            {
                gunShoot.RotateRight();
            }
            if (Input.GetKey(rRight))
            {
                gunShoot.RotateLeft();
            }
            if (Input.GetKeyDown(Fire))
            {
                Debug.Log("Fire!");
            }
        }
    }

    public void SetUtilityActive(bool var)
    {
        utilityActive = var;
    }
}
