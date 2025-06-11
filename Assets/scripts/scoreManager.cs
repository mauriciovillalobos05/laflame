using UnityEngine;
using TMPro;

public class ScoreManager : MonoBehaviour
{
    public static ScoreManager Instance;

    private int score = 0;
    public TextMeshProUGUI scoreText;

    void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }
        else
        {
            Destroy(gameObject);
        }
    }

    void Start()
    {
        score = 0;
        UpdateScoreUI();
    }

    public void AddPoint(int points)
    {
        score += points;
        UpdateScoreUI();
    }

    public void ResetScore()
    {
        score = 0;
        UpdateScoreUI();
    }

    void UpdateScoreUI()
    {
        if (scoreText != null)
            scoreText.text = "Score: " + score;
    }

    public int GetScore()
    {
        return score;
    }
}
