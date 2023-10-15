using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class CharacterNavigationController : MonoBehaviour
{
    public NavMeshAgent agent;
    public Animator animator;
    public Waypoint[] waypoints; // �������������� ���� ������ ��� waypoints
    private int currentWaypointIndex = 0;
    public bool reachedDestination = false;

    private void Start()
    {
        agent = GetComponent<NavMeshAgent>();
        animator = GetComponent <Animator>();

        if (waypoints.Length > 0)
        {
            SetDestination(waypoints[currentWaypointIndex].GetPosition());
        }
    }

    private void Update()
    {
        if (!reachedDestination)
        {
            // ������� ��� � NPC ���� ������ ���� �������� waypoint
            if (agent.remainingDistance <= agent.stoppingDistance)
            {
                reachedDestination = true;
                //animator.SetBool("IsWalking", false); // ���������� ��� ������������ ��� �������
                currentWaypointIndex++;

                if (currentWaypointIndex >= waypoints.Length -1)
                {
                    currentWaypointIndex = 0;
                }

                SetDestination(waypoints[currentWaypointIndex].GetPosition());
            }
        }

        //animator.SetFloat("vertical", agent.IsWalking ? 1 : 0);
    }
    

    public void SetDestination(Vector3 destination)
    {
        agent.SetDestination(destination);
        reachedDestination = false;
        animator.SetBool("IsWalking", true); // ��������� ��� ������������ ��� �������
        animator.SetFloat("vertical", 1);
    }
}
