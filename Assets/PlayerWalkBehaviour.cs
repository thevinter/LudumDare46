using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerWalkBehaviour : StateMachineBehaviour
{
    Player p;
    Rigidbody2D playerRb;
    float lastX, lastY;
    // OnStateEnter is called when a transition starts and the state machine starts to evaluate this state
    override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        p = animator.GetComponent<Player>();
        playerRb = animator.GetComponent<Rigidbody2D>();
        lastX = p.transform.position.x;
        lastY = p.transform.position.y;
    }

    // OnStateUpdate is called on each Update frame between OnStateEnter and OnStateExit callbacks
    override public void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
       

        if (Mathf.Abs(p.transform.position.x - lastX) == 0 && Mathf.Abs(p.transform.position.y - lastY) == 0)
        {
            
            animator.SetBool("isIdle", true);
        }
        lastX = p.transform.position.x;
        lastY = p.transform.position.y;
    }

    // OnStateExit is called when a transition ends and the state machine finishes evaluating this state
    override public void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        Debug.Log("Im exiting");
        animator.SetBool("isWalking", false);
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
