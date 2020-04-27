using TMPro;
using UnityEngine;

[RequireComponent(typeof(TextMeshProUGUI))]
public class UI_NpcDialogueDisplay : MonoBehaviour
{
    public StringVariable npcText;
    private TextMeshProUGUI tmp;

    private void Start() {
        tmp = GetComponent<TextMeshProUGUI>();
        tmp.text = "";
    }
    // Update is called once per frame
    void Update()
    {
        tmp.text = npcText.Value;
    }


}
