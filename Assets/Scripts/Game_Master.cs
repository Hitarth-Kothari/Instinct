using UnityEngine;
using UnityEngine.SceneManagement;

/// <summary>
/// Controls pausing, resuming, and scene transitions.
/// </summary>
public class Game_Master : MonoBehaviour
{
    [SerializeField, Tooltip("Reference to the pause menu UI object.")]
    private GameObject pauseMenu;

    // Tracks whether the game is currently paused
    private bool isPaused = false;

    /// <summary>
    /// Global access instance.
    /// </summary>
    public static Game_Master Instance { get; private set; }

    private void Awake()
    {
        // Make sure only one Game_Master exists
        Instance = this;
    }

    /// <summary>
    /// Pauses the game (timeScale = 0) and shows pause menu.
    /// </summary>
    public void Pause()
    {
        isPaused = true;
        pauseMenu.SetActive(true);
        Time.timeScale = 0f;
    }

    /// <summary>
    /// Resumes the game (timeScale = 1) and hides pause menu.
    /// </summary>
    public void Resume()
    {
        isPaused = false;
        pauseMenu.SetActive(false);
        Time.timeScale = 1f;
    }

    /// <summary>
    /// Returns to the Start scene from pause.
    /// </summary>
    public void Home()
    {
        Resume();
        SceneManager.LoadScene("Start");
    }

    /// <summary>
    /// Loads the Main gameplay scene.
    /// </summary>
    public void GoTo()
    {
        SceneManager.LoadScene("Main");
    }

    /// <summary>
    /// Loads the Start (Home) scene.
    /// </summary>
    public void GoToStart()
    {
        SceneManager.LoadScene("Start");
    }

    /// <summary>
    /// Checks if game is currently paused.
    /// </summary>
    public bool Getpause()
    {
        return isPaused;
    }
}
