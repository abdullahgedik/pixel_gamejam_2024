using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GunController : MonoBehaviour
{
    [Header("References")]
    [SerializeField] private GameObject gun;

    private bool utilityActive = false;

    private void Start()
    {

    }

    private void Update()
    {
        if (utilityActive)
        {

        }
    }

    public void SetUtilityActive(bool var)
    {
        utilityActive = var;
    }
}
