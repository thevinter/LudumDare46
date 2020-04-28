using System.Threading.Tasks;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameController : MonoBehaviour
{
    public Player p;
    public CoordVariable lastSpawn;
    public void Awake() {
        SceneManager.LoadScene("UI", LoadSceneMode.Additive);
    }

    public async void RespawnPlayer() {
        await Task.Delay(1000);
        p.transform.position = lastSpawn.Value;
    }
}
