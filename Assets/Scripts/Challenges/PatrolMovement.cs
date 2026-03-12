using UnityEngine;
using System.Collections;
public class PatrolMovement : MonoBehaviour
{
     public Transform waypointParent;

    public float moveSpeed = 2f;
    public float waitTime = 2f;
    public bool loopWaypoint = true;
    private Transform[] waypoints;
    private int currentWaypointIndex;
    private bool isWaiting;

    void Start()
    {
        waypoints = new  Transform[waypointParent.childCount];

        for (int i = 0; i < waypointParent.childCount; i++)
        {
            waypoints[i] = waypointParent.GetChild(i);
        }
    }

    void Update()
    {
        if (!isWaiting && !GameController.instance.failStateTriggered) MoveToWaypoint();
    }

    private void MoveToWaypoint()
    {
        if (currentWaypointIndex < waypoints.Length - 1)
        {
            Transform target = waypoints[currentWaypointIndex];
            transform.position = Vector2.MoveTowards(transform.position, target.position, moveSpeed * Time.deltaTime);
            if (Vector2.Distance(transform.position, target.position) < 0.1f)
            {
                StartCoroutine(WaitAtWaypoint());
            }

            Vector3 moveDirection = (target.position - transform.position).normalized;
            //transform.rotation = Quaternion.LookRotation(moveDirection);
            // 1. Calculate the direction vector from the current object to the target
            Vector3 directionToTarget = moveDirection;

            // 2. Use Mathf.Atan2 to find the angle in radians, then convert to degrees
            // Atan2 returns the angle whose tangent is the quotient of two specified numbers (y, x)
            float angle = Mathf.Atan2(directionToTarget.y, directionToTarget.x) * Mathf.Rad2Deg;

            // 3. Apply the rotation to the Z-axis (assuming your sprite's "forward" is the X-axis/right)
            // Adjust the angle offset if your sprite's default orientation is different (e.g., add or subtract 90 degrees)
            transform.rotation = Quaternion.Euler(new Vector3(0, 0, angle - 180));
        }
    }

    IEnumerator WaitAtWaypoint()
    {
        isWaiting = true;
        yield return new WaitForSeconds(waitTime);
        currentWaypointIndex = loopWaypoint
            ? (currentWaypointIndex + 1) % waypoints.Length
            : Mathf.Min(currentWaypointIndex + 1, waypoints.Length - 1);
        isWaiting = false;
    }
    
}
