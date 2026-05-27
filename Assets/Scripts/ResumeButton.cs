using UnityEngine;

public class ResumeButton : MonoBehaviour
{
    [SerializeField] private GameObject pauseMenuCanvas;

    public void Resume()
    {
        Time.timeScale = 1f;

        if (pauseMenuCanvas != null)
        {
            pauseMenuCanvas.SetActive(false);
        }

        if (GameManager.instance != null)
        {
            GameManager.instance.ResumeGame();
        }
    }
}