using UnityEngine;
using UnityEngine.SceneManagement;

public class StartMenu : MonoBehaviour
{
    public AudioSource menuSelect;

    public AudioSource menuHover;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void MouseHover()
    {
        menuHover.Play();
    }

<<<<<<< Updated upstream
=======
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

>>>>>>> Stashed changes
    public void StartTheGame()
    {
        SceneManager.LoadScene("JimothyRun");
        menuSelect.Play();
    }

    public void Tutorial()
    {
        SceneManager.LoadScene("TutorialScence");
        menuSelect.Play();
    }

    public void QuitTheGame()
    {
        Application.Quit();
        menuSelect.Play();
    }

    public void Restart()
    {
        SceneManager.LoadScene("JimothyRun");
    }

    public void StartScene()
    {
        SceneManager.LoadScene("StartScene");
    }
}
