using UnityEngine;

public class SoundHandlerGame : MonoBehaviour
{

    public AudioSource mainGameLoop;


    void Awake()
    {
        DontDestroyOnLoad(this);
        mainGameLoop.Play();
    }

}
