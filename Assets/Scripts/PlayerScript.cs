using Unity.VisualScripting;
using UnityEngine;

public class PlayerScript : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
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
