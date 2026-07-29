using UnityEngine;

public class SoundHandlerGame : MonoBehaviour
{

    public AudioSource mainGameLoop;


    void Awake()
    {
        DontDestroyOnLoad(this);
    }

    private void Start()
    {
        mainGameLoop.Play();
    }

}
