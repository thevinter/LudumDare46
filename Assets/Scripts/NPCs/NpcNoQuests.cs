using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NpcNoQuests : MonoBehaviour, INpcQuestManager {

    public State[] States { get => states; set => throw new System.NotImplementedException(); }
    public StringVariable QuestText { get => questText; set => throw new System.NotImplementedException(); }

    public State[] states;
    public StringVariable questText;

    public void Start() {
        foreach (State s in States) {
            s.SetTalked(false);
        }
        QuestSetUp();
    }

    public void OnDoorOpen() {
    }

    public void QuestSetUp() {
        
    }
}
