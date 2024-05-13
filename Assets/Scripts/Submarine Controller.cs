using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class SubmarineController : MonoBehaviour
{
    [Header("References")]
    [SerializeField] private GameObject submarine;
    [SerializeField] private PlayerController playerController;

    private bool UtilityActive = false;
    private SubmarineMovement subMov;

    private void Start()
    {
        subMov = submarine.GetComponent<SubmarineMovement>();
    }

    private void Update()
    {
        if(UtilityActive)
        {
            //Change Speed of Submarine
            if (Input.GetKeyDown(KeyCode.A))
            {
                subMov.decHorizontalSpeed();
            }
            if (Input.GetKeyDown(KeyCode.D))
            {
                subMov.incHorizontalSpeed();
            }
            if (Input.GetKeyDown(KeyCode.W))
            {
                subMov.incVerticalSpeed();
            }
            if (Input.GetKeyDown(KeyCode.S))
            {
                subMov.decVerticalSpeed();
            }
        }
    }

    public void SetUtilityActive(bool var)
    {
        UtilityActive = var;
    }
}
