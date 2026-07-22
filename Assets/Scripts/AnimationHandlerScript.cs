using Unity.VisualScripting;
using UnityEngine;

public class AnimationHandlerScript : MonoBehaviour
{
    public GameObject Jimothy;
    public Sprite JimothyHumanFall;
    public Sprite JimothyHumanRun1;
    public Sprite JimothyHumanRun2;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        Application.targetFrameRate = 60;
    }
    //true means human, false is raccoon, bool quicker than string lmao
    public bool JimothyForm = true;
    public int AnimationFrameCount = 0;
    public int RunAnimationSpeed = 60;
    // Update is called once per frame
    void Update()
    {
        if (JimothyForm == true)
        {
            if (Jimothy.GetComponent<PlayerScript>().OnGround == false)
            {
                Jimothy.GetComponent<SpriteRenderer>().sprite = JimothyHumanFall;
            }
            else
            {
                AnimationFrameCount++;
                if (AnimationFrameCount == (RunAnimationSpeed / 2))
                {
                    Jimothy.GetComponent<SpriteRenderer>().sprite = JimothyHumanRun1;
                }
                if (AnimationFrameCount == RunAnimationSpeed)
                {
                    Jimothy.GetComponent<SpriteRenderer>().sprite= JimothyHumanRun2;
                    AnimationFrameCount = 0;
                }
            }
        }
    }
}
