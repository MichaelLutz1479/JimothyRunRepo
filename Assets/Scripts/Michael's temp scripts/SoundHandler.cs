
using UnityEngine;
using UnityEngine.SceneManagement;

public class SoundHandler : MonoBehaviour
{
    public AudioSource mainMenuLoop;
    

    void Update()
    {
        if(SceneManager.GetActiveScene().name == "JimothyRun") 
        {
            mainMenuLoop.Stop();
        }
    }

    private void Awake()
    {
        DontDestroyOnLoad(this);
        mainMenuLoop.Play();
    }
}
