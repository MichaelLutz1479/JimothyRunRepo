using UnityEngine;
using UnityEngine.SceneManagement;

public class LoseCondition : MonoBehaviour
{

    public AudioSource die;
    public static int FinalScore;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            die.Play();
            int collectScore = Score.Instance.CurrentScore;
            int timeScore = SurvivalScore.Instance.CurrentScore;

            FinalScore = collectScore * timeScore;

            SceneManager.LoadScene("LoseScene");
        }
    }
}
