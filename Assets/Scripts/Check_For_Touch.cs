using UnityEngine;
using UnityEngine.SceneManagement;

/// <summary>
/// Handles touch input on a target object. 
/// Resets timer when tapped and ends the game if time runs out.
/// </summary>
public class Check_For_Touch : MonoBehaviour
{
    [Header("Sprites for Countdown")]
    [Tooltip("Sprite displayed when 1 second remains.")]
    public Sprite spriteOne;

    [Tooltip("Sprite displayed when 2 seconds remain.")]
    public Sprite spriteTwo;

    [Tooltip("Sprite displayed when 3 seconds remain.")]
    public Sprite spriteThree;

    [Tooltip("Sprite displayed when 4 seconds remain.")]
    public Sprite spriteFour;

    [Tooltip("Sprite displayed when 5 seconds remain (start sprite).")]
    public Sprite spriteFive;

    // Cached Components
    private SpriteRenderer spriteRenderer;
    private Collider2D myCollider;
    private Randomizer randomizer;

    // Timer for how long until the target must be tapped
    private float timer;

    // Indicates which sprite is active (1-5)
    private int currentSpriteIndex;

    private void Start()
    {
        // Cache references to avoid repeated GetComponent calls
        spriteRenderer = GetComponent<SpriteRenderer>();
        myCollider = GetComponent<Collider2D>();
        randomizer = GetComponent<Randomizer>();

        timer = 0f;
        currentSpriteIndex = 5;
        spriteRenderer.sprite = spriteFive;
    }

    private void Update()
    {
        // Increment timer each frame
        timer += Time.deltaTime;

        // Check for user touch input
        HandleTouchInput();

        // Update sprite or end game based on elapsed time
        UpdateSpriteAndCheckTimeout();
    }

    /// <summary>
    /// Checks for a single touch event. If the target is tapped, resets the timer and updates the score.
    /// </summary>
    private void HandleTouchInput()
    {
        // Only proceed if there's at least one touch
        if (Input.touchCount == 0) return;

        Touch touch = Input.GetTouch(0);
        if (touch.phase != TouchPhase.Began) return;

        // Convert screen point to world coordinates
        Vector2 touchPosition = Camera.main.ScreenToWorldPoint(touch.position);
        // Check if our collider was touched
        Collider2D touchedCollider = Physics2D.OverlapPoint(touchPosition);

        // If this object was touched and the game isn't paused
        if (touchedCollider == myCollider && Game_Master.Instance.Getpause() == false)
        {
            // Reset timer
            timer = 0f;
            // Increase score
            Score_Manager.instance.Add_Score();

            // Reset sprite to #5
            spriteRenderer.sprite = spriteFive;
            currentSpriteIndex = 5;

            // Move target to a new random position
            randomizer.New_position();
        }
    }

    /// <summary>
    /// Compares the current timer with the allowed time to decide if we switch sprites or end the game.
    /// </summary>
    private void UpdateSpriteAndCheckTimeout()
    {
        float allowedTime = randomizer.Get_timer();
        // If timer exceeds allowed time, end game
        if (timer >= allowedTime)
        {
            PlayerPrefs.SetInt("score", Score_Manager.instance.Get_Score());
            SceneManager.LoadScene("End");
            return;
        }

        // Update the sprite based on which second boundary we're in
        // 1s intervals: [0-1)=5, [1-2)=4, [2-3)=3, [3-4)=2, [4-5)=1
        if (timer >= 1f && timer < 2f && currentSpriteIndex != 4)
        {
            spriteRenderer.sprite = spriteFour;
            currentSpriteIndex = 4;
        }
        else if (timer >= 2f && timer < 3f && currentSpriteIndex != 3)
        {
            spriteRenderer.sprite = spriteThree;
            currentSpriteIndex = 3;
        }
        else if (timer >= 3f && timer < 4f && currentSpriteIndex != 2)
        {
            spriteRenderer.sprite = spriteTwo;
            currentSpriteIndex = 2;
        }
        else if (timer >= 4f && timer < 5f && currentSpriteIndex != 1)
        {
            spriteRenderer.sprite = spriteOne;
            currentSpriteIndex = 1;
        }
    }
}
