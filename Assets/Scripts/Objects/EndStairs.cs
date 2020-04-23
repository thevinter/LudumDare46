using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class EndStairs : MonoBehaviour, IInteractable
{
    public string Name { get => itemName; set => throw new System.NotImplementedException(); }

    public string itemName = "Stairs";

    public void Interact(Player p)
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
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
