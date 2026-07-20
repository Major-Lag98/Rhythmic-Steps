using System.IO;
using UnityEditor.ShaderGraph.Internal;
using UnityEngine;

public class Conductor : MonoBehaviour
{
    // singleton instance
    public static Conductor Instance { get; private set; }



    [SerializeField] private AudioSource songAudioSource; // The AudioSource component that will play the music
    [SerializeField] private float audioOffset = 0.00f; // Sometimes a songs beat doesnt start the instant the song starts
    
    public float ScrollSpeed = 1.0f; // The speed at which the arrows move (units per second)

    public float bpm = 120f; // 120 is common idk I need something to start with
    public float currentSongTime { get; private set; } // The current time of the song in seconds
    public float currentBeat { get; private set; }

    public float secPerBeat; // The number of seconds per beat, calculated from the BPM

    // Awake is called when the script instance is being loaded
    private void Awake()
    {
        // Singleton guard
        if (Instance == null) Instance = this;
        else Destroy(gameObject);

        secPerBeat = 60f / bpm;
    }

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        songAudioSource.Play();
    }

    // Update is called once per frame
    void Update()
    {
        if (!songAudioSource.isPlaying) return; // Wait for the song to start before updating

        float rawAudioTime = (float)songAudioSource.timeSamples / songAudioSource.clip.frequency; // Get the current time of the song in seconds

        currentSongTime = rawAudioTime - audioOffset;

        currentBeat = currentSongTime / secPerBeat;
    }
}
