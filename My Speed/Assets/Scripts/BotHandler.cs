using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class BotHandler : MonoBehaviour
{
    Vector3 targetPosition = Vector3.zero;
    public WaypointNode currentWaypoint = null;
    WaypointNode[] allWaypoints;
    PlayerController aiController;
    void Awake()
    {
        aiController = GetComponent<PlayerController>();
        allWaypoints = FindObjectsOfType<WaypointNode>();
    }
    void FixedUpdate()
    {
        Vector2 inputVector = Vector2.zero;
        FollowWaypoints();
        inputVector.x = TurnTowardsTarget();
        inputVector.y = SpeedOrBrake(inputVector.x);
        aiController.SetInputVector(inputVector);
    }
    void FollowWaypoints()
    {
        if (currentWaypoint==null)
        currentWaypoint = FindCloseWaypoint();
        if (currentWaypoint!=null)
        {
            targetPosition = currentWaypoint.transform.position;
            float distanceWaypoint = (targetPosition - transform.position).magnitude;
            if (distanceWaypoint <= currentWaypoint.minDistance)
            {
                currentWaypoint = currentWaypoint.nextWaypoint[Random.Range(0,currentWaypoint.nextWaypoint.Length)];
            }
        }
    }
    WaypointNode FindCloseWaypoint()
    {
        return allWaypoints
        .OrderBy(t => Vector3.Distance(transform.position, t.transform.position))
        .FirstOrDefault();
    }
    float TurnTowardsTarget()
    {
        Vector2 vectorToTarget = targetPosition - transform.position;
        vectorToTarget.Normalize();
        float angleToTarget = Vector2.SignedAngle(transform.up, vectorToTarget) * -1;
        float steerAmount = angleToTarget / 45.0f;
        return steerAmount;
    }
    float SpeedOrBrake(float inputX)
    {
        return 1.05f - Mathf.Abs(inputX) / 1.0f;
    }
}
