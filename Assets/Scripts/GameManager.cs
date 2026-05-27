using UnityEngine;
using UnityEngine.InputSystem;
using TMPro;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;

    public int collectedItems = 0;

    public TextMeshProUGUI counterText;

    public GameObject exitDoor;

    [Header("Pause")]
    [SerializeField] private GameObject pauseMenuCanvas;

    private bool isPaused = false;

    private void Awake()
    {
        instance = this;
    }

    private void Start()
    {
        counterText.text = "Предметів: 0/3";

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

    public void AddItem()
    {
        collectedItems++;

        counterText.text = "Предметів: " + collectedItems + "/3";

        Debug.Log("TEXT UPDATED");

        if (collectedItems >= 3)
        {
            exitDoor.SetActive(false);

            Debug.Log("EXIT OPENED");
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

    public void LoadMainMenu()
    {
        if (MusicManager.instance != null)
        {
            PlayerPrefs.SetFloat("MusicVolume", MusicManager.instance.GetVolume());
            PlayerPrefs.Save();
        }

        Time.timeScale = 1f;
        SceneManager.LoadScene("MainMenu");
    }

}