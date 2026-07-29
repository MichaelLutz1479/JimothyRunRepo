using Unity.VisualScripting;
using UnityEngine;

public class AnimationHandlerScript : MonoBehaviour
{
    public GameObject Jimothy;
    public Sprite JimothyHumanFall;
    public Sprite JimothyHumanRun1;
    public Sprite JimothyHumanRun2;
    public Sprite JimothyRaccoonFall;
    public Sprite JimothyRaccoonCrouch;
    public Sprite JimothyRaccoonRun1;
    public Sprite JimothyRaccoonRun2;
    public Sprite JimothyRaccoonCrouch2;

    public AudioSource jimoCrawl1;
    public AudioSource jimoCrawl2;

    int randomInt = 1;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        Application.targetFrameRate = 60;
        JimothyForm = false;
    }
    //Sorry Oliver lowkey had to change how "JimothyForm" works to fix a bug. False means human now. ok np
    bool JimothyForm = false;
    public int AnimationFrameCount = 0;
    public int RunAnimationSpeed = 20;
    // Update is called once per frame

    void PlayEffect()
    {

        if (randomInt == 1)
        {
            jimoCrawl1.Play();
        }
        else if (randomInt == 2)
        {
            jimoCrawl2.Play();
        }

        randomInt++;

        if (randomInt == 3)
        {
            randomInt = 1;
        }
    }

    void Update()
    {
        JimothyForm = Jimothy.GetComponent<PlayerScript>().transformed;
        if (JimothyForm == false)
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
        else if (JimothyForm == true)
        {
            if (Jimothy.GetComponent<PlayerScript>().OnGround == false)
            {
                Jimothy.GetComponent<SpriteRenderer>().sprite = JimothyRaccoonFall;
            }
            else if (Jimothy.GetComponent<PlayerScript>().Crouched == true)
            {
                AnimationFrameCount++;
                if (AnimationFrameCount == (RunAnimationSpeed / 2))
                {
                    Jimothy.GetComponent<SpriteRenderer>().sprite = JimothyRaccoonCrouch;
                }
                if (AnimationFrameCount == RunAnimationSpeed)
                {
                    Jimothy.GetComponent<SpriteRenderer>().sprite = JimothyRaccoonCrouch2;
                    AnimationFrameCount = 0;
                }
            }
            else
            {
                AnimationFrameCount++;
                if (AnimationFrameCount == (RunAnimationSpeed / 2))
                {
                    Jimothy.GetComponent<SpriteRenderer>().sprite = JimothyRaccoonRun1;
                    PlayEffect();
                }
                if (AnimationFrameCount == RunAnimationSpeed)
                {
                    Jimothy.GetComponent<SpriteRenderer>().sprite = JimothyRaccoonRun2;
                    PlayEffect();
                    AnimationFrameCount = 0;
                }
            }
        }
    }
}
