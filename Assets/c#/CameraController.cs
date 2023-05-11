using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    [SerializeField] private Transform player;
    [SerializeField] private float smoothTime = 0.3f;
    [SerializeField] private float offsetX = 0f;

    private Vector3 velocity = Vector3.zero;

    private void LateUpdate()
    {
        // Posición actual de la cámara
        Vector3 currentPosition = transform.position;

        // Posición objetivo (jugador)
        Vector3 targetPosition = new Vector3(player.position.x + offsetX, currentPosition.y, currentPosition.z);

        // Suavizado de la transición entre la posición actual y la objetivo
        transform.position = Vector3.SmoothDamp(currentPosition, targetPosition, ref velocity, smoothTime);
    }
}
