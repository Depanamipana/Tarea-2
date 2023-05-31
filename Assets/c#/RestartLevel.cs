using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class RestartLevel : MonoBehaviour
{
    private void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            RaycastHit2D hit = Physics2D.Raycast(Camera.main.ScreenToWorldPoint(Input.mousePosition), Vector2.zero);
            if (hit.collider != null && hit.collider.GetComponent<TextMeshProUGUI>() == GetComponent<TextMeshProUGUI>())
            {
                Restart();
            }
        }
    }

    private void Restart()
    {
        // Reinicia el nivel actual
        int currentSceneIndex = SceneManager.GetActiveScene().buildIndex;
        SceneManager.LoadScene(currentSceneIndex);
    }
}
