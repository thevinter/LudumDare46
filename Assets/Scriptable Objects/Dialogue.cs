using UnityEngine;

[CreateAssetMenu(fileName = "Data", menuName = "ScriptableObjects/Dialogue", order = 1)]
public class Dialogue : ScriptableObject
{
    [TextArea]
    [Tooltip("A list of dialogue options")]
    public string[] dialogueOptions;
    public int nextState;
}