using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PathCorrecting : MonoBehaviour
{
    EnemyState state;
    Transform target;
    Unit unit;

    private void Start()
    {
        state = GetComponent<EnemyState>();
        target = GameObject.FindGameObjectWithTag("Player").transform;
        unit = GetComponent<Unit>();
    }

    // Update is called once per frame
    void Update()
    {
        CorrectMovement();
    }

    void CorrectMovement()
    {
        float dist = Vector2.Distance(transform.position, target.position);
        if (state.GetState() == _EnemyState.approaching)
        {
            if(dist < unit.attackRadius && dist > 1)
            {
                transform.position = Vector2.MoveTowards(transform.position, target.position, Time.deltaTime * unit.speed);
            }
            else if(dist > unit.attackRadius)
            {
                state.SetState(_EnemyState.chasing);
            }
        }
    }
}
