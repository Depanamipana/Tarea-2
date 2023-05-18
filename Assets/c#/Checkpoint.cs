using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Checkpoint : MonoBehaviour
{
    private bool isActivated = false; // Indica si el checkpoint ha sido activado

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (!isActivated && other.CompareTag("Player"))
        {
            isActivated = true;
            GameManager.Instance.UpdateLastCheckpoint(transform.position);
            Debug.Log("Checkpoint activated at position: " + transform.position);

            // Desactivar el objeto de checkpoint
            gameObject.SetActive(false);
        }
    }
}
