using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NpcBehaviourOoooO : MonoBehaviour, INpc
{
    public string Name { get => npcname; set => throw new System.NotImplementedException(); }
    public Dialogue[] Dialogue { get => dialogues; set => throw new System.NotImplementedException(); }

    [SerializeField]
    private string npcname = "OooOOo";
    [SerializeField]
    private Dialogue[] dialogues;
    [SerializeField]
    private int currentState = 0;
    public void Speak()
    {
        Dialogue current = dialogues[currentState];
        foreach(string s in current.dialogueOptions)
        {
            print(s);
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
