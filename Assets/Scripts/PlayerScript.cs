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

    //Q, E
    public void TransfromAction(InputAction.CallbackContext context)
    {
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

    private void OnCollisionEnter2D(Collision2D collision)
    {
        OnGround = true;
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        OnGround = false;
    }


}
