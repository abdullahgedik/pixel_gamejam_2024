using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class SubmarineController : MonoBehaviour
{
    [Header("References")]
    [SerializeField] private GameObject submarine;

    [Header("Input Settings")]
    [SerializeField] private KeyCode mLeft = KeyCode.A;  //Left
    [SerializeField] private KeyCode mRight = KeyCode.D; //Right
    [SerializeField] private KeyCode mUp = KeyCode.W;    //Upward
    [SerializeField] private KeyCode mDown = KeyCode.S;  //Downward


    private bool utilityActive = false;
    private SubmarineMovement subMov;

    private void Start()
    {
        subMov = submarine.GetComponent<SubmarineMovement>();
    }

    private void Update()
    {
        if(utilityActive)
        {
            //Change Speed of Submarine
            if (Input.GetKeyDown(mLeft))
            {
                subMov.decHorizontalSpeed();
            }
            if (Input.GetKeyDown(mRight))
            {
                subMov.incHorizontalSpeed();
            }
            if (Input.GetKeyDown(mUp))
            {
                subMov.incVerticalSpeed();
            }
            if (Input.GetKeyDown(mDown))
            {
                subMov.decVerticalSpeed();
            }
        }
    }

    public void SetUtilityActive(bool var)
    {
        utilityActive = var;
    }
}
