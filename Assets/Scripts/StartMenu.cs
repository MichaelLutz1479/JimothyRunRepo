using UnityEngine;
using UnityEngine.SceneManagement;

public class StartMenu : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void StartTheGame()
    {
        SceneManager.LoadScene("JimothyRun");
    }

    public void Tutorial()
    {
        SceneManager.LoadScene("TutorialScence");
    }

    public void QuitTheGame()
    {
        Application.Quit();
    }

    public void Restart()
    {
        SceneManager.LoadScene("JimothyRun");
    }
}
