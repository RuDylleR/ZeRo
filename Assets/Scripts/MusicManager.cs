using UnityEngine;

public class MusicManager : MonoBehaviour
{
    public static MusicManager instance;

    public AudioClip[] musicTracks;

    private AudioSource audioSource;
    private int currentTrack = 0;

    private const string MUSIC_VOLUME_KEY = "MusicVolume";

    private void Awake()
    {
        if (instance != null && instance != this)
        {
            Destroy(gameObject);
            return;
        }

        instance = this;

        DontDestroyOnLoad(gameObject);

        audioSource = GetComponent<AudioSource>();

        // Якщо гучність ще не збережена
        if (!PlayerPrefs.HasKey(MUSIC_VOLUME_KEY))
        {
            PlayerPrefs.SetFloat(MUSIC_VOLUME_KEY, 0.3f);
            PlayerPrefs.Save();
        }

        // Завантаження збереженої гучності
        float savedVolume = PlayerPrefs.GetFloat(MUSIC_VOLUME_KEY);

        audioSource.volume = savedVolume;
    }

    private void Start()
    {
        if (audioSource == null) return;

        if (!audioSource.isPlaying)
        {
            PlayTrack(currentTrack);
        }
    }

    public void NextTrack()
    {
        if (musicTracks == null || musicTracks.Length == 0) return;

        currentTrack++;

        if (currentTrack >= musicTracks.Length)
        {
            currentTrack = 0;
        }

        PlayTrack(currentTrack);
    }

    private void PlayTrack(int index)
    {
        if (audioSource == null) return;
        if (musicTracks == null || musicTracks.Length == 0) return;

        audioSource.clip = musicTracks[index];

        audioSource.volume = GetSavedVolume();

        audioSource.Play();
    }

    public void SetVolume(float volume)
    {
        if (audioSource == null) return;

        volume = Mathf.Clamp01(volume);

        audioSource.volume = volume;

        PlayerPrefs.SetFloat(MUSIC_VOLUME_KEY, volume);

        PlayerPrefs.Save();
    }

    public float GetVolume()
    {
        if (audioSource == null)
        {
            return GetSavedVolume();
        }

        return audioSource.volume;
    }

    public float GetSavedVolume()
    {
        return PlayerPrefs.GetFloat(MUSIC_VOLUME_KEY, 0.3f);
    }

    public void ApplySavedVolume()
    {
        if (audioSource == null) return;

        audioSource.volume = GetSavedVolume();
    }
}