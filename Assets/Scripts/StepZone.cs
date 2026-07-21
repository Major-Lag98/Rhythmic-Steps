using UnityEngine;
using System.Collections;

public class StepZone : MonoBehaviour
{

    // list of prefabs for the target lanes
    [SerializeField] private GameObject lanePrefab;

    public GameObject[] stepZoneLanesList = new GameObject[4]; // index 0 = Left, 1 = Down, 2 = Up, 3 = Right

    // Singleton instance
    public static StepZone Instance { get; private set; }

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Awake()
    {
        // Singleton guard
        if (Instance == null) Instance = this;
        else Destroy(gameObject);
    }

    private void Start()
    {
        // Instantiate the 4 lane prefabs as children of the StepZone; they should be 2 units apart in the x direction. centered on the StepZone's position.
        for (int i = 0; i < 4; i++)
        {
            GameObject lane = Instantiate(lanePrefab, transform);
            // lanes x should be respctively -2.25, -0.75, 0.75, 2.25
            lane.transform.localPosition = new Vector3((i * 1.5f) - 2.25f, 0, 0);
            // append the lane to the list of lanes
            stepZoneLanesList[i] = lane;
        }
    }
}
