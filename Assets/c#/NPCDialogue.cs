using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NPCDialogue : MonoBehaviour
{
    public GameObject dialoguePanel; // Panel de diálogo
    public TMPro.TextMeshProUGUI dialogueText; // Texto de diálogo
    public string[] dialogLines; // Array que contiene las líneas de diálogo

    private bool dialogueActive = false; // Indica si el diálogo está activo
    private int currentLineIndex = 0; // Índice de la línea de diálogo actual

    void Update()
    {
        if (dialogueActive && Input.GetKeyDown(KeyCode.Space))
        {
            if (currentLineIndex < dialogLines.Length)
            {
                dialogueText.text = dialogLines[currentLineIndex];
                currentLineIndex++;
            }
            else
            {
                EndDialogue();
            }
        }
    }

    public void StartDialogue()
    {
        dialogueActive = true;
        dialoguePanel.SetActive(true); // Mostrar el panel de diálogo al iniciar el diálogo
    }

    private void EndDialogue()
    {
        dialogueActive = false;
        dialoguePanel.SetActive(false); // Ocultar el panel de diálogo al finalizar el diálogo
        currentLineIndex = 0; // Reiniciar el índice de línea de diálogo
    }
}
