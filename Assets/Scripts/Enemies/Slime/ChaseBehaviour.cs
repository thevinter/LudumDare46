﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChaseBehaviour : StateMachineBehaviour
{

    //private GameObject player;
    //private Transform playerTransform;
    //private EnemyController enemy;

    //override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    //{
    //    player = GameObject.FindGameObjectWithTag("Player");
    //    playerTransform = player.transform;
    //    enemy = animator.GetComponent<EnemyController>();
    //}

    //// OnStateUpdate is called on each Update frame between OnStateEnter and OnStateExit callbacks
    //override public void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    //{
    //    animator.transform.position = Vector3.MoveTowards(animator.transform.position, playerTransform.position, enemy.speed * Time.deltaTime);
    //    if (Vector3.Distance(animator.transform.position, player.transform.position) > enemy.chaseDistance)
    //    {
    //        animator.SetBool("isIdle", true);
    //        animator.SetBool("isChasing", false);
    //    }
    //    if (Vector3.Distance(animator.transform.position, player.transform.position) < enemy.attackDistance)
    //    {
    //        animator.SetBool("isAttacking", true);
    //        animator.SetBool("isChasing", false);
    //    }

    //}

    // OnStateExit is called when a transition ends and the state machine finishes evaluating this state
    override public void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {

    }
}
