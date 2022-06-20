using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Final_score_manager : MonoBehaviour
{
    // Highscore
    static int highscore;
    // Text file for score
    public TMP_Text Final_score;
    // Text file for highscore
    public TMP_Text Highscore;
    // Start is called before the first frame update
    void Start()
    {
        highscore = PlayerPrefs.GetInt("highscore", highscore);
        Final_score.text = Score_Manager.instance.Get_Score().ToString();
        if(Score_Manager.instance.Get_Score() >= highscore)
        {
            highscore = Score_Manager.instance.Get_Score();
            PlayerPrefs.SetInt("highscore", highscore);
            PlayerPrefs.Save();
        }
        Highscore.text = highscore.ToString();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
