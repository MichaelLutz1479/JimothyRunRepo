using UnityEngine;

public class CactusScript : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        StartCactus();
    }

    public void StartCactus()
    {
        GetComponent<Transform>().position = (new Vector3(9,0.5f));
        GetComponent<Rigidbody2D>().AddForce(new Vector2(-350f, 0f));
    }

    // Update is called once per frame
    void Update()
    {
        if (GetComponent<Transform>().position.x == -9)
        {
            Destroy(gameObject);
        }
    }
}
