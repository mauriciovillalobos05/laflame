using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;
using UnityEngine.UI;

public class PlayerHealth : MonoBehaviour
{
    public int maxHealth = 5;
    private int currentHealth;
    private TextMeshProUGUI healthText;
    public GameObject gameOverPanel;

    void Start()
    {
        currentHealth = maxHealth;
        healthText = GameObject.Find("HealthText").GetComponent<TextMeshProUGUI>();
        gameOverPanel = GameObject.Find("GameOverPanel");
        gameOverPanel.SetActive(false);
        UpdateHealthUI();
    }

    public void TakeDamage(int damage)
    {
        currentHealth -= damage;
        UpdateHealthUI();

        if (currentHealth <= 0)
        {
            Die();
        }
    }

    void UpdateHealthUI()
    {
        if (healthText != null)
        {
            healthText.text = "Health: " + currentHealth;
        }
    }

    void Die()
    {
        Debug.Log("Game Over!");
        Time.timeScale = 0f; // Pause the game
        gameOverPanel.SetActive(true);

        ScoreManager.Instance.ResetScore();
    }
}
