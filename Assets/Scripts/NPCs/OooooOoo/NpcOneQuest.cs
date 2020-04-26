using TMPro;
using UnityEngine;

public class NpcOneQuest : MonoBehaviour, INpcQuestManager
{

    private bool isDoorOpen;

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

    public void OnDoorOpen() {
       isDoorOpen = true;
    }

    public void QuestSetUp() {
        EventManager.Instance.OnDoorOpen += OnDoorOpen;
        states[1].currentQuest = new Quest(null, p => isDoorOpen);
        states[3].currentQuest = new Quest(null, p => isDoorOpen);
        states[6].currentQuest = new Quest(null, p => isDoorOpen);

    }
}
