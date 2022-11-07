using UnityEngine;

[CreateAssetMenu(fileName = "Subtitle", menuName = "Subtitle")]
public class SubtitleClass : ScriptableObject
{
    public float time;
    public float duration;
    public string lyrics;
}
