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
    [SerializeField] private State[] states;
    
    private State currentState;

    public void Speak(){
        PrintString(currentState.dialogueOptions);
        if (currentState.questReward != null)
        {
            //player.give(currentState.questReward)
        }
        if (currentState.autoAdvance && currentState.nextState != null)
        {
                
            currentState = currentState.nextState;
        }
        print(currentState.nextState);
    }

    public void Start(){
        test.doorOpen += OnDoorOpen;
        currentState = states[0];
    }

    public void OnDoorOpen(){
        currentState = states[3];
        test.doorOpen -= OnDoorOpen;
    }

    public void Interact(Player p)
    {
        if(!isTalking)Speak();
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
