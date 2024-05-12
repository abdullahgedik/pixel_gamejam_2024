using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [Header("References")]
    [SerializeField] private Rigidbody2D rb;
    [SerializeField] private Transform groundCheck;
    [SerializeField] private LayerMask groundLayer;
    [SerializeField] private Transform interactPosition;
    [SerializeField] private LayerMask interactLayer;

    [Header("Settings")]
    [SerializeField] private float movementSpeed = 6;
    [SerializeField] private float jumpingForce = 12;

    private float horizontalInput;
    private bool isUsingUtility = false;
    private bool isFacingRight = true;

    private void Update()
    {
        horizontalInput = Input.GetAxisRaw("Horizontal");

        Jump();

        Flip();

        Interact();
    }

    private void FixedUpdate()
    {
        if (!isUsingUtility)
            rb.velocity = new Vector2(horizontalInput * movementSpeed, rb.velocity.y);
        else
            rb.velocity = new Vector2(0, rb.velocity.y);
    }

    private bool IsGrounded()
    {
        return Physics2D.OverlapCircle(groundCheck.position, .3f, groundLayer);
    }

    private void Jump()
    {
        if (!isUsingUtility)
        {
            if (Input.GetButtonDown("Jump") && IsGrounded())
            {
                rb.velocity = new Vector2(rb.velocity.x, jumpingForce);
            }
            if (Input.GetButtonUp("Jump") && rb.velocity.y > 0f)
            {
                rb.velocity = new Vector2(rb.velocity.x, rb.velocity.y * 0.6f);
            }
        }
    }

    private void Flip()
    {
        if (isFacingRight && horizontalInput < 0f || !isFacingRight && horizontalInput > 0f)
        {
            isFacingRight = !isFacingRight;
            Vector3 localScale = transform.localScale;
            localScale.x *= -1f;
            transform.localScale = localScale;
        }
    }

    private void Interact()
    {
        if(Input.GetKeyDown(KeyCode.E) && Physics2D.OverlapCircle(interactPosition.position, .2f, interactLayer))
        {
            //Gun Controller
            if(Physics2D.OverlapCircle(interactPosition.position, .2f, interactLayer).GetComponent<GunController>() != null)
            {
                Physics2D.OverlapCircle(interactPosition.position, .2f, interactLayer).GetComponent<GunController>().UsingUtilityActive();
                UsingUtilityTrue();
            }

            //Submarine Controller
            if (Physics2D.OverlapCircle(interactPosition.position, .2f, interactLayer).GetComponent<SubmarineController>() != null)
            {
                Physics2D.OverlapCircle(interactPosition.position, .2f, interactLayer).GetComponent<SubmarineController>().UsingUtilityActive();
                UsingUtilityTrue();
            }
        }
    }

    private void OnDrawGizmos()
    {
        Gizmos.DrawWireSphere(interactPosition.position, .2f);
    }

    //Utility True/False
    public void UsingUtilityTrue()
    {
        isUsingUtility = true;
    }
    public void UsingUtilityFalse()
    {
        isUsingUtility = false;
    }
}
