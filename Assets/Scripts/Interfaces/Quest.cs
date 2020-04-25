using System;
using UnityEngine;

public class Quest
{
    private Func<Player, bool> CompleteQuest;
    private Player p;
    int nextStateIfTrue, nextStateIfFalse;


    public Quest(Player p, Func<Player, bool> quest) {
        CompleteQuest = quest;
        this.p = p;
    } 

    public bool IsCompleted() {
        return CompleteQuest(p);
    }
    
}
