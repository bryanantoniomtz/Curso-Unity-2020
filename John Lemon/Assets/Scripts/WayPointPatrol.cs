using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

[RequireComponent(typeof(NavMeshAgent))]
public class WayPointPatrol : MonoBehaviour
{
    // Start is called before the first frame update
    
    private NavMeshAgent navMeshAgent;
    public Transform[] waypoints;
    private int currentWaypointIndex;
    
    void Start()
    {
        navMeshAgent=GetComponent<NavMeshAgent>();
        navMeshAgent.SetDestination(waypoints[currentWaypointIndex].position);
      
    }

    // Update is called once per frame
    void Update()
    {
     
         Debug.Log(currentWaypointIndex);
         Debug.Log(navMeshAgent.remainingDistance);
         Debug.Log(navMeshAgent.stoppingDistance);
        if(navMeshAgent.remainingDistance>0){  
         
            if(navMeshAgent.remainingDistance < navMeshAgent.stoppingDistance)
            {
            currentWaypointIndex=(currentWaypointIndex + 1 ) % waypoints.Length;
             navMeshAgent.SetDestination(waypoints[currentWaypointIndex].position);
            } 
        }
    }
}
