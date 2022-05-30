using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Score_Manager : MonoBehaviour
{
    // Score string
    public TMP_Text Score_Text;
    // Score variable
    int Score = 0;
    // Create instance
    public static Score_Manager instance;

    // Initiate instance
    private void Awake()
    {
        instance = this;
    }

    // Start is called before the first frame update
    void Start()
    {
        Score_Text.text = Score.ToString();
    }

    // Add point
    public void Add_Score()
    {
        Score += 1;
        Score_Text.text = Score.ToString();
    }

    // Get score
    public int Get_Score()
    {
        return Score;
    }
}
