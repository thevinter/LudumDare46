using UnityEngine;

public class GameInstance : MonoBehaviour
{
    private static GameInstance _instance;
    public static GameInstance Instance { get { return _instance; } }


    private void Awake() {
        if (_instance != null && _instance != this) {
            Destroy(this.gameObject);
        }
        else {
            _instance = this;
        }
    }
    [SerializeField]
    private DataManager data;

    public Player GetPlayer() {
        return data.player;
    }

    public void SetPlayer(Player p) {
        data.player = p;
    }
}
