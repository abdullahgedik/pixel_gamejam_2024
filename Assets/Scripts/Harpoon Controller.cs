using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HarpoonController : MonoBehaviour
{
    [Header("References")]
    [SerializeField] private GameObject harpoonGun;

    [Header("Input Settings")]
    [SerializeField] private KeyCode hLeft = KeyCode.A;
    [SerializeField] private KeyCode hRight = KeyCode.D;
    [SerializeField] private KeyCode hFirePull = KeyCode.Space;

    private HarpoonShoot harpoonShoot;
    private bool utilityActive = false;

    private void Start()
    {
        harpoonShoot = harpoonGun.GetComponent<HarpoonShoot>();
    }

    private void Update()
    {
        if (utilityActive)
        {
            if(Input.GetKey(hLeft))
            {
                //Rotate Left
            }
            if (Input.GetKey(hRight))
            {
                //Rotate Right
            }
            if (Input.GetKey(hFirePull))
            {
                // Fire or Pull Harpoon
            }
        }
    }

    public void SetUtilityActive(bool var)
    {
        utilityActive = var;
    }
}
