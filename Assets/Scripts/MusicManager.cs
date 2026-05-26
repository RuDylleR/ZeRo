using UnityEngine;

public class MusicManager : MonoBehaviour
{
    public static MusicManager instance;

    public AudioClip[] musicTracks;

    private AudioSource audioSource;

    private int currentTrack = 0;

    void Awake()
    {
        if (instance != null)
        {
            Destroy(gameObject);
            return;
        }

        instance = this;

        DontDestroyOnLoad(gameObject);

        audioSource = GetComponent<AudioSource>();
    }

    void Start()
    {
        PlayTrack(currentTrack);
    }

    public void NextTrack()
    {
        currentTrack++;

        if (currentTrack >= musicTracks.Length)
        {
            currentTrack = 0;
        }

        PlayTrack(currentTrack);
    }

    void PlayTrack(int index)
    {
        audioSource.clip = musicTracks[index];

        audioSource.Play();
    }
}