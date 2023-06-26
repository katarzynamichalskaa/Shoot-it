using UnityEngine;
using UnityEngine.AI;
using Pathfinding;

public class EnemyMovement : MonoBehaviour
{
    public Transform player;
    public float distanceToStartChasing = 2f;
    public Transform StartPoint;
    public Transform DestinationPoint;
    public Transform enemy;
    private Quaternion targetRotation;
    private AIPath aiPath;
    private bool isChasingPlayer = false;


    private void Start()
    {
        aiPath = GetComponent<AIPath>();
        aiPath.destination = DestinationPoint.position;

        if (player == null)
        {
            Debug.LogError("Player not assigned!");
        }
    }

    private void Update()
    {

        float distanceToPlayer = Vector3.Distance(transform.position, player.position);

        if (distanceToPlayer <= distanceToStartChasing)
        {
            RotateTowardsPlayer();
            isChasingPlayer = true;
            aiPath.destination = player.position;
        }
        else
        {
            if (isChasingPlayer)
            {
                aiPath.destination = DestinationPoint.position;
                isChasingPlayer = false;
            }

            if (aiPath.reachedDestination)
            {
                if (aiPath.destination == DestinationPoint.position)
                {
                    RotateTowardsStartPoint();
                    aiPath.destination = StartPoint.position;
                }
                else if (aiPath.destination == StartPoint.position)
                {
                    RotateTowardsDestinationPoint();
                    aiPath.destination = DestinationPoint.position;
                }
            }
        }
    }

    private void RotateTowardsPlayer()
    {
        if (player != null)
        {
            Vector3 direction = player.position - transform.position;

            if (Mathf.Sign(direction.x) != Mathf.Sign(transform.localScale.x))
            {
                Vector3 newScale = transform.localScale;
                newScale.x *= -1;
                transform.localScale = newScale;
            }
        }
    }

    private void RotateTowardsStartPoint()
    {
        if (StartPoint != null)
        {
            Vector3 newScale = transform.localScale;
            newScale.x *= -1;
            transform.localScale = newScale;

        }
    }

    private void RotateTowardsDestinationPoint()
    {
        if (DestinationPoint != null)
        {
            Vector3 newScale = transform.localScale;
            newScale.x *= -1;
            transform.localScale = newScale;

        }
    }
}
