using System.Collections.Generic;
using UnityEngine;

public class ArrowSpawner : MonoBehaviour
{
    [System.Serializable]
    public struct NoteData
    {
        public float targetBeat; // What beat to step on this note
        public int laneIndex;    // 0 = Left, 1 = Down, 2 = Up, 3 = Right
    }

    [Header("Prefabs & Spawn Positions")]
    [SerializeField] private GameObject[] arrowPrefabs; // Array of 4 arrow prefabs
    [SerializeField] private Transform[] spawnPoints;   // Array of 4 Transform positions

    [Header("Chart Settings")]
    [SerializeField] private float beatsAheadToSpawn = 4f; // Spawn arrows 4 beats before they must be hit

    // A list of notes representing your level chart (ordered by targetBeat)
    private List<NoteData> songChart = new List<NoteData>();
    private int nextNoteIndex = 0;

    private void Start()
    {
        // For testing: Create a simple chart (Spawn notes on beats 1, 2, 3, 4)
        songChart.Add(new NoteData { targetBeat = 1f, laneIndex = 0 });
        songChart.Add(new NoteData { targetBeat = 2f, laneIndex = 1 });
        songChart.Add(new NoteData { targetBeat = 3f, laneIndex = 2 });
        songChart.Add(new NoteData { targetBeat = 4f, laneIndex = 3 });
    }

    private void Update()
    {
        
    }
}
