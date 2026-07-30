using UnityEngine;
using UnityEngine.SceneManagement;

public class StartMenu : MonoBehaviour
{
    public AudioSource menuSelect;

    public AudioSource menuHover;

    public AudioSource mainMenuLoop;

    // Start is called once before the first execution of Update after the MonoBehaviour is created

    void Awake()
    {
        mainMenuLoop.Play();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void MouseHover()
    {
        menuHover.Play();
    }


    public void Back()
    {
        menuSelect.Play();
        SceneManager.LoadScene("StartScene");
    }

    public void Credits()
    {
        menuSelect.Play();
        SceneManager.LoadScene("Credits");
    }

    public void StartTheGame()
    {
        mainMenuLoop.Stop();
        menuSelect.Play();
        SceneManager.LoadScene("JimothyRun");
    }

    public void Tutorial()
    {
        menuSelect.Play();
        SceneManager.LoadScene("TutorialScence");
    }

    public void QuitTheGame()
    {
        menuSelect.Play();
        Application.Quit();
    }

    public void Restart()
    {
        mainMenuLoop.Stop();
        SceneManager.LoadScene("JimothyRun");
    }

    public void StartScene()
    {
        SceneManager.LoadScene("StartScene");
    }
}
