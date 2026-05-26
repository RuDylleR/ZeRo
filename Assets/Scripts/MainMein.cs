using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MainMenu : MonoBehaviour
{
    public Slider volumeSlider;
    public AudioSource musicSource;

    void Start()
    {
        volumeSlider.value = musicSource.volume;
    }

    public void StartGame()
    {
        SceneManager.LoadScene("Level1");
    }

    public void ExitGame()
    {
        Application.Quit();
        Debug.Log("Exit");
    }

    public void SetVolume(float volume)
    {

        Debug.Log("Slider volume = " + volume);

        musicSource.volume = volume;

        if (!musicSource.isPlaying)
        {
            Debug.Log("Music stopped, starting again");
            musicSource.Play();
        }
    }
}