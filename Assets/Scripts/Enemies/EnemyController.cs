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

    private void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").transform;
        unit = GetComponent<Unit>();
    }

    public void Update()
    {
        if (Vector2.Distance(transform.position, player.position) < lightRange.Value) 
        {
            unit.RequestPath(true);
        }
        else
        {
            unit.RequestPath(false);
        }
    }
}
