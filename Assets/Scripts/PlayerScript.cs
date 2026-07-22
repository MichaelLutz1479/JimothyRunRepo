using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerScript : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    //ADD THIS TO THE SCRIPT OTHERWISE INPUT ACTION WILL NOT WORK


public class TransformScript : MonoBehaviour
{
    public bool onGround = false;

    bool transformed = false;


    /*
     Do not put the input actions in Update()
     I can set up the inspector stuff and keybinds, but if you try to run the game before I add those you will get errors, just ignore them.
     */

    //Z, F
    public void TransfromAction(InputAction.CallbackContext context)
    {
        if (transformed == false)
        {
            transformed = true;
        }
        else if (transformed == true)
        {
            transformed = false;
        }
    }

    //W, Up arrow, Spacebar
    public void JumpAction(InputAction.CallbackContext context)
    {
        if (transformed == false && onGround == true)
        {
            GetComponent<Rigidbody2D>().AddForce(new Vector2(0f, 350f));
        }
    }

    //S, Down Arrow
    public void CrouchAction(InputAction.CallbackContext context)
    {
        if (transformed == true)
        {

        }
    }

}

void Start()
    {
        GetComponent<Rigidbody2D>();
        OnGround = true;
    }

    // Update is called once per frame

    public bool OnGround;

    private void OnCollisionEnter2D(Collision2D collision)
    {
        OnGround = true;
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        OnGround = false;
    }

    void Update()
    {
        
        if (Input.GetKeyDown(KeyCode.W) == true)
        {
            if (OnGround == true)
            {
                GetComponent<Rigidbody2D>().AddForce(new Vector2(0f , 350f));
            }
        }
        
    }
}
