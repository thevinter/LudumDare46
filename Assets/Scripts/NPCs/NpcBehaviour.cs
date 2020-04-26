using System;
using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using UnityEngine;

public class NpcBehaviour : MonoBehaviour, INpc, IInteractable
{
    public string Name { get => npcname; set => throw new System.NotImplementedException(); }
    public State[] States { get => states; set => throw new System.NotImplementedException(); }

    [SerializeField] private string npcname = "Oooo";
    [SerializeField] private INpcQuestManager questManager;
    
    private State[] states;
    private bool isTalking = false;
    private State currentState;

    private int letterDelay = 40;

    private void Update() {
        print(WorldState.isDoorOpen);
    }
    /// <summary>
    /// Allows the NPC to print its current state's line of dialogue and sets the current state as his next aviable state after talking
    /// 
    /// If the player already talked to the NPC in its current state but this time the quest is completed then the NPC advances to its
    /// next state *before* displaying the dialogue
    /// </summary>
    public void Speak(){
            currentState = currentState.NextState();
            PrintString(currentState.dialogueOptions);
    }

    public void Start(){ 
        questManager = GetComponent<INpcQuestManager>();
        states = questManager.States;
        currentState = states[0];
    }

    /// <summary>
    /// Method of the Interactable Interface
    /// </summary>
    /// <param name="p">The Player GameObject</param>
    public void Interact(Player p){
        if (!isTalking) Speak();
        else letterDelay = 0;
    }

    /// <summary>
    /// This method prints all the array of sentences for the current State of the NPC. It currently waits 40ms between letters
    /// and 1000ms between phrases
    /// </summary>
    /// <param name="sentences">A list of sentences to say</param>
    private async void PrintString(string[] sentences){   
        int stringindex = 0;
        isTalking = true;
        while (stringindex < sentences.Length){
            int charindex = 0;
            string s = sentences[stringindex];
            char[] chars = s.ToCharArray();
            while (questManager.QuestText.text.Length < s.Length){
                questManager.QuestText.text += chars[charindex];
                charindex++;
                await Task.Delay(letterDelay);
            }
            stringindex++;
            await Task.Delay(1000);
            letterDelay = 40;
            questManager.QuestText.text = "";
        }
        isTalking = false;
    }
}
