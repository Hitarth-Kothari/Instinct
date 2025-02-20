using UnityEngine;
using TMPro;

/// <summary>
/// Tracks and displays the current score. 
/// Provides a global static instance for easy access.
/// </summary>
public class Score_Manager : MonoBehaviour
{
    [Header("UI Reference")]
    [Tooltip("Text object that displays the current score.")]
    [SerializeField] private TMP_Text scoreText;

    private static int score;

    /// <summary>
    /// Global access to the score manager.
    /// </summary>
    public static Score_Manager instance;

    private void Awake()
    {
        // Ensure only one instance is active
        instance = this;
        score = 0;
    }

    private void Start()
    {
        UpdateScoreText();
    }

    /// <summary>
    /// Increments the player's score by 1 and updates the UI.
    /// </summary>
    public void Add_Score()
    {
        score++;
        UpdateScoreText();
    }

    /// <summary>
    /// Returns the current score.
    /// </summary>
    public int Get_Score()
    {
        return score;
    }

    /// <summary>
    /// Reflects the current score value in the assigned TextMeshPro element.
    /// </summary>
    private void UpdateScoreText()
    {
        if (scoreText != null)
        {
            scoreText.text = score.ToString();
        }
    }
}
