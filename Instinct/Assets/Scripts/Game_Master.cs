using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Game_Master : MonoBehaviour
{

    public void GoTo()
    {
        SceneManager.LoadScene("Main");
    }

}
