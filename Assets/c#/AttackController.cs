using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackController : MonoBehaviour
{
    private Animator animator;
    private bool isAttacking = false;
    public int attackDamage = 1; // Cantidad de daño del ataque

    void Start()
    {
        animator = GetComponent<Animator>();
    }

    void Update()
    {
        if (Input.GetMouseButtonDown(0) && !isAttacking)
        {
            Attack();
        }
    }

    void Attack()
    {
        isAttacking = true;
        animator.SetBool("IsAttacking", true);

        // Aquí puedes agregar la lógica para el ataque, como detección de colisión con el enemigo, daño, animaciones, efectos, etc.

        // Obtener todos los colliders en contacto con el área del ataque
        Collider2D[] hitColliders = Physics2D.OverlapBoxAll(transform.position, transform.localScale, 0);

        // Iterar sobre los colliders detectados y restar vida al enemigo si corresponde
        foreach (Collider2D hitCollider in hitColliders)
        {
            if (hitCollider.CompareTag("Enemy"))
            {
                EnemyHealth enemyHealth = hitCollider.GetComponent<EnemyHealth>();
                if (enemyHealth != null)
                {
                    enemyHealth.TakeDamage(attackDamage);
                }
            }
        }

        // Cuando finalice el ataque, se debe restablecer el bool y las condiciones
        Invoke(nameof(ResetAttack), 1.0f);
    }

    void ResetAttack()
    {
        isAttacking = false;
        animator.SetBool("IsAttacking", false);
    }
}
