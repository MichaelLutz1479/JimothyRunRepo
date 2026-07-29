using UnityEngine;
using TMPro;

public class SurvivalScore : MonoBehaviour
{
    public static SurvivalScore Instance;

    [Header("UI Reference")]
    [SerializeField] private TextMeshProUGUI score;

    [Header("Settings")]
    [SerializeField] private float scoreMultiplier = 1.5f;

    private float elapsedTime = 0f;
    private bool isJimothyAlive = true;

    private void Awake()
    {
        Instance = this;
    }

    void Update()
    {
        if (isJimothyAlive)
        {

            elapsedTime += Time.deltaTime;


            int currentScore = Mathf.FloorToInt(elapsedTime * scoreMultiplier);


            score.text = "Score: " + currentScore.ToString();
        }
    }


    public void PlayerDied()
    {
        isJimothyAlive = false;
    }

    public int CurrentScore
    {
        get
        {
            return Mathf.FloorToInt(elapsedTime * scoreMultiplier);
        }
    }
}