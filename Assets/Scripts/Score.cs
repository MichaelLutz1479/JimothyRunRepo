using UnityEngine;
using TMPro;

public class Score : MonoBehaviour
{
    public static Score Instance;

    [SerializeField] private TextMeshProUGUI scoreText;

    private int score = 1;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        Instance = this;
        scoreText.text = "Score: " + score;
    }

    // Update is called once per frame
    public void AddScore()
    {
        score++;
        scoreText.text = "Score: " + score;
    }

    public int CurrentScore
    {
        get { return score; }
    }
}
