using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class SubmarineController : MonoBehaviour
{
    // Currently in test state 

    private float movementDir = 1;

    void Start()
    {
        StartCoroutine(ChangeDir());
    }

    private void FixedUpdate()
    {
        transform.Translate(new Vector2(0, movementDir * Time.deltaTime));
        transform.Translate(new Vector2(movementDir * Time.deltaTime , 0));
    }

    IEnumerator ChangeDir()
    {
        while (true)
        {
            yield return new WaitForSeconds(4f);
            movementDir *= -1;
        }
    }
}
