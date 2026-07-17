using UnityEngine;

public class ArrowBehaviour : MonoBehaviour
{

    public BeatType beatType; // The beat type of the arrow, set in the Unity Inspector

    [SerializeField] private float speed = 5f; // The speed at which the arrow moves (units per second)

    public float TargetBeat;

    public float MissDistance = 0.5f; // The distance at which the arrow is considered missed

    // Update is called once per frame
    void Update()
    {
        // time remaining until the note (in seconds)
        float currentBeat = Conductor.Instance.currentBeat;

        float beatDifference = TargetBeat - currentBeat;

        float newYPosition = beatDifference * speed;

        transform.localPosition = new Vector3(transform.localPosition.x, newYPosition, 0);

        if (beatDifference < -MissDistance)
        {
            Destroy(gameObject);
        }

    }
}
