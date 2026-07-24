using UnityEngine;

public class SoundHandler : MonoBehaviour
{
    public AudioSource mainLoop;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        mainLoop.Play();
    }
}
