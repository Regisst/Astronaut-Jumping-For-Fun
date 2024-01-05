using UnityEngine;

public class MovingPlatform : MonoBehaviour
{
    [SerializeField] Transform platform;
    [SerializeField] Transform[] targetPoints;
    [SerializeField] float speed = 2;

    private int _currentTarget = 0;
    private bool ItMovesBackwards = false;

    private void OnDrawGizmos()
    {
        for (int i = 0; i < targetPoints.Length - 1; i++)
        {
            Gizmos.DrawLine(targetPoints[i].position, targetPoints[i + 1].position);
        }
    }

    private void Update()
    {
        MovementPlatform(targetPoints[_currentTarget].position);
    }

    private void MovementPlatform(Vector2 target)
    {
        platform.position = Vector2.MoveTowards(platform.position, target, speed * Time.deltaTime);

        FindLastTarget();

        if ((Vector2)platform.position == target)
        {
            if (ItMovesBackwards)
            {
                _currentTarget--;
            }
            else
            {
                _currentTarget++;
            }
        }

    }

    private void FindLastTarget()
    {
        if (platform.position == targetPoints[targetPoints.Length - 1].position)
        {
            ItMovesBackwards = true;
        }
        else if (platform.position == targetPoints[0].position)
        {
            ItMovesBackwards = false;
        }
    }

}
