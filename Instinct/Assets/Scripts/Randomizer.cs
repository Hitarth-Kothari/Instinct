using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Randomizer : MonoBehaviour
{
    // Max and Min range for Target
    public float down;
    public float up;
    public float left;
    public float right;

    // Target Position used for directional movement
    Vector2 Target_Position;

    // Difficulty
    public float Min_difficulty;
    public float Max_difficulty;
    float Difficulty;

    // Change Position
    bool change;

    // Max difficulty score
    public int Max_difficulty_score;

    // Max time allowed
    public float timer;
    // Start is called before the first frame update
    void Start()
    {
        // Random start position
        transform.position = Randomize_Position();
        // Random direction
        Target_Position = Randomize_Position();
        // Set change to false
        change = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (change)
        {
            transform.position = Randomize_Position();
            Target_Position = Randomize_Position();
            change = false;
        }
        else
        {
            if ((Vector2)transform.position != Target_Position)
            {
                Difficulty = Mathf.Lerp(Min_difficulty, Max_difficulty, GetDifficulty());
                transform.position = Vector2.MoveTowards(transform.position, Target_Position, Difficulty * Time.deltaTime);
            }
            else
            {
                Target_Position = Randomize_Position();
            }
        }

    }

    // Finds a random point on screen
    Vector2 Randomize_Position()
    {
        float randomX = Random.Range(left, right);
        float randomY= Random.Range(up, down);

        return new Vector2(randomX, randomY);
    }

    // Bool for new position once clicked
    public void New_position()
    {
        change = true;
    }

    // Max difficulty percentage
    float GetDifficulty()
    {
        return Mathf.Clamp01(Score_Manager.instance.Get_Score() / Max_difficulty_score);
    }
}
