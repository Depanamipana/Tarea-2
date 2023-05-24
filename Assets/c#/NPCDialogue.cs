using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NPCDialogue : MonoBehaviour
{
    public GameObject dialoguePanel; // Panel de di�logo
    public TMPro.TextMeshProUGUI dialogueText; // Texto de di�logo
    public string[] dialogLines; // Array que contiene las l�neas de di�logo

    private bool dialogueActive = false; // Indica si el di�logo est� activo
    private int currentLineIndex = 0; // �ndice de la l�nea de di�logo actual

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
        dialoguePanel.SetActive(true); // Mostrar el panel de di�logo al iniciar el di�logo
    }

    private void EndDialogue()
    {
        dialogueActive = false;
        dialoguePanel.SetActive(false); // Ocultar el panel de di�logo al finalizar el di�logo
        currentLineIndex = 0; // Reiniciar el �ndice de l�nea de di�logo
    }
}
