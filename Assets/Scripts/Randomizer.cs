using UnityEngine;

/// <summary>
/// Randomly moves the target around the screen. 
/// Speed scales with score. Also defines the allowed timer for tapping.
/// </summary>
public class Randomizer : MonoBehaviour
{
    [Header("Movement Speed Settings")]
    [Tooltip("Minimum movement speed of the target.")]
    [SerializeField] private float minDifficulty = 3f;

    [Tooltip("Maximum movement speed of the target.")]
    [SerializeField] private float maxDifficulty = 20f;

    [Tooltip("Score at which the target hits maximum speed.")]
    [SerializeField] private int maxDifficultyScore = 1000;

    [Header("Screen Bounds Padding")]
    [Tooltip("Padding around the edges of the screen.")]
    [SerializeField] private float screenPadding = 0.5f;

    [Header("Time Allowed Before Player Loses")]
    [Tooltip("Seconds before game ends if not tapped.")]
    [SerializeField] private float timer = 5f;

    // Screen edges for random positioning
    private float bottom;
    private float top;
    private float left;
    private float right;

    // The target's current movement destination
    private Vector2 targetPosition;

    // Flag set true when the target needs repositioning after a tap
    private bool shouldReposition;

    private Camera mainCamera;

    private void Start()
    {
        mainCamera = Camera.main;
        SetEnvironmentBounds();

        // Generate initial positions
        transform.position = GetRandomPosition();
        targetPosition = GetRandomPosition();
        shouldReposition = false;
    }

    private void Update()
    {
        if (shouldReposition)
        {
            // If tapped, choose a new random position
            transform.position = GetRandomPosition();
            targetPosition = GetRandomPosition();
            shouldReposition = false;
        }
        else
        {
            // Calculate speed based on current score
            float difficulty = Mathf.Lerp(minDifficulty, maxDifficulty, GetScoreRatio());

            // Move towards the target position
            if ((Vector2)transform.position != targetPosition)
            {
                transform.position = Vector2.MoveTowards(
                    transform.position,
                    targetPosition,
                    difficulty * Time.deltaTime
                );
            }
            else
            {
                // If reached the position, pick another random spot
                targetPosition = GetRandomPosition();
            }
        }
    }

    /// <summary>
    /// Sets the four edges of the screen with a padding to avoid partial off-screen spawns.
    /// </summary>
    private void SetEnvironmentBounds()
    {
        Vector2 bottomLeft = mainCamera.ScreenToWorldPoint(new Vector3(0, 0, mainCamera.nearClipPlane));
        Vector2 topRight = mainCamera.ScreenToWorldPoint(new Vector3(mainCamera.pixelWidth, mainCamera.pixelHeight, mainCamera.nearClipPlane));

        bottom = bottomLeft.y + screenPadding;
        top = topRight.y - screenPadding;
        left = bottomLeft.x + screenPadding;
        right = topRight.x - screenPadding;
    }

    /// <summary>
    /// Generates a random position within the screen boundaries.
    /// </summary>
    private Vector2 GetRandomPosition()
    {
        float randomX = Random.Range(left, right);
        float randomY = Random.Range(top, bottom);
        return new Vector2(randomX, randomY);
    }

    /// <summary>
    /// Returns a value [0..1] that indicates how far we are from min to max difficulty, based on score.
    /// </summary>
    private float GetScoreRatio()
    {
        int score = Score_Manager.instance.Get_Score();
        return Mathf.Clamp01((float)score / maxDifficultyScore);
    }

    /// <summary>
    /// Called by Check_For_Touch to trigger a new random position after the target is tapped.
    /// </summary>
    public void New_position()
    {
        shouldReposition = true;
    }

    /// <summary>
    /// Returns the total time allowed before the player is considered to have lost.
    /// </summary>
    public float Get_timer()
    {
        return timer;
    }
}
