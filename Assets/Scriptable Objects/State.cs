using System;
using System.Runtime.InteropServices;
using UnityEngine;

[CreateAssetMenu(fileName = "Data", menuName = "ScriptableObjects/Dialogue", order = 1)]
public class State : ScriptableObject
{
    public int stateIndex;
    [TextArea]
    [Tooltip("A list of dialogue options")]
    public string[] dialogueOptions;
    public State nextStateIfTrue;
    public State nextStateIfFalse;
    public Quest currentQuest;
    public GameObject questReward;

    private bool hasTalkedAlready = false;

    public bool HasTalkedAlready() {
        return hasTalkedAlready;
    }   

    public void SetTalked(bool state) {
        hasTalkedAlready = state;
    }

    /// <summary>
    /// This method returns the next State based on whether the current Quest is completed. If there is no current quest then State
    /// is considered to be on "Auto Advance" and proceeds to the next state whenever the Next State is asked.
    /// </summary>
    /// <returns></returns>
    public State NextState() {

        hasTalkedAlready = true;
        if (currentQuest == null) return nextStateIfTrue;
        else {
            if (currentQuest.IsCompleted()) return nextStateIfTrue;
            else return nextStateIfFalse;
        }
    }
}