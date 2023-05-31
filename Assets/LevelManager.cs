using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class LevelManager : MonoBehaviour
{
    public GameObject pausePanel;
    public GameObject resumeButton;
    private bool isPaused = false;
    private int currentSceneIndex;

    private void Start()
    {
        currentSceneIndex = SceneManager.GetActiveScene().buildIndex;
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (isPaused)
                ResumeGame();
            else
                PauseGame();
        }
    }

    public void PauseGame()
    {
        isPaused = true;
        Time.timeScale = 0f; // Pausa el tiempo en el juego
        pausePanel.SetActive(true); // Activa el panel de pausa
        resumeButton.SetActive(true); // Activa el botón de reanudar
    }

    public void ResumeGame()
    {
        isPaused = false;
        Time.timeScale = 1f; // Restaura el tiempo normal del juego
        pausePanel.SetActive(false); // Desactiva el panel de pausa
        resumeButton.SetActive(false); // Desactiva el botón de reanudar
    }

    public void ContinueLevel()
    {
        ResumeGame(); // Reanuda el juego

        // Aquí puedes añadir cualquier lógica adicional para continuar el nivel, como guardar el progreso del jugador, restaurar la posición inicial, etc.
    }
}
