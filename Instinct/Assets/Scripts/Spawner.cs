using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{

    // Max targets
    int Max_targets = 10;
    // Object counter
    int counter;
    // Spawn target
    public GameObject target;

    // Start is called before the first frame update

    private void Awake()
    {
        counter = 1;
    }
    void Start()
    {
        Instantiate(target);
    }

    // Update is called once per frame
    void Update()
    {
        if (Score_Manager.instance.Get_Score() == Get_threshold(counter))
        {
            if (counter < Max_targets)
            {
                Instantiate(target);
                counter += 1;
            }
        }
    }
    int Get_threshold(int counter)
    {
        int a = (counter) * (counter);
        a = 20 * a;
        return a;
    }
}
