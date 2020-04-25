using System;
using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class NpcOneBehaviour : MonoBehaviour, INpc, IInteractable
{
    public TestDelegate test;
    public string Name { get => npcname; set => throw new System.NotImplementedException(); }
    public State[] States { get => states; set => throw new System.NotImplementedException(); }

    public TextMeshProUGUI questText;
    private bool isTalking = false;

    [SerializeField] private string npcname = "NPC1";
    [SerializeField] private State[] states = null;
    
    private State currentState;

    private void Update() {
        print(currentState.HasTalkedAlready());
    }

    public void Speak(){
        if (currentState.HasTalkedAlready()) {
            print(currentState.HasTalkedAlready());
            currentState = currentState.NextState();
        }
        PrintString(currentState.dialogueOptions);
        currentState = currentState.NextState();
    }

    public void Start(){
        foreach (State s in states) {
            s.setTalked(false);
        }
        states[2].currentQuest = new Quest(null, p => WorldState.isDoorOpen);
        states[5].currentQuest = new Quest(null, p => WorldState.isDoorOpen);
        test.doorOpen += OnDoorOpen;
        currentState = states[0];
        
    }

    public void OnDoorOpen(){
        WorldState.isDoorOpen = true;
        test.doorOpen -= OnDoorOpen;
    }

    public void Interact(Player p)
    {
        if (!isTalking)Speak();
    }

    private async void PrintString(string[] sentences)
    {   
        int stringindex = 0;
        isTalking = true;
        while (stringindex < sentences.Length) {
            int charindex = 0;
            string s = sentences[stringindex];
            char[] chars = s.ToCharArray();
            while (questText.text.Length < s.Length) {
                questText.text += chars[charindex];
                charindex++;
                await Task.Delay(40);
            }
            stringindex++;
            await Task.Delay(1000);
            questText.text = "";
        }
        isTalking = false;
    }
}
