using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{

    // Max targets
    public int Max_targets;
    // Score threshold
    public int score_threshold;
    // Object counter
    int counter = 1;
    // Spawn target
    public GameObject target;

    // Start is called before the first frame update
    void Start()
    {
        Instantiate(target);
    }

    // Update is called once per frame
    void Update()
    {
        if (Score_Manager.instance.Get_Score() == (counter*score_threshold))
        {
            Instantiate(target);
            counter += 1;
        }
    }
}
