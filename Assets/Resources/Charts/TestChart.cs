using UnityEngine;

[CreateAssetMenu(fileName = "TestChart", menuName = "Scriptable Objects/TestChart")]
public class TestChart : ScriptableObject
{
    public AudioClip songClip;

    public TextAsset chartFile; // The text file containing the chart data
}
