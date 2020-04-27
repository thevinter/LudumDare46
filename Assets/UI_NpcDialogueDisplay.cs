using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class UI_NpcDialogueDisplay : MonoBehaviour
{
    public StringVariable npcText;
    private TextMeshProUGUI tmp;

    private void Start() {
        tmp = GetComponent<TextMeshProUGUI>();
    }
    // Update is called once per frame
    void Update()
    {
        tmp.text = npcText.Value;
    }
}
