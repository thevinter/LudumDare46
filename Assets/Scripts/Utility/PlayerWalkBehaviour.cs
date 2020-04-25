using ChrisTutorials.Persistent;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerWalkBehaviour : StateMachineBehaviour
{
    Player p;
    PlayerInput pi;
    float lastX, lastY;
    public AudioClip bonfireStart;
 
    // OnStateEnter is called when a transition starts and the state machine starts to evaluate this state
    override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        p = animator.GetComponent<Player>();
        lastX = p.transform.position.x;
        lastY = p.transform.position.y;
        pi = p.GetComponent<PlayerInput>();
        bonfireStart = p.moveStart;
        AudioManager.Instance.Play(bonfireStart, animator.transform, .05f, 3f);
    }

    // OnStateUpdate is called on each Update frame between OnStateEnter and OnStateExit callbacks
    override public void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        bool input = p.directionalInput.x != 0 || p.directionalInput.y != 0;
        float movementX = Mathf.Abs(animator.transform.position.x - lastX);
        float movementY = Mathf.Abs(animator.transform.position.y - lastY);
        bool movement = movementX != 0 && movementY != 0;
        animator.SetBool("isIdle", !input && !movement);
        animator.SetBool("isWalking", input && movement);
        animator.SetBool("isAttacking", (pi.shootHorizontal != 0 || pi.shootVertical != 0));

        if(Mathf.Abs(p.directionalInput.x) == Mathf.Abs(p.directionalInput.y))
        {
            animator.SetFloat("velocityX", 0);
            animator.SetFloat("velocityY", p.directionalInput.y);
        }
        else
        {
            animator.SetFloat("velocityX", p.directionalInput.x);
            animator.SetFloat("velocityY", p.directionalInput.y);
        }

        lastX = p.transform.position.x;
        lastY = p.transform.position.y;
    }

    // OnStateExit is called when a transition ends and the state machine finishes evaluating this state
    override public void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
       
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
