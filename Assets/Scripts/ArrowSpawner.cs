using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class ArrowSpawner : MonoBehaviour
{

    const int AMOUNT_OF_LANES = 4;

    [Header("Prefabs & Spawn Positions")]
    [SerializeField] private GameObject[] arrowPrefabs; // Array of 4 arrow prefabs
    [SerializeField] private Transform[] spawnPoints;   // Array of 4 Transform positions

    [Header("Chart Settings")]
    [SerializeField] private float beatsAheadToSpawn = 4f; // Spawn arrows 4 beats before they must be hit

    // A list of notes representing your level chart (ordered by targetBeat)
    private List<GameObject> songChart = new List<GameObject>();
    private int nextNoteIndex = 0;

    private void Start()
    {
        // Load the chart file located at Assets/Resources/Charts/test.txt using Unity's Resources API
        TextAsset chartText = Resources.Load<TextAsset>("Charts/test");
        // If the file couldn't be found, log an error and stop initialization
        if (chartText == null)
        {
            Debug.LogError("Chart file not found at Resources/Charts/test.txt");
            return;
        }

        // Warn if arrowPrefabs doesn't contain four prefabs (one per lane)
        if (arrowPrefabs.Length != 4)
            Debug.LogWarning("arrowPrefabs should contain 4 prefabs (one per lane).");
        // Warn if spawnPoints doesn't contain four transforms (one per lane)
        if (spawnPoints.Length != 4)
            Debug.LogWarning("spawnPoints should contain 4 transforms (one per lane).");

        // Split the file text into non-empty lines, handling both Carriage Return and Line Feed
        string[] rawLineList = chartText.text.Split(new[] { '\r', '\n' }, System.StringSplitOptions.RemoveEmptyEntries);
        // beatIndex tracks which beat (line) we are on
        int beatIndex = 0;
        // Iterate over every non-empty line from the chart file
        foreach (string rawLine in rawLineList)
        {
            // Trim whitespace from the line
            string line = rawLine.Trim();
            // Skip comment lines that start with '//' entirely
            if (line.StartsWith("//"))
                continue;

            // For each lane character in the line
            for (int laneIndex = 0; laneIndex < AMOUNT_OF_LANES; laneIndex++)
            {
                // If the character is '0' we should do nothing
                // If the character is '1' we should spawn an arrow for this lane
                if (line[laneIndex] == '1')
                {
                    // Instantiate the lane-specific arrow prefab at the corresponding spawn point
                    GameObject arrow = Instantiate(arrowPrefabs[laneIndex], spawnPoints[laneIndex].position, Quaternion.identity);
                    // Try to set the TargetBeat on the ArrowBehaviour component if it exists
                    var behaviour = arrow.GetComponent<ArrowBehaviour>();
                    if (behaviour != null)
                        behaviour.TargetBeat = beatIndex;
                    // Add the spawned arrow to the songChart list for tracking
                    songChart.Add(arrow);
                }
                // TODO: Handle '2' for hold notes
            }

            // Move to the next beat (next line represents the next beat)
            beatIndex++;
        }
    }

    private void Update()
    {
        
    }
}
