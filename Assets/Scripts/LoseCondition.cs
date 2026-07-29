using UnityEngine;
using UnityEngine.SceneManagement;

public class LoseCondition : MonoBehaviour
{

    public AudioSource die;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            die.Play();
            SceneManager.LoadScene("LoseScene");
        }
    }
}
