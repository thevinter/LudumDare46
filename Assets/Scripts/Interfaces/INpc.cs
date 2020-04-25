using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface INpc
{
    /// <summary>
    /// The name of the npc
    /// </summary>
    string Name { get; set; }

    /// <summary>
    /// The list of States the NPC can find himself in. Aka the state graph
    /// </summary>
    State[] States { get; set; }

    /// <summary>
    /// The speak action that should be called via the IInteractable interface
    /// </summary>
    void Speak();
}
