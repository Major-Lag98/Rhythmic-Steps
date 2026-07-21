using UnityEngine;

public class ArrowBehaviour : MonoBehaviour
{

    public BeatType beatType; // The beat type of the arrow, set in the Unity Inspector

    private float speed; // The speed at which the arrow moves (units per second)

    public float TargetBeat;

    public float MissDistance = 0.5f; // The distance at which the arrow is considered missed

    public int LaneIndex; // The index of the lane this arrow belongs to (0 = Left, 1 = Down, 2 = Up, 3 = Right)

    //Vector3 StepZonePos;

    private void Start()
    {
        speed = Conductor.Instance.ScrollSpeed;
        //// Cache initial step zone position; we'll read the current position each frame
        //StepZonePos = StepZone.Instance.transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        // time remaining until the note (in seconds)
        float currentBeat = Conductor.Instance.currentBeat;

        float beatDifference = TargetBeat - currentBeat;

        float newYPosition = beatDifference * speed;

        // Make y=0 of the arrow prefab be relative to the StepZone's world Y position.
        // Use the StepZone's current world position in case it moves at runtime.
        Vector3 currentStepZonePos = StepZone.Instance.transform.position;
        float worldY = currentStepZonePos.y + newYPosition;

        transform.position = new Vector3(StepZone.Instance.stepZoneLanesList[LaneIndex].transform.position.x, worldY, transform.position.z);

        if (beatDifference < -MissDistance)
        {
            Destroy(gameObject);
        }

    }
}
