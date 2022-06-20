using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Check_For_Touch : MonoBehaviour
{
    // Sprite images
    public Sprite one;
    public Sprite two;
    public Sprite three;
    public Sprite four;
    public Sprite five;
    // Sprite counter
    int sprite = 5;
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
        show_timer(this, timer, sprite);

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
                    this.gameObject.GetComponent<SpriteRenderer>().sprite = five;
                    sprite = 5;
                    gameObject.GetComponent<Randomizer>().New_position();
                }
            }
        }

    }
    void show_timer(Check_For_Touch obj, float timer, int sprite)
    {
        if (timer >= gameObject.GetComponent<Randomizer>().Get_timer())
        {
            SceneManager.LoadScene("End");
        }
        if (timer >= 1 && timer < 2)
        {
            if (sprite != 4)
            {
                obj.gameObject.GetComponent<SpriteRenderer>().sprite = four;
                sprite = 4;
            }
        }
        else if (timer >= 2 && timer < 3)
        {
            if (sprite != 3)
            {
                obj.gameObject.GetComponent<SpriteRenderer>().sprite = three;
                sprite = 3;
            }
        }
        else if (timer >= 3 && timer < 4)
        {
            if (sprite != 2)
            {
                obj.gameObject.GetComponent<SpriteRenderer>().sprite = two;
                sprite = 2;
            }
        }
        else if (timer >= 4 && timer < 5)
        {
            if (sprite != 1)
            {
                obj.gameObject.GetComponent<SpriteRenderer>().sprite = one;
                sprite = 1;
            }
        }
    }
}
