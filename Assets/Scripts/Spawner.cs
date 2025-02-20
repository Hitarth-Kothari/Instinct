using UnityEngine;

/// <summary>
/// Spawns additional targets once certain score thresholds are met.
/// </summary>
public class Spawner : MonoBehaviour
{
    [Header("Spawner Settings")]
    [Tooltip("Prefab for the target to be spawned.")]
    [SerializeField] private GameObject targetPrefab;

    [Tooltip("Maximum number of targets to spawn.")]
    [SerializeField] private int maxTargets = 10;

    // Counts how many times we've spawned a target
    private int counter = 1;

    private void Start()
    {
        // Spawn the initial target
        Instantiate(targetPrefab);
    }

    private void Update()
    {
        int currentScore = Score_Manager.instance.Get_Score();

        // If current score hits the threshold and we haven't spawned too many
        if (currentScore == GetThreshold(counter) && counter < maxTargets)
        {
            Instantiate(targetPrefab);
            counter++;
        }
    }

    /// <summary>
    /// Returns the score threshold for the given counter.
    /// Example: 20 * (counter^2).
    /// </summary>
    private int GetThreshold(int c)
    {
        return 20 * c * c;
    }
}
