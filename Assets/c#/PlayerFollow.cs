using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerFollow : MonoBehaviour
{
    public Transform target; // Transform del jugador
    public float followDistance = 5f; // Distancia a partir de la cual el personaje comenzar� a seguir al jugador
    public float attackDistance = 3f; // Distancia a partir de la cual el enemigo activar� su animaci�n de ataque
    public float moveSpeed = 5f; // Velocidad de movimiento del personaje

    private Animator animator;
    private bool isFacingRight = true; // Indica si el personaje est� mirando hacia la derecha

    void Start()
    {
        animator = GetComponent<Animator>();
    }

    void Update()
    {
        float distanceToTarget = Vector2.Distance(transform.position, target.position);

        if (distanceToTarget <= followDistance)
        {
            // Calcular la direcci�n hacia el jugador
            Vector3 targetDirection = target.position - transform.position;
            targetDirection.Normalize();

            // Modificar el eje x del personaje seg�n la direcci�n del jugador
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

            if (distanceToTarget <= attackDistance)
            {
                animator.SetBool("IsAttacking", true);
                // Aqu� puedes agregar la l�gica adicional para el ataque del enemigo
            }
            else
            {
                animator.SetBool("IsAttacking", false);
            }
        }
        else
        {
            animator.SetBool("IsAttacking", false);
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
