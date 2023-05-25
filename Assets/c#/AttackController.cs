using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackController : MonoBehaviour
{
    private Animator animator;
    private bool isAttacking = false;
    public int attackDamage = 1; // Cantidad de daño del ataque
    Coroutine current = null;
    float timePassed;
    float missingAnimationTime = 0;
    
    [SerializeField] private float timeAnimeATK1;
    [SerializeField] private float timeAnimeATK2;
    [SerializeField] private float timeAnimeATK3;
    bool atk1;
    bool atk2;
    bool atk3;

    void Start()
    {
        animator = GetComponent<Animator>();
    }

    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Attack();
        }
    }

    void Attack()
    {
        isAttacking = true;
        if (animator.GetBool("IsAttacking2"))
        {
            animator.SetBool("IsAttacking3", true);
        }

        if (animator.GetBool("IsAttacking"))
        {
            animator.SetBool("IsAttacking2", true);
        }


        // ATK 1
        animator.SetBool("IsAttacking", true);
        if (current == null && animator.GetBool("IsAttacking2") == false && animator.GetBool("IsAttacking3") == false) { 
            current = StartCoroutine(WaitAndDo(0.375f));
            atk1 = true;
        }

        if (current != null && animator.GetBool("IsAttacking2") == true && animator.GetBool("IsAttacking3") == false)
        {
            StopCoroutine(current);
            current = StartCoroutine(WaitAndDo(1 + missingAnimationTime));
            atk2 = true;
        }

        if (current != null && animator.GetBool("IsAttacking2") == true && animator.GetBool("IsAttacking3") == true)
        {
            if(atk3 == false) {
                atk3 = true;
                StopCoroutine(current);
                current = StartCoroutine(WaitAndDo(1 + missingAnimationTime));
            }
        }
    }
     
    IEnumerator WaitAndDo(float time)
    {
        timePassed = 0;
        missingAnimationTime = time;

        while (timePassed < time) {
            yield return new WaitForSeconds(0.016f);
            timePassed += 0.016f;
            missingAnimationTime = time - timePassed;
        }
        
        ResetAttack();
        current = null;
    }

     void ResetAttack()
    {
        animator.SetBool("IsAttacking", false);
        animator.SetBool("IsAttacking2", false);
        animator.SetBool("IsAttacking3", false);
        atk1 = false;
        atk2 = false;
        atk3 = false;
    }
}
