using System.Threading.Tasks;
using TMPro;
using UnityEngine;

[RequireComponent(typeof(TextMeshProUGUI))]
[RequireComponent(typeof(GameEventListener))]
public class UI_ItemInteractDisplay : MonoBehaviour
{
    public StringVariable interactName;
    [SerializeField] private TextMeshProUGUI tmp;
    [SerializeField] private GameObject child;
    // Start is called before the first frame update
    void Start() {
        tmp.text = "";
    }

    public void ShowText() {
        tmp.text = interactName.Value;
        child.SetActive(true);
    }

    public void HideText() {
        tmp.text = "";
        child.SetActive(false);

    }
}
