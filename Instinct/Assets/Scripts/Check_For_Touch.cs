using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Check_For_Touch : MonoBehaviour
{
    // Collider
    Collider2D Col;
    // Timer
    float timer;
    // Start is called before the first frame update
    void Start()
    {
        Col = GetComponent<Collider2D>();
        timer = 0;
    }

    // Update is called once per frame
    void Update()
    {
        timer += Time.deltaTime;
        if (timer >= gameObject.GetComponent<Randomizer>().timer)
        {
            SceneManager.LoadScene("Start");
        }
        
        if (Input.touchCount > 0)
        {
            Touch touch = Input.GetTouch(0);
            Vector2 touch_position = Camera.main.ScreenToWorldPoint(touch.position);

            if (touch.phase == TouchPhase.Began)
            {
                Collider2D touched_position = Physics2D.OverlapPoint(touch_position);
                if (Col == touched_position)
                {
                    timer = 0;
                    Score_Manager.instance.Add_Score();
                    gameObject.GetComponent<Randomizer>().New_position();
                }
            }
        }

    }
}
