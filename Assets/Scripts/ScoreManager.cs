using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;  // Required for using TextMeshPro

public class ScoreManager : MonoBehaviour
{
    public TextMeshProUGUI scoreText;  // Reference to the TextMeshProUGUI component
    private int score = 0;  // Initial score

    // Method to add score when a can is hit
    public void AddScore(int points)
    {
        score += points;  // Increase the score
        UpdateScoreText(); // Update the UI
    }

    // Method to update the score text on the UI
    private void UpdateScoreText()
    {
        scoreText.text = "Score: " + score.ToString();
    }
}
