using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerIdleBehaviour : StateMachineBehaviour
{
    Player p;
    Rigidbody2D playerRb;
    PlayerInput pi;
    // OnStateEnter is called when a transition starts and the state machine starts to evaluate this state
    override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        p = animator.GetComponent<Player>();
        playerRb = animator.GetComponent<Rigidbody2D>();
        pi = p.GetComponent<PlayerInput>();

    }

    // OnStateUpdate is called on each Update frame between OnStateEnter and OnStateExit callbacks
    override public void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        animator.SetBool("isIdle", !(p.directionalInput.x != 0 || p.directionalInput.y != 0));
        animator.SetBool("isWalking", p.directionalInput.x != 0 || p.directionalInput.y != 0);
        animator.SetBool("isAttacking", pi.shootHorizontal != 0 || pi.shootVertical != 0);
        animator.SetFloat("velocityX", p.directionalInput.x);
        animator.SetFloat("velocityY", p.directionalInput.y);

    }

    // OnStateExit is called when a transition ends and the state machine finishes evaluating this state
    override public void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        animator.SetBool("isIdle", false);
    }

    // OnStateMove is called right after Animator.OnAnimatorMove()
    //override public void OnStateMove(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    //{
    //    // Implement code that processes and affects root motion
    //}

    // OnStateIK is called right after Animator.OnAnimatorIK()
    //override public void OnStateIK(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    //{
    //    // Implement code that sets up animation IK (inverse kinematics)
    //}
}
