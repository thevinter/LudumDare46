using UnityEngine;
using System.Collections;
using ChrisTutorials.Persistent;
using UnityEngine.UI;
using System.Threading.Tasks;
using UnityEditor.Animations;

public enum PlayerState {
    idle,
    resting,
    attacking,
    dashing,
    pause,
    interacting,
}

public class Player : MonoBehaviour, IDamageable {
    public FloatVariable moveSpeed;
    private Vector2 directionalInput;

    public bool tutorial = false;
    public bool canInteract = false;
    private bool isResting = false;
    private bool canDamage = true;
    private bool gameOver = false;
    bool canPlaySound = true;

    private PlayerFlame flame;
    private Controller2D controllerScript;
    private PlayerShoot shootScript;
    private CameraShake shake = null;
    private IInteractable obj;
    private PlayerAnimator anim;
    private Renderer r;

    public bool resetSpeed;

    //Things to remove
    public AudioClip[] playerDamage;
    public GameObject itemTextBox;
    public AudioClip playerDeath;
    public AudioClip[] steps;
    public AudioClip moveStart;
    public Image img;
 


    public int Health { get => (int)flame.GetCurrentFlame(); set => throw new System.NotImplementedException(); }
    public Vector2 DirectionalInput { get => directionalInput; set { } }
    /// <summary>
    /// Function that is called when the player dies 
    /// </summary>
    public void Die() {
        if (!gameOver) {
            AudioManager.Instance.Play(playerDeath, transform, .1f);
            gameOver = true;
        }
        StartCoroutine(FadeImage(false, true));
    }

    private void Awake() {
        //GameInstance.Instance.SetPlayer(this);
        if (resetSpeed)
            moveSpeed.SetValue(moveSpeed.Value);
    }

    public void SetResting(bool state) {
        isResting = state;
    }

    public bool GetResting() {
        return isResting;
    }

    /// <summary>
    /// Sends the shoot comand to the ShootScript based on the horizontal and on the vertical input
    /// </summary>
    /// <param name="hor">The horizontal direction of shooting</param>
    /// <param name="ver">The vertical direction of shooting</param>
    public void Shoot(float hor, float ver) {
        shootScript.Shoot(hor, ver);
    }

    /// <summary>
    /// Sets if the torch has to be consumed overtime or not
    /// </summary>
    /// <param name="state">True if the torch has to be consumed overtime, false otherwhise</param>
    public void SetConsumingTorch(bool state) {
        flame.SetConsuming(state);
    }


    /// <summary>
    /// IEnumerator that allows the fade of an Image. It shouldn't be here but rather in a separate UI script
    /// </summary>
    /// <param name="fadeAway"></param>
    /// <param name="gameOver"></param>
    /// <returns></returns>
    IEnumerator FadeImage(bool fadeAway, bool gameOver = false) {
        // fade from opaque to transparent
        if (fadeAway) {
            // loop over 1 second backwards
            for (float i = 1; i >= 0; i -= Time.deltaTime) {
                // set color with i as alpha
                //img.color = new Color(0, 0, 0, i);
                yield return null;
            }
        }
        // fade from transparent to opaque
        else {
            // loop over 1 second
            for (float i = 0; i <= 2; i += Time.deltaTime) {
                // set color with i as alpha
                //img.color = new Color(0, 0, 0, i);
                yield return null;
            }
            //if (gameOver) SceneManager.LoadScene("GameOver");
        }
    }

    private void FixedUpdate() {
        if(!isResting)
            controllerScript.Move(directionalInput.normalized, 6);
        Step();
    }

    /// <summary>
    /// Puts the character into a resting state and fills its torch
    /// </summary>
    /// <param name="rest">Whether the character is resting or not</param>
    public void SetRestState(bool rest) {
        isResting = rest;
        if (isResting) {
            flame.Fill();
        }
    }

    void Start() {
        if(!tutorial) StartCoroutine(FadeImage(true));
        GetComponents();
    }

    /// <summary>
    /// Finds and initializes all the necessary components
    /// </summary>
    private void GetComponents() {
        r = GetComponent<Renderer>();
        anim = GetComponent<PlayerAnimator>();
        controllerScript = GetComponent<Controller2D>();
        shootScript = GetComponent<PlayerShoot>();
        flame = GetComponent<PlayerFlame>();
        if (!tutorial) shake = GameObject.FindGameObjectWithTag("Shake").GetComponent<CameraShake>();
    }

    /// <summary>
    /// Interacts with the current interactable object
    /// </summary>
    public void Interact() {
        obj.Interact(this);
    }

    /// <summary>
    /// Sets the player's movement direction
    /// </summary>
    /// <param name="input">The direction the player is moving towards</param>
    public void SetDirectionalInput(Vector2 input) {
        directionalInput = input;
    }

    /// <summary>
    /// Recharghes the player's torch
    /// </summary>
    /// <param name="amount"></param>
    public void RechargeTorch(int amount) {
        flame.Recharge(amount);
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.GetComponent<IInteractable>() != null) {
            obj = collision.gameObject.GetComponent<IInteractable>();
            // REMEMBER TO DECOMMENT itemTextBox.GetComponent<TextMeshProUGUI>().text = obj.Name;
            // REMEMBER TO DECOMMENT itemTextBox.SetActive(true);
            canInteract = true;
        }
    }

    private void OnTriggerExit2D(Collider2D collision) {
        if (collision.gameObject.GetComponent<IInteractable>() != null) {
            //itemTextBox.SetActive(false);
            obj = null;
            canInteract = false;
        }
    }

    private async Task TurnRed() {
        r.material.color = Color.red;
        await Task.Delay(100);
        r.material.color = Color.white;
    }

    public void AddWeapon(GameObject weapon) {
        shootScript.SetWeapon(weapon);
    }

    private async Task Invuln() {
        await Task.Delay(500);
        canDamage = true;
    }

    private async Task SoundTimer() {
        await Task.Delay(7500);
        canPlaySound = true;
    }

    //This works but needs to be reworked because it was a hack for the LD
    public void Step() {
        if (canPlaySound){
            canPlaySound = false;
            _ = SoundTimer();
            AudioClip stepSound = steps[Random.Range(0, steps.Length - 1)];
            AudioManager.Instance.Play(stepSound, transform, .2f);
        }
    }

    
    public void Damage(int damage) {
        if (canDamage) {
            AudioManager.Instance.Play(playerDamage[Random.Range(0,playerDamage.Length-1)], transform);
            canDamage = false;
            shake.shake = 0.5f;
            _ = TurnRed();
            _ = Invuln();
            flame.ReduceCurrentFlame(damage);
        }
    }
}
