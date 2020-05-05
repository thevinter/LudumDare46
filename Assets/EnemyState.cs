using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum _EnemyState
{
    idle,
    chasing,
    approaching,
    attacking
}
public class EnemyState : MonoBehaviour
{
    private _EnemyState state;

    private void Start()
    {
        state = _EnemyState.idle;
    }

    public _EnemyState GetState()
    {
        return state;
    }

    public void SetState(_EnemyState s)
    {
        state = s;
    }
}
