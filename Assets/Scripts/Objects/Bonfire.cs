using ChrisTutorials.Persistent;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bonfire : MonoBehaviour, IInteractable
{
    public string Name { get => objectName; set => throw new System.NotImplementedException(); }
    [SerializeField]
    private string objectName = "Bonfire";
    private bool isSitting = false;
    private Light l;
    private Animator anim;
    public AudioClip bonfireSound;
    private bool isLit =false;
    public float desiredRange;

    private void Start()
    {
        l = GetComponentInChildren<Light>();
        anim = GetComponent<Animator>();
    }
    public void Interact(Player p)
    {
        if (!isLit)
        {
            isLit = true;
            anim.SetBool("isLitUp", true);
            AudioManager.Instance.Play(bonfireSound, transform);
            LightUp();
        }
        isSitting = !isSitting;
        p.torch.SetConsuming(!isSitting);
        p.SetRestState(isSitting);
        print("Im sitting: " + isSitting);
        
        p.GetComponent<Animator>().SetBool("isIdle", !isSitting);
        p.GetComponent<Animator>().SetBool("isResting", isSitting);

        
    }

    void LightUp()
    {
        while(l.range < desiredRange)
        {
            l.range += 0.2f;
        }
    }

    void Update()
    {
        if (isLit)
        {
            float desiredRange = Random.Range(8f, 12f);
            l.range = Mathf.Lerp(l.range, desiredRange, .2f);
        }
       
    }
}
