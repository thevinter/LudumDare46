using UnityEngine;
using System.Collections;

public class Unit : MonoBehaviour
{


    public Transform target;
    public float speed = 3;
    public float turnDist = 0;
    public float turnSpeed = 3;
    bool followingPath = true;
    private EnemyState state;
    Path path;
    public float attackRadius = 1;

    private void Start()
    {
        state = GetComponent<EnemyState>();
    }

    public void RequestPath(bool state)
    {
        if (state) PathRequestManager.RequestPath(transform.position, target.position, OnPathFound);
        else followingPath = false;
    }

    public void OnPathFound(Vector2[] waypoits, bool pathSuccessful)
    {
        if (pathSuccessful)
        {
            path = new Path(waypoits, transform.position, turnDist);
            StopCoroutine("FollowPath");
            StartCoroutine("FollowPath");
        }
    }

    IEnumerator FollowPath()
    {

        Vector2 moveDirection = Vector2.zero;
        bool followingPath = true;
        int pathIndex = 0;
        if (path.lookPoints.Length == 0)
        {
            followingPath = false;
        }
        else moveDirection = (path.lookPoints[0] - (Vector2)transform.position).normalized;
        if (!(state.GetState() == _EnemyState.chasing) && !(state.GetState() == _EnemyState.idle)) followingPath = false;

        while (followingPath)
        {
            Vector2 pos2D = (Vector2)transform.position;
            if (path.turnBoundaries[pathIndex].HasCrossedLine(pos2D))
            {
                if (pathIndex == path.finishLineIndex)
                {
                    followingPath = false;
                }

                else pathIndex++;
            }
            yield return null;
            if (followingPath)
            {
                Vector2 targetDirection = (path.lookPoints[pathIndex] - (Vector2)transform.position).normalized;
                moveDirection = Vector2.Lerp(moveDirection, targetDirection, Time.deltaTime * turnSpeed).normalized;
                transform.Translate(moveDirection * Time.deltaTime * speed);
            }
        }
    }

    private void Update()
    {
        print(state.GetState());

    }

    public void OnDrawGizmos()
    {
        if (path != null)
        {
            path.DrawWithGizmos();
        }
    }
}