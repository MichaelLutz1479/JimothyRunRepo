using UnityEngine;
using UnityEngine.SceneManagement;

public class LoseCondition : MonoBehaviour
{
    public static int FinalScore;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            int collectScore = Score.Instance.CurrentScore;
            int timeScore = SurvivalScore.Instance.CurrentScore;

            FinalScore = collectScore * timeScore;

            SceneManager.LoadScene("LoseScene");
        }
    }
}
