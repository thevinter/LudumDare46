using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public interface INpcQuestManager
{
    State[] States { get; set; }
    StringVariable QuestText { get; set; }
    /// <summary> 
    /// A method that manages all of the quests of a character. It has to:
    /// <br/> <br/> 
    /// 1)Subscribe to all of the NPC related events<br/> 
    /// 2)Create the necessary quests<br/> 
    /// 3)Reset all of the states to "Not talked yet". This is necessary since the States are scriptable objects and are persistent
    /// </summary>
    void QuestSetUp();
}
