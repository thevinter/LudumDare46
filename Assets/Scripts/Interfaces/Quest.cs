using System;

public class Quest
{
    private Func<Player, bool> CompleteQuest;
    private Player p;

    public Quest(Player p, Func<Player, bool> quest) {
        CompleteQuest = quest;
        this.p = p;
    } 

    public bool IsCompleted() {
        return CompleteQuest(p);
    } 
}
