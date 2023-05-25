using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMovement : MonoBehaviour
{
    public float moveSpeed = 2f; // Velocidad de movimiento del enemigo
    public float detectionDistance = 5f; // Distancia de detección al personaje

    private Transform target; // Transform del personaje
    private bool isChasing = false; // Indica si el enemigo está persiguiendo al personaje
    private Vector3 randomDirection; // Dirección aleatoria de movimiento

    void Start()
    {
        target = GameObject.FindGameObjectWithTag("Player").transform;
        SetRandomDirection();
    }

    void Update()
    {
        if (isChasing)
        {
            ChasePlayer();
        }
        else
        {
            MoveRandomly();
        }
    }

    void MoveRandomly()
    {
        // transform.Translate(randomDirection * moveSpeed * Time.deltaTime);

        if (Vector3.Distance(transform.position, target.position) <= detectionDistance)
        {
            isChasing = true;
        }
    }

    void ChasePlayer()
    {
        Vector3 directionToPlayer = (target.position - transform.position).normalized;
        transform.Translate(directionToPlayer * moveSpeed * Time.deltaTime);

        if (Vector3.Distance(transform.position, target.position) > detectionDistance)
        {
            isChasing = false;
            SetRandomDirection();
        }
    }

    void SetRandomDirection()
    {
        randomDirection = new Vector3(Random.Range(-1f, 1f), Random.Range(-1f, 1f), 0f).normalized;
    }
}
