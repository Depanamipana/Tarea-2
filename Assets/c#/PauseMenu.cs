using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PauseMenu : MonoBehaviour
{
    public GameObject pauseMenuUI; // Panel para asignar en el inspector

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (Time.timeScale == 1)
            {
                Time.timeScale = 0;
                pauseMenuUI.SetActive(true);
            }
            else
            {
                Time.timeScale = 1;
                pauseMenuUI.SetActive(false);
            }
        }
    }
}
