using UnityEngine;

[CreateAssetMenu(fileName = "Subtitle", menuName = "Subtitle")]
public class SubtitleClass : ScriptableObject
{
    public float time;
    public string lyrics;
    public bool latest;
}