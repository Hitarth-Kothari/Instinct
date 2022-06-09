using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Randomizer : MonoBehaviour
{
    // Environment coordinates
    float down;
    float up;
    float left;
    float right;

    // Error margin
    float error = 0.5f;

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
        // Camera for screen edge detection
        Camera cam = Camera.main;
        // Bottom left corner
        Vector2 bottomLeft = (Vector2)cam.ScreenToWorldPoint(new Vector3(0, 0, cam.nearClipPlane));
        // Top right corner
        Vector2 topRight = (Vector2)cam.ScreenToWorldPoint(new Vector3(cam.pixelWidth, cam.pixelHeight, cam.nearClipPlane));
        // Max and Min range for Target
        float d = bottomLeft.y;
        float u = topRight.y;
        float l = bottomLeft.x;
        float r = topRight.x;
        // Set environment
        set_environment(d, u, l, r);
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
    // Sets environment
    void set_environment(float d, float u, float l, float r)
    {
        down = d + error;
        up = u - error;
        left = l + error;
        right = r - error;
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
