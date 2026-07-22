using UnityEngine;
using UnityEngine.InputSystem;

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
