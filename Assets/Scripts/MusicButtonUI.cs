using UnityEngine;

public class MusicButtonUI : MonoBehaviour
{
    public void NextMusic()
    {
        if (MusicManager.instance != null)
        {
            MusicManager.instance.NextTrack();
        }
    }
}
