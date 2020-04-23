using UnityEngine;
using System.Collections;
using TMPro;
using ChrisTutorials.Persistent;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Player : MonoBehaviour, IDamageable
{
    public float moveSpeed = 6;

    Vector3 velocity;
    public bool tutorial = false;
    public bool canInteract = false;
    public PlayerTorch torch;
    public Controller2D controller;
    public PlayerShoot shoot;
    public IInteractable obj;
    public bool isResting = false;
    private CameraShake shake;
    private bool canDamage = true;
    private PlayerAnimator anim;
    public AudioClip[] playerDamage; 
    public GameObject itemTextBox;
    private Renderer r;
    public AudioClip[] steps;
    bool canPlaySound = true;
    public AudioClip moveStart;
    public Vector2 directionalInput;
    public Image img;
    public AudioClip playerDeath;
    private bool gameOver = false;
    public int Health { get => (int)torch.currentFlame; set => throw new System.NotImplementedException(); }

    private void OnLevelWasLoaded(int level)
    {


    }

    public void Die()
    {
        if (!gameOver)
        {
            AudioManager.Instance.Play(playerDeath, transform, .1f);
            gameOver = true;
        }
        StartCoroutine(FadeImage(false, true));       
    }

    IEnumerator FadeImage(bool fadeAway, bool gameOver = false)
    {
        // fade from opaque to transparent
        if (fadeAway)
        {
            // loop over 1 second backwards
            for (float i = 1; i >= 0; i -= Time.deltaTime)
            {
                // set color with i as alpha
                //img.color = new Color(0, 0, 0, i);
                yield return null;
            }
            
        }
        // fade from transparent to opaque
        else
        {

            // loop over 1 second
            for (float i = 0; i <= 2; i += Time.deltaTime)
            {
                // set color with i as alpha
                //img.color = new Color(0, 0, 0, i);
                yield return null;
            }
            //if (gameOver) SceneManager.LoadScene("GameOver");
        }
    }



    private void FixedUpdate()
    {
        if(!isResting)
            controller.Move(directionalInput.normalized, moveSpeed);
        Step();
    }


    public void SetRestState(bool rest)
    {
        isResting = rest;
        //fai robe animazione e musica
        if (isResting)
        {
            torch.Fill();
        }
    }

    void Start()
    {
        if(!tutorial) StartCoroutine(FadeImage(true));
        r = GetComponent<Renderer>();
        anim = GetComponent<PlayerAnimator>();
        controller = GetComponent<Controller2D>();
        shoot = GetComponent<PlayerShoot>();
        torch = GetComponent<PlayerTorch>();
        if(!tutorial) shake = GameObject.FindGameObjectWithTag("Shake").GetComponent<CameraShake>();
    }

    public void Interact()
    {
        obj.Interact(this);
    }

    public void SetDirectionalInput(Vector2 input)
    {
        directionalInput = input;
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Usable"))
        {
            obj = collision.gameObject.GetComponent<IInteractable>();
            itemTextBox.GetComponent<TextMeshProUGUI>().text = obj.Name;
            itemTextBox.SetActive(true);
            canInteract = true;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Usable"))
        {
            itemTextBox.SetActive(false);
            obj = null;
            canInteract = false;
        }
    }

    private IEnumerator TurnRed()
    {
        r.material.color = Color.red;
        yield return new WaitForSeconds(0.1f);
        r.material.color = Color.white;
    }
    public void AddWeapon(GameObject weapon)
    {
        shoot.SetWeapon(weapon);
    }
    private IEnumerator Invuln()
    {
        yield return new WaitForSeconds(.5f);
        canDamage = true;
    }

    private IEnumerator SoundTimer() {
        yield return new WaitForSeconds(7.5f);
        canPlaySound = true;
    }

    public void Step() {
        if (canPlaySound)
        {
            canPlaySound = false;
            StartCoroutine(SoundTimer());
            AudioClip stepSound = steps[Random.Range(0, steps.Length - 1)];
            AudioManager.Instance.Play(stepSound, transform, .2f);
        }
    }

    public void Damage(int damage)
    {
        if (canDamage) {
            AudioManager.Instance.Play(playerDamage[Random.Range(0,playerDamage.Length-1)], transform);
            canDamage = false;
            shake.shake = 0.5f;
            StartCoroutine(TurnRed());
            StartCoroutine(Invuln());
            torch.currentFlame -= damage;
        }
    }
}
