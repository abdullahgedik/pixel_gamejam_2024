using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GunController : MonoBehaviour
{
    [Header("References")]
    [SerializeField] private PlayerController playerController;

    private bool UsingUtility = false;

    private void Start()
    {

    }

    private void Update()
    {
        if (UsingUtility)
        {

        }
    }

    public void SetUtilityActive(bool var)
    {
        UsingUtility = var;
    }
}
