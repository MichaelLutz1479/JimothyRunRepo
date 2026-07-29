using UnityEngine;

public class SoundHandler : MonoBehaviour
{
    public AudioSource mainLoop;

    private void Awake()
    {
        DontDestroyOnLoad(this);
        mainLoop.Play();
    }
}
