using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public interface INpcQuestManager
{
    //The quest dialogue element that the NPC uses when displaying his text
    TextMeshProUGUI QuestText { get; set; }
    State[] States { get; set; }

    /// <summary> 
    /// A method that manages all of the quests of a character. 
    /// 
    /// 1)Subscribes to all of the NPC related events 
    /// 2)Creates the necessary quests
    /// 3)Sets the starting state to the first State
    /// 4)Resets all of the states to "Not talked yet". This is necessary since the States are scriptable objects and are persistent
    /// </summary>
    void QuestSetUp();
}
