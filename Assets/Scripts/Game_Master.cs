using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Game_Master : MonoBehaviour
{
    [SerializeField] GameObject pausemenu;
    bool pause = false;
    public static Game_Master Instance;

    private void Awake()
    {
        Instance = this;
    }
    public void Pause()
    {
        pause = true;
        pausemenu.SetActive(true);
        Time.timeScale = 0f;
    }

    public void Resume()
    {
        pause = false;
        pausemenu.SetActive(false);
        Time.timeScale = 1f;
    }

    public void Home()
    {
        pause = false;
        Time.timeScale = 1f;
        SceneManager.LoadScene("Start");
    }
    public void GoTo()
    {
        SceneManager.LoadScene("Main");
    }
    public void GoToStart()
    {
        SceneManager.LoadScene("Start");
    }

    public bool Getpause()
    {
        return pause;
    }

}
