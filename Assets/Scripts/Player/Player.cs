using UnityEngine;
using ChrisTutorials.Persistent;
using System.Threading.Tasks;
using UnityEngine.Events;

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

    [Tooltip("The event that gets invoked when the player dies")] 
    public UnityEvent deathEvent;

    [Tooltip("A field used for testing purposes, should be left on true for the time being")]
    public bool tutorial = false;

    private bool isResting = false;
    private bool canDamage = true;
    private bool canPlaySound = true;

    private PlayerFlame flame;
    private Controller2D controllerScript;
    private PlayerShoot shootScript;
    private SpriteRenderer r;
    private InteractScript inter;

    //Needs to be implemented again, probably with an event
    private CameraShake shake = null;

    public bool resetSpeed;

    //Things to remove
    //Put this into a separate Audio controller with events and stuff
    //public AudioClip[] playerDamageSounds;
    //public AudioClip playerDeathSound;
    //public AudioClip[] stepSounds;
    //public AudioClip startMovingSound;

    public int Health { get => (int)flame.GetCurrentFlame(); set => throw new System.NotImplementedException(); }
    public Vector2 DirectionalInput { get => directionalInput; set { } }
    
    /// <summary>
    /// Function that is called when the player dies 
    /// </summary>
    public void Die() {
        deathEvent.Invoke();
    }

    private void Awake() {
        //GameInstance.Instance.SetPlayer(this);
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

    

    private void FixedUpdate() {
        if(!isResting)
            controllerScript.Move(directionalInput.normalized, moveSpeed.Value);
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
        GetComponents();
    }

    /// <summary>
    /// Finds and initializes all the necessary components
    /// </summary>
    private void GetComponents() {
        r = GetComponent<SpriteRenderer>();
        controllerScript = GetComponent<Controller2D>();
        shootScript = GetComponent<PlayerShoot>();
        flame = GetComponent<PlayerFlame>();
        inter = GetComponent<InteractScript>();
        if (!tutorial) shake = GameObject.FindGameObjectWithTag("Shake").GetComponent<CameraShake>();
    }

    /// <summary>
    /// Interacts with the current interactable object
    /// </summary>
    public void Interact() {
        inter.Interact(this);
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

    private async Task TurnRed() {
        r.color = Color.red;
        await Task.Delay(100);
        r.color = Color.white;
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
            //AudioClip stepSound = stepSounds[Random.Range(0, stepSounds.Length - 1)];
            //AudioManager.Instance.Play(stepSound, transform, .2f);
        }
    }

    
    public void Damage(int damage) {
        if (canDamage) {
            //AudioManager.Instance.Play(playerDamage[Random.Range(0,playerDamage.Length-1)], transform);
            canDamage = false;
            //shake.shake = 0.5f;
            _ = TurnRed();
            _ = Invuln();
            flame.ReduceCurrentFlame(damage);
        }
    }
}
