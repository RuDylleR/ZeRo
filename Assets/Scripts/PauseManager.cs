using UnityEngine;
using UnityEngine.InputSystem;

public class PauseManager : MonoBehaviour
{
    public static PauseManager Instance { get; private set; }

    [SerializeField] private GameObject pauseMenuCanvas;

    private bool isPaused;

    private void Awake()
    {
        Instance = this;
    }

    private void Start()
    {
        pauseMenuCanvas.SetActive(false);
    }

    private void Update()
    {
        if (Keyboard.current.escapeKey.wasPressedThisFrame)
        {
            if (isPaused)
            {
                ResumeGame();
            }
            else
            {
                PauseGame();
            }
        }
    }

    public void PauseGame()
    {
        pauseMenuCanvas.SetActive(true);

        Time.timeScale = 0f;

        isPaused = true;
    }

    public void ResumeGame()
    {
        pauseMenuCanvas.SetActive(false);

        Time.timeScale = 1f;

        isPaused = false;
    }
}