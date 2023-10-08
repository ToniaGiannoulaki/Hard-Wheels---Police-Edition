using UnityEngine;
using UnityEngine.AI;
using System.Collections;
using System.Collections.Generic;

public class EnemyFollowPlayer : MonoBehaviour
{

    private Rigidbody myBody;

    [SerializeField] private GameObject target;

    [SerializeField] private float rotationSpeed;

    [SerializeField] private float speed;

    private void Awake()
    {
        myBody = GetComponent<Rigidbody>();
    }

    private void Start()
    {
        target = GameObject.FindWithTag("Player");
    }

    private void Update()
    {
        if (target != null)
        {
            Vector3 targetDirection = transform.position - target.transform.position;
            targetDirection.Normalize();

            float rotation = Vector3.Cross(targetDirection, transform.forward).y;

            // ����������� ��� ���������� ���� �����
            myBody.angularVelocity = rotationSpeed * rotation * new Vector3(0, 1, 0);
        }
    }

    private void FixedUpdate()
    {
        // � ������ �������� �������
        myBody.velocity = transform.forward * speed;
    }

    /*public Transform player; // � ������� ���� ����������
    private NavMeshAgent agent;

    private void Start()
    {
        agent = GetComponent<NavMeshAgent>();
        if (player == null)
        {
            // ������ ��� ������ �� ���� �� tag "Player"
            player = GameObject.FindGameObjectWithTag("Player").transform;
        }
    }

    private void Update()
    {
        if (player != null)
        {
            // ������ ��� ������ �� ��� ����� ��� NavMeshAgent
            agent.SetDestination(player.position);
        }
    }*/
}
