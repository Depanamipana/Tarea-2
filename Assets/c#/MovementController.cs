using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovementController : MonoBehaviour
{
    [SerializeField] private float moveSpeed = 5f;
    [SerializeField] private float runSpeed = 10f; // Velocidad de movimiento al correr
    [SerializeField] private float jumpForce = 10f;

    private Rigidbody2D rb;
    private Animator animator;

    private bool isGrounded = false;
    private bool isRunning = false; // Bool para controlar si el jugador está corriendo
    private float originalMoveSpeed; // Velocidad de movimiento original
    private bool isJumping = false; // Bool para controlar si el jugador está saltando

    void Start()
    {
        if(GameManager.Instance != null) { 
            transform.position = GameManager.Instance.lastCheckpointPosition;
        }
        rb = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
        originalMoveSpeed = moveSpeed;
    }

    void Update()
    {
        // Movimiento horizontal
        float moveInput = Input.GetAxisRaw("Horizontal");

        // Cambiar la velocidad de movimiento según el estado del botón Shift
        if (Input.GetKey(KeyCode.LeftShift))
        {
            isRunning = true;
            moveSpeed = runSpeed;
        }
        else
        {
            isRunning = false;
            moveSpeed = originalMoveSpeed;
        }

        rb.velocity = new Vector2(moveInput * moveSpeed, rb.velocity.y);

        // Salto
        if (Input.GetKeyDown(KeyCode.Space) && isGrounded)
        {
            rb.AddForce(Vector2.up * jumpForce, ForceMode2D.Impulse);
            isGrounded = false;
            isJumping = true;
        }

        // Activar animación cuando se mueve a la derecha
        if (moveInput > 0)
        {
            animator.SetBool("IsMoving", true);
            animator.SetBool("IsWalking", true);
            Vector3 cScale = transform.localScale;
            transform.localScale = new Vector3(Mathf.Abs(cScale.x), cScale.y, cScale.z); // Restaurar la dirección del sprite
        }
        // Activar animación cuando se mueve a la izquierda
        else if (moveInput < 0)
        {
            animator.SetBool("IsMoving", true);
            animator.SetBool("IsWalking", true);
            Vector3 cScale = transform.localScale;
            transform.localScale = new Vector3(Mathf.Abs(cScale.x) * -1, cScale.y, cScale.z); // Cambiar la dirección del sprite
        }
        else
        {
            animator.SetBool("IsMoving", false);
            animator.SetBool("IsWalking", false);
        }

        // Actualizar animación de correr
        animator.SetBool("IsRunning", isRunning);

        // Activar animación de saltar
        animator.SetBool("IsJumping", isJumping);
    }

    void OnCollisionEnter2D(Collision2D other)
    {
        // Verificar si estamos en el suelo
        if (other.gameObject.CompareTag("Ground"))
        {
            isGrounded = true;
            isJumping = false;
        }
    }
}

