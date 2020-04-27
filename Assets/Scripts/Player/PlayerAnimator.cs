using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAnimator : MonoBehaviour
{
    private Player player;
    private PlayerInput playerInput;
    private Animator anim;
    // Start is called before the first frame update
    void Start() {
        player = GetComponent<Player>();
        playerInput = GetComponent<PlayerInput>();
        anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update() {
        anim.SetBool("isResting", player.GetResting());
        anim.SetBool("isIdle", !(player.DirectionalInput.x != 0 || player.DirectionalInput.y != 0));
        anim.SetBool("isWalking", player.DirectionalInput.x != 0 || player.DirectionalInput.y != 0);
        anim.SetBool("isAttacking", playerInput.shootHorizontal != 0 || playerInput.shootVertical != 0);
        anim.SetFloat("velocityX", player.DirectionalInput.x);      
        anim.SetFloat("velocityY", player.DirectionalInput.y);
    }
}
