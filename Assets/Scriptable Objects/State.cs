using UnityEngine;

[CreateAssetMenu(fileName = "Data", menuName = "ScriptableObjects/Dialogue", order = 1)]
public class State : ScriptableObject
{
    public int stateIndex;
    [TextArea]
    [Tooltip("A list of dialogue options")]
    public string[] dialogueOptions;
    public State nextState;
    public GameObject questReward;
    public Quest currentQuest;
    public delegate bool CheckCompletition();
    public bool IsCompleted(CheckCompletition c) {
        if (c == null) return true;
        else return c();
    }
       
}