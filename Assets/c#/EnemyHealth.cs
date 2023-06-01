using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHealth : MonoBehaviour
{
    public int maxHealth = 10; // Vida máxima del enemigo
    private int currentHealth; // Vida actual del enemigo

    void Start()
    {
        currentHealth = maxHealth;
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        /*
        if (collision.gameObject.CompareTag("Player")) // Verificar si la colisión es con el jugador
        {
            // Restar vida al enemigo
            TakeDamage(1); // Puedes ajustar el valor de la cantidad de daño según tus necesidades
        }
        */
    }

    public void TakeDamage(int damage)
    {
        currentHealth -= damage;

        if (currentHealth <= 0)
        {
            Die(); // Si la vida del enemigo llega a 0 o menos, llamar al método Die()
        }
    }

    void Die()
    {
        // Aquí puedes agregar la lógica para la muerte del enemigo, como reproducir una animación de muerte, otorgar puntos al jugador, etc.
        Destroy(gameObject); // Destruir el GameObject del enemigo
    }
}
