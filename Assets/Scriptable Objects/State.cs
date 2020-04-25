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

    public State NextState() {

        hasTalkedAlready = true;
        if (currentQuest == null) return nextStateIfTrue;
        else {
            if (currentQuest.IsCompleted()) return nextStateIfTrue;
            else return nextStateIfFalse;
        }
    }
}