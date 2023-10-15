using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class NPCController : MonoBehaviour
{
    public NavMeshAgent agent;
    public Animator animator;

    CharacterNavigationController controller;
    public Waypoint currentWaypoint;

    int direction;

    private void Awake()
    {
        controller = GetComponent<CharacterNavigationController>();
    }

    void Start()
    {
        agent = GetComponent<NavMeshAgent>();
        animator = GetComponent<Animator>();

        direction = Mathf.RoundToInt(Random.Range(0f, 1f));
        controller.SetDestination(currentWaypoint.GetPosition());
    }

    void Update()
    {
        if (controller.reachedDestination)
        {
            bool shouldBranch = false;

            if (currentWaypoint.branches != null && currentWaypoint.branches.Count > 0)
            {
                shouldBranch = Random.Range(0f, 1f) <= currentWaypoint.branchRation ? true : false;
            }

            if (shouldBranch)
            {
                currentWaypoint = currentWaypoint.branches[Random.Range(0 , currentWaypoint.branches.Count - 1)];
            }
            else
            {
                if (direction == 0)
                {
                    if (currentWaypoint.nextWaypoint != null)
                    {

                    }
                    else
                    {
                        currentWaypoint = currentWaypoint.previousWaypoint;
                        direction = 1;
                    }
                    
                }
                else if (direction == 1)
                {
                    if (currentWaypoint.previousWaypoint != null)
                    {
                        currentWaypoint = currentWaypoint.previousWaypoint;
                    }
                    else
                    {
                        currentWaypoint = currentWaypoint.nextWaypoint;
                        direction = 0;
                    }
                    
                }
            }

            

            controller.SetDestination(currentWaypoint.GetPosition());
        }
    }
}





/*using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NPCController : MonoBehaviour
{
    public Transform waypointRoot; // � ���� ��� Waypoints
    public float moveSpeed = 5f; // �������� ������� ��� NPC

    private Waypoint currentWaypoint; // �� ������ Waypoint ���� �� ����� �������� �� NPC

    [Range(0f, 15f)][SerializeField] private float rotationSpeed = 4f;
    //the rotation target for the current frame
    private Quaternion rotationGoal;
    //the direction to the next waypoint that the agent needs to rotate towards
    private Vector3 directionToWaypoint;

    private void Start()
    {
        // ������������ ��� ������ Waypoint
        if (waypointRoot != null && waypointRoot.childCount > 0)
        {
            currentWaypoint = waypointRoot.GetChild(0).GetComponent<Waypoint>();
        }
    }

    private void Update()
    {
        if (currentWaypoint != null)
        {
            Vector3 waypointPosition = currentWaypoint.GetPosition(); // ���� ��� ��������� waypoint
            waypointPosition.y = transform.position.y; // ��������� ��� Y ����� �� �� ���� ��� �����������
            Vector3 direction = waypointPosition - transform.position;

            Quaternion targetRotation = Quaternion.LookRotation(direction);
            transform.rotation = Quaternion.Slerp(transform.rotation, targetRotation, Time.deltaTime * rotationSpeed);

            transform.Translate(direction.normalized * moveSpeed * Time.deltaTime);

            if (Vector3.Distance(transform.position, waypointPosition) < 0.1f)
            {
                SetNextWaypoint();
            }
        }


        *//*// ��������� �� ������ ������ Waypoint
        if (currentWaypoint != null)
        {
            // ���������� ���� ��� �������� Waypoint
            Vector3 direction = currentWaypoint.GetPosition() - transform.position;

            // ���������� ���� ��� ������ Waypoint
            Quaternion targetRotation = Quaternion.LookRotation(direction);
            transform.rotation = Quaternion.Slerp(transform.rotation, targetRotation, Time.deltaTime * rotationSpeed);

            // ������ ���� ��� ������ Waypoint
            transform.Translate(direction.normalized * moveSpeed * Time.deltaTime);

            // ��� ������ ������ ���� ������ Waypoint, ������� ��� ���� �������
            if (Vector3.Distance(transform.position, currentWaypoint.GetPosition()) < 0.1f)
            {
                SetNextWaypoint();
            }
        }*//*
    }


    *//*//will slowly rotate the agent towards the current waypoint it is moving towards
    private void RotateTowardsWaypoint()
    {
        directionToWaypoint = (currentWaypoint.GetPosition() - transform.position).normalized;
        rotationGoal = Quaternion.LookRotation(directionToWaypoint);
        transform.rotation = Quaternion.Slerp(transform.rotation, rotationGoal, rotateSpeed * Time.deltaTime);
    }*//*

    // ���� � ������� �������� ��� ������� Waypoint
    private void SetNextWaypoint()
    {
        if (currentWaypoint.nextWaypoint != null)
        {
            currentWaypoint = currentWaypoint.nextWaypoint;
        }
        else
        {
            // ��� ��� ������� �������� Waypoint, ������������ ���� ����� Waypoint
            currentWaypoint = waypointRoot.GetChild(0).GetComponent<Waypoint>();
        }
    }

    public Vector3 GetPosition()
    {
        Vector3 position = transform.position;

        // ������������� ��� �� Y ����� �� ���� �� �� Y ��� �����������
        position.y = transform.position.y;

        return position;
    }


}
*/