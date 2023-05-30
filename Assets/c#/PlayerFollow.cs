using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerFollow : MonoBehaviour
{
    public Transform target; // Transform del jugador
    public float followDistance = 5f; // Distancia a partir de la cual el personaje comenzará a seguir al jugador
    public float moveSpeed = 5f; // Velocidad de movimiento del personaje

    private bool isFacingRight = true; // Indica si el personaje está mirando hacia la derecha

    void Update()
    {
        float distanceToTarget = Vector2.Distance(transform.position, target.position);

        if (distanceToTarget <= followDistance)
        {
            // Calcular la dirección hacia el jugador
            Vector3 targetDirection = target.position - transform.position;
            targetDirection.Normalize();

            // Modificar el eje x del personaje según la dirección del jugador
            if (targetDirection.x < 0 && isFacingRight)
            {
                FlipCharacter();
            }
            else if (targetDirection.x > 0 && !isFacingRight)
            {
                FlipCharacter();
            }

            // Mover el personaje hacia el jugador
            transform.position += targetDirection * moveSpeed * Time.deltaTime;
        }
    }

    void FlipCharacter()
    {
        isFacingRight = !isFacingRight;
        Vector3 characterScale = transform.localScale;
        characterScale.x *= -1;
        transform.localScale = characterScale;
    }
}

