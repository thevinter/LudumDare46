using ChrisTutorials.Persistent;
using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using UnityEngine;

public class EnemyController : MonoBehaviour
{
    private Transform player;
    public FloatVariable lightRange;
    private Unit unit;
    private EnemyState state;
    
    private void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").transform;
        unit = GetComponent<Unit>();
        state = GetComponent<EnemyState>();
    }

    public void Update()
    {
        GetState();
        if (state.GetState() == _EnemyState.chasing) 
        {
            unit.RequestPath(true);
        }
        else
        {
            unit.RequestPath(false);
        }
    }

    void GetState()
    {
        float dist = Vector2.Distance(transform.position, player.position);
        if (dist > lightRange.Value) state.SetState(_EnemyState.idle);
        else if (dist < lightRange.Value && dist > unit.attackRadius) state.SetState(_EnemyState.chasing);
        else if (dist < unit.attackRadius && dist > 1) state.SetState(_EnemyState.approaching);
        else if (dist < 1) state.SetState(_EnemyState.attacking);
    }
}
