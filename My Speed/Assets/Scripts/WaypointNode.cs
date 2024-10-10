using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaypointNode : MonoBehaviour
{
    [Header("Este é o próximo ponto que o Bot vai")]
    public WaypointNode[] nextWaypoint;
    public float minDistance = 1;
}
