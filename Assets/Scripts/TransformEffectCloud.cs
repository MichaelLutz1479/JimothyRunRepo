using UnityEngine;

public class TransformEffectCloud : MonoBehaviour
{
    public Sprite LandFrame1;
    public Sprite LandFrame2;
    public Sprite LandFrame3;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
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
