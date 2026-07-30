using UnityEngine;
using UnityEngine.SceneManagement;

public class LoseCondition : MonoBehaviour
{

    public AudioSource die;
    public static int FinalScore;

    public AudioSource mainGameLoop;

    private void Start()
    {
        mainGameLoop.Play();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            mainGameLoop.Stop();
            die.Play();
            int collectScore = Score.Instance.CurrentScore;
            int timeScore = SurvivalScore.Instance.CurrentScore;

            FinalScore = collectScore * timeScore;

            SceneManager.LoadScene("LoseScene");
        }
    }
}
