using TMPro;
using UnityEngine;

public class NpcOneQuest : MonoBehaviour, INpcQuestManager
{
    public TextMeshProUGUI QuestText { get => questText; set => throw new System.NotImplementedException(); }
    public State[] States { get => states; set => throw new System.NotImplementedException(); }

    public TextMeshProUGUI questText;
    public State[] states;

    public void Start() {
        foreach (State s in States) {
            s.SetTalked(false);
        }
        QuestSetUp();
    }

    private void OnDoorOpen() {
        WorldState.isDoorOpen = true;
    }

    public void QuestSetUp() {
        EventManager.current.OnDoorOpen += OnDoorOpen;
        states[2].currentQuest = new Quest(null, p => WorldState.isDoorOpen);
        states[5].currentQuest = new Quest(null, p => WorldState.isDoorOpen);
    }
}
