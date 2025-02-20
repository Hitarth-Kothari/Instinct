using UnityEngine;
using TMPro;

/// <summary>
/// Manages the final score display and updates high score if applicable.
/// </summary>
public class Final_score_manager : MonoBehaviour
{
    [Header("Score UI References")]
    [Tooltip("Text for displaying current final score.")]
    public TMP_Text finalScoreText;

    [Tooltip("Text for displaying high score.")]
    public TMP_Text highScoreText;

    // Static highscore value used by PlayerPrefs
    private static int highscore;

    private void Start()
    {
        // Load stored highscore (default 0 if not set)
        highscore = PlayerPrefs.GetInt("highscore", 0);

        // Current session score
        int currentScore = PlayerPrefs.GetInt("score", 0);
        finalScoreText.text = currentScore.ToString();

        // If our current score beats stored highscore, update it
        if (currentScore > highscore)
        {
            highscore = currentScore;
            PlayerPrefs.SetInt("highscore", highscore);
            PlayerPrefs.Save();
        }

        // Display the updated highscore
        highScoreText.text = highscore.ToString();
    }
}
