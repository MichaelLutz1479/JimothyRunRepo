using UnityEngine;
using TMPro;

public class FinalScoreDisplay : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI finalScoreText;

    private void Start()
    {
        finalScoreText.text = "Final Score: " + LoseCondition.FinalScore;
    }
}