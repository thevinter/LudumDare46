using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SlimeAttackBehaviour : StateMachineBehaviour
{
    GameObject player;
    private EnemyController enemy;
    private Vector3 prevPos;
    // OnStateEnter is called when a transition starts and the state machine starts to evaluate this state
    override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        player = GameObject.FindGameObjectWithTag("Player");
        animator.GetComponent<EnemyController>().StartAttacking(true, player);
        enemy = animator.GetComponent<EnemyController>();
        prevPos = animator.transform.position;
    }

    // OnStateUpdate is called on each Update frame between OnStateEnter and OnStateExit callbacks
    override public void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        Vector3 movement = animator.transform.position - prevPos;
        Debug.Log("Animator is:  " + animator + " player is:  " + player);
        if (Vector3.Distance(animator.transform.position, player.transform.position) > enemy.attackDistance)
        {
            animator.SetBool("isAttacking", false);
            animator.SetBool("isChasing", true);
        }
        animator.SetFloat("moveX", movement.x);
        animator.SetFloat("moveY", movement.y);
    }

    // OnStateExit is called when a transition ends and the state machine finishes evaluating this state
    override public void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        animator.GetComponent<EnemyController>().StartAttacking(false, player);

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
