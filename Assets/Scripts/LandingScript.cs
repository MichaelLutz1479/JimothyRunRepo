using UnityEngine;

public class LandingScript : MonoBehaviour
{
    public Sprite LandFrame1;
    public Sprite LandFrame2;
    public Sprite LandFrame3;
    public GameObject Jimothy;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        GetComponent<Transform>().position = (Jimothy.GetComponent<Transform>().position);
        GetComponent<Transform>().Translate(new Vector3(0f,-1.5f));
        GetComponent<SpriteRenderer>().sprite = LandFrame1;
    }
    public int AnimSpeed = 30;
    public int FrameCount = 0;
    // Update is called once per frame
    void Update()
    {
        FrameCount++;
        if (FrameCount == AnimSpeed / 3)
        {
            GetComponent<SpriteRenderer>().sprite = LandFrame2;
        }
        if (FrameCount == 2 * AnimSpeed / 3)
        {
            GetComponent<SpriteRenderer>().sprite = LandFrame3;
        }
        if (FrameCount == AnimSpeed)
        {
            Destroy(gameObject);
        }

    }
}
