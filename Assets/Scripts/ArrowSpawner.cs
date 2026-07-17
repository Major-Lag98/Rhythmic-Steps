using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class ArrowSpawner : MonoBehaviour
{
    //[System.Serializable]
    //public struct NoteData
    //{
    //    public float targetBeat; // What beat to step on this note
    //    public int laneIndex;    // 0 = Left, 1 = Down, 2 = Up, 3 = Right
    //}

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
        // For testing: Create a simple chart (Spawn notes on beats 1, 2, 3, 4)
        GameObject arrow = Instantiate(arrowPrefabs[0], spawnPoints[0].transform.position, Quaternion.identity);
        arrow.GetComponent<ArrowBehaviour>().TargetBeat = 1f;
        songChart.Add(arrow);

        GameObject arrow2 = Instantiate(arrowPrefabs[0], spawnPoints[1].transform.position, Quaternion.identity);
        arrow2.GetComponent<ArrowBehaviour>().TargetBeat = 2f; 
        songChart.Add(arrow2);

        GameObject arrow3 = Instantiate(arrowPrefabs[0], spawnPoints[2].transform.position, Quaternion.identity);
        arrow3.GetComponent <ArrowBehaviour>().TargetBeat = 3f;
        songChart.Add(arrow3);

        GameObject arrow4 = Instantiate(arrowPrefabs[0], spawnPoints[3].transform.position, Quaternion.identity);
        arrow4.GetComponent<ArrowBehaviour>().TargetBeat = 4f;
        songChart.Add(arrow4);
    }

    private void Update()
    {
        
    }
}
