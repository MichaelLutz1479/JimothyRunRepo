using System;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerScript : MonoBehaviour
{
    public bool transformed = false;
    public PolygonCollider2D humanCollider;
    public PolygonCollider2D raccoonCollider;
    public PolygonCollider2D crouchCollider;
    public Sprite CrouchSprite;
    public bool OnGround;
    public bool Crouched = false;
    public GameObject LandingCloud;
    public GameObject TransformEffect;

    public Transform humanGroundCheck;
    public Transform raccoonGroundCheck;
    public float groundCheckRadius = 0.15f;
    public LayerMask physicsObjectLayer;
    private bool firstGroundCheck = true;

    private bool wasGrounded;

    void FixedUpdate()
    {
        Transform currentGroundCheck = transformed ? raccoonGroundCheck : humanGroundCheck;

        wasGrounded = OnGround;

        OnGround = Physics2D.OverlapCircle(currentGroundCheck.position, groundCheckRadius, physicsObjectLayer);

        if (!wasGrounded && OnGround)
        {
            if (firstGroundCheck == true)
            {
                firstGroundCheck = false;
            }
            else
            {
                if (transformed == false)
                {
                    Instantiate(LandingCloud, transform.position + new Vector3(0f, -0.75f, 0f), Quaternion.identity);
                }
                else
                {
                    Instantiate(LandingCloud, transform.position, Quaternion.identity);
                }
            }

        }
    }

    private void OnDrawGizmosSelected()
    {
        if (humanGroundCheck != null)
        {
            Gizmos.color = Color.green;
            Gizmos.DrawWireSphere(humanGroundCheck.position, groundCheckRadius);
        }

        if (raccoonGroundCheck != null)
        {
            Gizmos.color = Color.blue;
            Gizmos.DrawWireSphere(raccoonGroundCheck.position, groundCheckRadius);
        }
    }

    //Q, E
    public void TransfromAction(InputAction.CallbackContext context)
    {
        Instantiate(TransformEffect, transform.position, Quaternion.identity);
        if (transformed == false)
        {
            transformed = true;
            humanCollider.enabled = false;
            raccoonCollider.enabled = true;
        }
        else if (transformed == true)
        {
            transformed = false;
            humanCollider.enabled = true;
            raccoonCollider.enabled = false;
        }
    }

    //W, Up arrow, Spacebar
    public void JumpAction(InputAction.CallbackContext context)
    {
        if (transformed == false && OnGround == true)
        {
            GetComponent<Rigidbody2D>().AddForce(new Vector2(0f, 200f));
        }
    }

    //S, Down Arrow
    public void CrouchAction(InputAction.CallbackContext context)
    {
        if (context.performed)
        {
            if (transformed == true)
            {
                GetComponent<SpriteRenderer>().sprite = CrouchSprite;
                Crouched = true;
                crouchCollider.enabled = true;
                raccoonCollider.enabled = false;
            }
        }

        if (context.canceled)
        {
            GetComponent<SpriteRenderer>().sprite = CrouchSprite;
            Crouched = false;
            crouchCollider.enabled = false;
            raccoonCollider.enabled = true;
        }

    }



    void Start()
        {
            GetComponent<Rigidbody2D>();
            OnGround = true;
            transformed = false;
        }
}
